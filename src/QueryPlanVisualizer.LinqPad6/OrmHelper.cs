using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace QueryPlanVisualizer.LinqPad6
{
    internal abstract class OrmHelper
    {
        private readonly PlanProcessor planProcessor;
        private readonly DatabaseProvider databaseProvider;

        protected OrmHelper((DatabaseProvider provider, PlanProcessor planConvertor) parameters)
        {
            databaseProvider = parameters.provider;
            planProcessor = parameters.planConvertor;
        }

        public static OrmHelper Create<T>(IQueryable<T> queryable, string driver)
        {
            if (driver.Contains("EntityFrameworkCore"))
            {
                return new EFCoreHelper(driver);
            }

            var queryType = queryable.GetType();

            var dataQueryType = queryType.Assembly.GetType("System.Data.Linq.DataQuery`1");
            var tableQueryType = queryType.Assembly.GetType("System.Data.Linq.Table`1");

            var queryGenericType = queryType.GetGenericTypeDefinition();
            if (queryGenericType == dataQueryType || queryGenericType == tableQueryType)
            {
                var contextField = queryType.GetField("context", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
                var context = contextField?.GetValue(queryable);

                if (context != null)
                {
                    return new LinqToSqlHelper(context);
                }
            }

            return null;
        }

        protected abstract DbCommand CreateCommand(IQueryable queryable);

        public PlanProcessor GetPlanProcessor<T>(IQueryable<T> queryable)
        {
            var query = GetQueryText(queryable);
            planProcessor.Initialize(query);
            return planProcessor;
        }

        public DatabaseProvider GetDatabaseProvider<T>(IQueryable<T> queryable)
        {
            if (databaseProvider == null)
            {
                return null;
            }

            var dbCommand = CreateCommand(queryable);
            databaseProvider.Initialize(dbCommand);
            return databaseProvider;
        }

        protected abstract string GetQueryText<T>(IQueryable<T> queryable);
    }

    class EFCoreHelper : OrmHelper
    {
        public EFCoreHelper(string provider) : base(CreateParameters(provider))
        {
        }

        static (DatabaseProvider provider, PlanProcessor planConvertor) CreateParameters(string provider)
        {
            switch (provider)
            {
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    return (new SqlServerDatabaseProvider(), new SqlServerPlanProcessor());
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    return (new PostgresDatabaseProvider(), new PostgresPlanProcessor());
            }
            return (null, null);
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            return queryable.CreateDbCommand();
        }

        protected override string GetQueryText<T>(IQueryable<T> queryable)
        {
            return queryable.ToQueryString();
        }
    }

    class LinqToSqlHelper : OrmHelper
    {
        private readonly object dataContext;

        public LinqToSqlHelper(object dataContext) : base((new SqlServerDatabaseProvider(), new SqlServerPlanProcessor()))
        {
            this.dataContext = dataContext;
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            var getCommand = dataContext.GetType().GetMethod("GetCommand", BindingFlags.Public | BindingFlags.Instance);
            return getCommand.Invoke(dataContext, new object[] { queryable }) as DbCommand;
        }

        protected override string GetQueryText<T>(IQueryable<T> queryable)
        {
            return queryable.ToString();
        }
    }
}
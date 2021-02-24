using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace QueryPlanVisualizer.LinqPad6
{
    internal abstract class OrmHelper
    {
        private readonly IPlanConvertor planConvertor;
        private readonly DatabaseProvider databaseProvider;

        protected OrmHelper((DatabaseProvider provider, IPlanConvertor planConvertor) parameters)
        {
            databaseProvider = parameters.provider;
            planConvertor = parameters.planConvertor;
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

        public IPlanConvertor GetPlanConvertor()
        {
            return planConvertor;
        }

        public DatabaseProvider GetDatabaseProvider<T>(IQueryable<T> queryable)
        {
            if (databaseProvider == null)
            {
                return null;
            }

            var dbCommand = CreateCommand(queryable);
            databaseProvider.Initialize(dbCommand, queryable.ToQueryString());
            return databaseProvider;
        }
    }

    class EFCoreHelper : OrmHelper
    {
        public EFCoreHelper(string provider) : base(CreateParameters(provider))
        {
        }

        static (DatabaseProvider provider, IPlanConvertor planConvertor) CreateParameters(string provider)
        {
            switch (provider)
            {
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    return (new SqlServerDatabaseProvider(), new SqlServerPlanConvertor());
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    return (new PostgresDatabaseProvider(), new PostgresPlanConvertor());
            }
            return (null, null);
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            return queryable.CreateDbCommand();
        }
    }

    class LinqToSqlHelper : OrmHelper
    {
        private readonly object dataContext;

        public LinqToSqlHelper(object dataContext) : base((new SqlServerDatabaseProvider(), new SqlServerPlanConvertor()))
        {
            this.dataContext = dataContext;
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            var getCommand = dataContext.GetType().GetMethod("GetCommand", BindingFlags.Public | BindingFlags.Instance);
            return getCommand.Invoke(dataContext, new object[] { queryable }) as DbCommand;
        }
    }
}
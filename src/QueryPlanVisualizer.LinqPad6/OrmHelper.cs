using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExecutionPlanVisualizer
{
    internal abstract class OrmHelper
    {
        public PlanProcessor PlanProcessor { get; }
        public DatabaseProvider DatabaseProvider { get; }

        public static OrmHelper Create<T>(IQueryable<T> queryable, object dataContext)
        {
            if (dataContext is DbContext dbContext)
            {
                var efCoreHelper = new EFCoreHelper(dbContext.Database.ProviderName);
                efCoreHelper.Initialize(queryable);
                return efCoreHelper;
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
                    var linqToSqlHelper = new LinqToSqlHelper(context);
                    linqToSqlHelper.Initialize(queryable);
                    return linqToSqlHelper;
                }
            }

            return null;
        }

        protected OrmHelper((DatabaseProvider provider, PlanProcessor planConvertor) parameters)
        {
            DatabaseProvider = parameters.provider;
            PlanProcessor = parameters.planConvertor;
        }

        private void Initialize(IQueryable queryable)
        {
            PlanProcessor?.Initialize(GetQueryText(queryable));
            DatabaseProvider?.Initialize(CreateCommand(queryable));
        }

        protected abstract string GetQueryText(IQueryable queryable);
        protected abstract DbCommand CreateCommand(IQueryable queryable);
    }

    class EFCoreHelper : OrmHelper
    {
        public EFCoreHelper(string provider) : base(CreateParameters(provider))
        {
        }

        public static (DatabaseProvider provider, PlanProcessor planConvertor) CreateParameters(string provider)
        {
            return provider switch
            {
                "Microsoft.EntityFrameworkCore.SqlServer" => (new SqlServerDatabaseProvider(), new SqlServerPlanProcessor()),
                "Npgsql.EntityFrameworkCore.PostgreSQL" => (new PostgresDatabaseProvider(), new PostgresPlanProcessor()),
                _ => (null, null)
            };
        }

        protected override DbCommand CreateCommand(IQueryable queryable) => queryable.CreateDbCommand();

        protected override string GetQueryText(IQueryable queryable) => queryable.ToQueryString();
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

        protected override string GetQueryText(IQueryable queryable) => queryable.ToString();
    }
}
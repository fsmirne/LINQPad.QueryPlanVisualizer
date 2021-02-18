using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace QueryPlanVisualizer.LinqPad6
{
    internal abstract class OrmHelper
    {
        private readonly DatabaseProcessor databaseProcessor;

        protected OrmHelper(DatabaseProcessor databaseProcessor)
        {
            this.databaseProcessor = databaseProcessor;
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

        public DatabaseProcessor GetDatabaseProcessor<T>(IQueryable<T> queryable)
        {
            if (databaseProcessor == null)
            {
                return null;
            }

            var dbCommand = CreateCommand(queryable);
            databaseProcessor.Initialize(dbCommand);
            return databaseProcessor;
        }
    }

    class EFCoreHelper : OrmHelper
    {
        public EFCoreHelper(string provider) : base(GetDatabaseProcessor(provider))
        {
        }

        private static DatabaseProcessor GetDatabaseProcessor(string provider)
        {
            switch (provider)
            {
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    return new SqlServerDatabaseProcessor();
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    return new PostgresDatabaseProcessor();
                default:
                    return null;
            }
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            return queryable.CreateDbCommand();
        }
    }

    class LinqToSqlHelper : OrmHelper
    {
        private readonly object dataContext;

        public LinqToSqlHelper(object dataContext) : base(new SqlServerDatabaseProcessor())
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
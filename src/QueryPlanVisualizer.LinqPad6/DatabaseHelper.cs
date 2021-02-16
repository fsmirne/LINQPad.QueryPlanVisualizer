using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace QueryPlanVisualizer.LinqPad6
{
    internal abstract class DatabaseHelper
    {
        private readonly IPlanExtractor planExtractor;

        protected DatabaseHelper(IPlanExtractor planExtractor)
        {
            this.planExtractor = planExtractor;
        }

        public static DatabaseHelper Create<T>(IQueryable<T> queryable, string driver)
        {
            if (driver.Contains("EntityFrameworkCore"))
            {
                return new EFCoreDatabaseHelper(driver);
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
                    return new LinqToSqlDatabaseHelper(context);
                }
            }

            return null;
        }

        public virtual string GetQueryPlan<T>(IQueryable<T> queryable)
        {
            if (planExtractor == null)
            {
                return null;
            }

            using var command = CreateCommand(queryable);
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                return planExtractor.ExtractPlan(command);
            }
            finally
            {
                command.Connection.Close();
            }
        }

        protected abstract DbCommand CreateCommand(IQueryable queryable);
    }

    class EFCoreDatabaseHelper : DatabaseHelper
    {
        public EFCoreDatabaseHelper(string provider) : base(GetPlanExtractor(provider))
        {
        }

        private static IPlanExtractor GetPlanExtractor(string provider)
        {
            switch (provider)
            {
                case "Microsoft.EntityFrameworkCore.SqlServer":
                    return new SqlServerPlanExtractor();
                case "Npgsql.EntityFrameworkCore.PostgreSQL":
                    return new PostgresPlanExtractor();
                default:
                    return null;
            }
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            return queryable.CreateDbCommand();
        }
    }

    class LinqToSqlDatabaseHelper : DatabaseHelper
    {
        private readonly object dataContext;

        public LinqToSqlDatabaseHelper(object dataContext) : base(new SqlServerPlanExtractor())
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
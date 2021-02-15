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
        public static DatabaseHelper Create<T>(IQueryable<T> queryable)
        {
            if (queryable is EntityQueryable<T>) // queryable is EntityQueryable<T> forces us to add where T : class to the method so we can't do that
            {
                return new EFCoreDatabaseHelper();
            }

            if (queryable.GetType().GetGenericTypeDefinition() == typeof(InternalDbSet<object>).GetGenericTypeDefinition())
            {
                return new EFCoreDatabaseHelper();
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

        public virtual string GetSqlServerQueryExecutionPlan<T>(IQueryable<T> queryable)
        {
            using var command = CreateCommand(queryable);
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                using (var setStatisticsCommand = command.Connection.CreateCommand())
                {
                    setStatisticsCommand.CommandText = "SET STATISTICS XML ON";
                    setStatisticsCommand.ExecuteNonQuery();
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.NextResult())
                    {
                        if (reader.GetName(0) == "Microsoft SQL Server 2005 XML Showplan")
                        {
                            reader.Read();
                            return reader.GetString(0);
                        }
                    }
                }

                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        protected abstract DbCommand CreateCommand(IQueryable queryable);
    }

    class LinqToSqlDatabaseHelper : DatabaseHelper
    {
        private readonly object dataContext;

        public LinqToSqlDatabaseHelper(object dataContext)
        {
            this.dataContext = dataContext;
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            var getCommand = dataContext.GetType().GetMethod("GetCommand", BindingFlags.Public | BindingFlags.Instance);
            return getCommand.Invoke(dataContext, new object[] { queryable }) as DbCommand;
        }
    }

    class EFCoreDatabaseHelper : DatabaseHelper
    {
        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            return queryable.CreateDbCommand();
        }
    }
}
using LINQPad;
using System.Linq;

namespace QueryPlanVisualizer.LinqPad6
{
    public static class QueryPlanVisualizer
    {
        public static IQueryable<T> DumpPlan<T>(this IQueryable<T> queryable, bool dumpData = false)
        {
            DumpPlanInternal(queryable, dumpData, true);

            return queryable;
        }

        private static void DumpPlanInternal<T>(IQueryable<T> queryable, in bool dumpData, bool addNewPanel)
        {
            var databaseHelper = DatabaseHelper.Create(queryable);

            if (databaseHelper == null)
            {
                return;
            }

            databaseHelper.GetSqlServerQueryExecutionPlan(queryable).Dump();
        }
    }
}

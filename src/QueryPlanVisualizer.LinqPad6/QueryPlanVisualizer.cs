using System;
using LINQPad;
using System.Linq;
using System.Windows.Forms;

namespace QueryPlanVisualizer.LinqPad6
{
    public static class QueryPlanVisualizer
    {
        private const string ExecutionPlanPanelTitle = "Query Execution Plan";

        public static IQueryable<T> DumpPlan<T>(this IQueryable<T> queryable, bool dumpData = false)
        {
            try
            {
                DumpPlanInternal(queryable, dumpData, true);
            }
            catch (Exception exception)
            {
                ShowError(exception.Message);
            }

            return queryable;
        }

        private static void DumpPlanInternal<T>(IQueryable<T> queryable, bool dumpData, bool addNewPanel)
        {
            var databaseHelper = DatabaseHelper.Create(queryable, Util.CurrentQuery.GetConnectionInfo().DriverData.Element("EFProvider").Value);

            if (databaseHelper == null)
            {
                ShowError("The selected database or database driver isn't supported");
                return;
            }
            
            if (dumpData)
            {
                queryable.Dump();
            }

            var rawPlan = databaseHelper.GetQueryPlan(queryable).Dump();

            if (string.IsNullOrEmpty(rawPlan))
            {
                ShowError("Cannot extract query plan");
                return;
            }
        }

        private static void ShowError(string text)
        {
            var control = new Label { Text = text };
            control.Dump(ExecutionPlanPanelTitle);
        }
    }
}

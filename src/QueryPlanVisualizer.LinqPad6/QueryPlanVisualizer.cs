using LINQPad;
using QueryPlanVisualizer.LinqPad6;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ExecutionPlanVisualizer
{
    public static class QueryPlanVisualizer
    {
        private const string ExecutionPlanPanelTitle = "Query Execution Plan";

        public static IQueryable<T> DumpPlan<T>(this IQueryable<T> queryable, bool dumpData = false)
        {
            try
            {
                DumpPlanInternal(queryable, dumpData);
            }
            catch (Exception exception)
            {
                ShowError(exception.Message);
            }

            return queryable;
        }

        private static void DumpPlanInternal<T>(IQueryable<T> queryable, bool dumpData)
        {
            var ormHelper = OrmHelper.Create(queryable, Util.CurrentDataContext);
            
            if (ormHelper == null)
            {
                ShowError("The selected database or database driver isn't supported");
                return;
            }

            if (dumpData)
            {
                queryable.Dump();
            }

            if (ormHelper.DatabaseProvider == null)
            {
                ShowError("Selected database not supported");
                return;
            }

            var rawPlan = ormHelper.DatabaseProvider.ExtractPlan();

            if (string.IsNullOrEmpty(rawPlan))
            {
                ShowError("Cannot extract query plan");
                return;
            }

            var control = new QueryPlanUserControl
            {
                DatabaseProvider = ormHelper.DatabaseProvider,
                PlanProcessor = ormHelper.PlanProcessor
            };

            control.DisplayPlan(rawPlan);
            control.Dump(ExecutionPlanPanelTitle);
        }

        private static void ShowError(string text)
        {
            var control = new Label { Text = text };
            control.Dump(ExecutionPlanPanelTitle);
        }
    }
}

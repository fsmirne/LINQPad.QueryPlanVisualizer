using LINQPad;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

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

            string webViewFolder = null;

            try
            {
                CoreWebView2Environment.GetAvailableBrowserVersionString();
            }
            catch (WebView2RuntimeNotFoundException)
            {
                var nestedType = typeof(Util).GetNestedType("BrowserEngine");

                var methodInfo = nestedType?.GetMethod("GetWebView2ExecutableFolder", BindingFlags.Static | BindingFlags.Public);
                webViewFolder = methodInfo?.Invoke(null, null)?.ToString();

                if (nestedType == null || methodInfo == null || string.IsNullOrEmpty(webViewFolder))
                {
                    ShowError("Query Plan Visualizer requires Webview2 Runtime installation but it was not found.");
                    return;
                }

                try
                {
                    var browserVersionString = CoreWebView2Environment.GetAvailableBrowserVersionString(webViewFolder);
                }
                catch (WebView2RuntimeNotFoundException)
                {
                    ShowError("Query Plan Visualizer requires Webview2 Runtime installation but it was not found.");
                    return;
                }
            }

            var control = new QueryPlanUserControl
            {
                WebViewFolder = webViewFolder,
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

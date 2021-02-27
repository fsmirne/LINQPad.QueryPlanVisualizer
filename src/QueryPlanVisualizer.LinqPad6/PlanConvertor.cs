using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using ExecutionPlanVisualizer.Helpers;

namespace ExecutionPlanVisualizer
{
    internal abstract class PlanProcessor
    {
        public string Query { get; private set; }
        
        public void Initialize(string query)
        {
            Query = query;
        }

        public abstract string ConvertPlanToHtml(string rawPlan);
        public abstract Task<string> SharePlanAsync(string plan);
    }

    class PostgresPlanProcessor : PlanProcessor
    {
        public override string ConvertPlanToHtml(string rawPlan)
        {
            return rawPlan.Replace(Environment.NewLine, "<br/>").Replace(" ","&nbsp;");
        }

        public override async Task<string> SharePlanAsync(string plan)
        {
            using var client = new HttpClient();
            var data = new { plan = plan, title = "Query Plan from LINQPad", query = Query };
            var responseMessage = await client.PostAsJsonAsync("https://explain.dalibo.com/new", data);
            return responseMessage.RequestMessage.RequestUri.ToString();
        }
    }

    class SqlServerPlanProcessor : PlanProcessor
    {
        static bool shouldExtract = true;

        public List<string> ExtractFiles()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LINQPadQueryVisualizer", "SqlServer");
            
            var qpJavascript = Path.Combine(folder, "qp.js");
            var qpStyleSheet = Path.Combine(folder, "qp.css");
            
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (shouldExtract)
            {
                var icons = Path.Combine(folder, "qp_icons.png");

                using (var iconsStream = File.OpenWrite(icons))
                {
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("ExecutionPlanVisualizer.Resources.qp_icons.png").CopyTo(iconsStream);
                }

                File.WriteAllText(qpJavascript, SqlServerResources.qp_min_js);
                File.WriteAllText(qpStyleSheet, SqlServerResources.qp_css); 
            }

            shouldExtract = false;

            return new List<string> { qpStyleSheet, qpJavascript};
        }

        public override string ConvertPlanToHtml(string rawPlan)
        {
            var files = ExtractFiles();
            files.Add(rawPlan);

            return string.Format(SqlServerResources.template, files.ToArray());
        }

        public override async Task<string> SharePlanAsync(string plan)
        {
            using var client = new HttpClient();
            var responseMessage = await client.PostAsJsonAsync("https://jeczi7iqj8.execute-api.us-west-2.amazonaws.com/prod/", new { queryplan_xml = plan });
            var doc = await JsonDocument.ParseAsync(await responseMessage.Content.ReadAsStreamAsync());
            var queryId = doc.RootElement.GetProperty("id").GetString();

            return $"https://www.brentozar.com/pastetheplan/?id={queryId}";
        }
    }
}
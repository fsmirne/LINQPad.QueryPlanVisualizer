using ExecutionPlanVisualizer.Helpers;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExecutionPlanVisualizer
{
    internal abstract class PlanProcessor
    {
        public string Query { get; private set; }

        public abstract string SharePlanWebsite { get; }
        protected abstract string PlanFolder { get; }

        protected string PlanFileFolderFullPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                                "LINQPadQueryVisualizer", PlanFolder);

        private string planFileName = $"plan {Guid.NewGuid()}.html";

        protected string PlanFilePath => Path.Combine(PlanFileFolderFullPath, planFileName);

        public void Initialize(string query)
        {
            Query = query;
        }

        protected abstract void ExtractFiles();
        public abstract string GeneratePlanHtml(string rawPlan);
        public abstract Task<string> SharePlanAsync(string plan);
    }

    class PostgresPlanProcessor : PlanProcessor
    {
        static bool shouldExtract = true;
        public override string SharePlanWebsite => "https://explain.dalibo.com/";
        protected override string PlanFolder => "Postgres";

        protected override void ExtractFiles()
        {
            Directory.CreateDirectory(Path.Combine(PlanFileFolderFullPath, "js"));
            Directory.CreateDirectory(Path.Combine(PlanFileFolderFullPath, "css"));

            if (shouldExtract)
            {
                var allStylesheet = Path.Combine(PlanFileFolderFullPath, "css", "all.css");
                var appStylesheet = Path.Combine(PlanFileFolderFullPath, "css", "app.css");
                var bootstrapStylesheet = Path.Combine(PlanFileFolderFullPath, "css", "bootstrap.min.css");

                var chunkJavascript = Path.Combine(PlanFileFolderFullPath, "js", "chunk-vendors.js");

                File.WriteAllText(allStylesheet, PostgresResources.all);
                File.WriteAllText(appStylesheet, PostgresResources.app_css);
                File.WriteAllText(bootstrapStylesheet, PostgresResources.bootstrap_min);
                File.WriteAllText(chunkJavascript, PostgresResources.chunk_vendors);

                File.WriteAllText(PlanFilePath, PostgresResources.index);
            }

            shouldExtract = false;
        }

        public override string GeneratePlanHtml(string rawPlan)
        {
            ExtractFiles();

            var appJavascript = Path.Combine(PlanFileFolderFullPath, "js", "app.js");
            var appJs = PostgresResources.app_js.Replace("{plan}", JavaScriptEncoder.UnsafeRelaxedJsonEscaping.Encode(rawPlan).Replace("'", "\\'"))
                                                .Replace("{query}", JavaScriptEncoder.UnsafeRelaxedJsonEscaping.Encode(Query).Replace("'", "\\'"));

            File.WriteAllText(appJavascript, appJs);

            return PlanFilePath;
        }

        public override async Task<string> SharePlanAsync(string plan)
        {
            using var client = new HttpClient();
            var data = new { plan = plan, title = "Query Plan from LINQPad", query = Query };
            var responseMessage = await client.PostAsJsonAsync("https://explain.dalibo.com/new.json", data);
            var doc = await JsonDocument.ParseAsync(await responseMessage.Content.ReadAsStreamAsync());
            var queryId = doc.RootElement.GetProperty("id").GetString();

            return $"https://explain.dalibo.com/plan/{queryId}";
        }
    }

    class SqlServerPlanProcessor : PlanProcessor
    {
        static bool shouldExtract = true;
        public override string SharePlanWebsite => "https://www.brentozar.com/pastetheplan/";
        protected override string PlanFolder => "SqlServer";

        protected override void ExtractFiles()
        {
            Directory.CreateDirectory(PlanFileFolderFullPath);

            if (shouldExtract)
            {
                var icons = Path.Combine(PlanFileFolderFullPath, "qp_icons.png");
                var qpJavascript = Path.Combine(PlanFileFolderFullPath, "qp.js");
                var qpStyleSheet = Path.Combine(PlanFileFolderFullPath, "qp.css");

                File.WriteAllText(qpJavascript, SqlServerResources.qp_min_js);
                File.WriteAllText(qpStyleSheet, SqlServerResources.qp_css);
                SqlServerResources.qp_icons.Save(icons);
            }

            shouldExtract = false;
        }

        public override string GeneratePlanHtml(string rawPlan)
        {
            ExtractFiles();

            var html = string.Format(SqlServerResources.template, rawPlan);

            File.WriteAllText(PlanFilePath, html);

            return PlanFilePath;
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
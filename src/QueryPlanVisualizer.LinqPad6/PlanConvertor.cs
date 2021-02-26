using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace QueryPlanVisualizer.LinqPad6
{
    interface IPlanConvertor
    {
        string ConvertPlanToHtml(string rawPlan);
    }

    class PostgresPlanConvertor : IPlanConvertor
    {
        public string ConvertPlanToHtml(string rawPlan)
        {
            return rawPlan.Replace(Environment.NewLine, "<br/>").Replace(" ","&nbsp;");
        }
    }

    class SqlServerPlanConvertor : IPlanConvertor
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
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("QueryPlanVisualizer.LinqPad6.Resources.qp_icons.png").CopyTo(iconsStream);
                }

                File.WriteAllText(qpJavascript, SqlServerResources.qp_min_js);
                File.WriteAllText(qpStyleSheet, SqlServerResources.qp_css); 
            }

            shouldExtract = false;

            return new List<string> { qpStyleSheet, qpJavascript};
        }

        public string ConvertPlanToHtml(string rawPlan)
        {
            var files = ExtractFiles();
            files.Add(rawPlan);

            return string.Format(SqlServerResources.template, files.ToArray());
        }
    }
}
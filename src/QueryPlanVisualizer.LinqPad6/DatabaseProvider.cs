using ExecutionPlanVisualizer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QueryPlanVisualizer.LinqPad6
{
    abstract class DatabaseProvider
    {
        public string Query { get; private set; }
        private DbCommand command;

        public abstract string PlanExtension { get; }
        public abstract string PlanSaveDialogFilter { get; }
        public abstract string SharePlanWebsite { get; }

        internal void Initialize(DbCommand command, string query)
        {
            this.command = command;
            this.Query = query;
        }

        public string ExtractPlan()
        {
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                return ExtractPlanInternal(command);
            }
            finally
            {
                command.Connection.Close();
            }
        }

        protected abstract string ExtractPlanInternal(DbCommand command);

        public virtual List<MissingIndexDetails> GetMissingIndexes(string rawPlan)
        {
            return new List<MissingIndexDetails>();
        }

        public abstract Task<string> SharePlanAsync(string plan);
    }

    class PostgresDatabaseProvider : DatabaseProvider
    {
        public override string PlanExtension { get; } = "txt";
        public override string PlanSaveDialogFilter { get; } = "Text Files|*.txt";
        public override string SharePlanWebsite { get; } = "https://explain.dalibo.com/";

        protected override string ExtractPlanInternal(DbCommand command)
        {
            command.CommandText = "EXPLAIN (ANALYZE, COSTS, VERBOSE, BUFFERS) " + command.CommandText;

            using var reader = command.ExecuteReader();
            var plan = string.Join(Environment.NewLine, reader.Cast<IDataRecord>().Select(r => r.GetString(0)));

            return plan;
        }

        public override async Task<string> SharePlanAsync(string plan)
        {
            using var client = new HttpClient();
            var data = new { plan = plan, title = "Query Plan from LINQpad", query = Query };
            var responseMessage = await client.PostAsJsonAsync("https://explain.dalibo.com/new", data);
            return responseMessage.RequestMessage.RequestUri.ToString();
        }
    }

    class SqlServerDatabaseProvider : DatabaseProvider
    {
        private static readonly XNamespace PlanXmlNamespace = "http://schemas.microsoft.com/sqlserver/2004/07/showplan";

        public override string PlanExtension { get; } = "sqlplan";
        public override string PlanSaveDialogFilter { get; } = "Execution Plan Files|*.sqlplan";
        public override string SharePlanWebsite { get; } = "https://www.brentozar.com/pastetheplan/";

        protected override string ExtractPlanInternal(DbCommand command)
        {
            using var setStatisticsCommand = command.Connection.CreateCommand();
            setStatisticsCommand.CommandText = "SET STATISTICS XML ON";
            setStatisticsCommand.ExecuteNonQuery();

            using var reader = command.ExecuteReader();
            while (reader.NextResult())
            {
                if (reader.GetName(0) == "Microsoft SQL Server 2005 XML Showplan")
                {
                    reader.Read();
                    return reader.GetString(0);
                }
            }

            return null;
        }

        public override List<MissingIndexDetails> GetMissingIndexes(string rawPlan)
        {
            var document = XDocument.Parse(rawPlan);

            var missingIndexGroups = document.Descendants(PlanXmlNamespace.WithName("MissingIndexGroup"));

            var result = from missingIndexGroup in missingIndexGroups

                         let missingIndexes = missingIndexGroup.Descendants(PlanXmlNamespace.WithName("MissingIndex"))

                         let indexes = from missingIndex in missingIndexes
                                       let columnGroups = missingIndex.Descendants(PlanXmlNamespace.WithName("ColumnGroup"))

                                       let equalityColumns = (from columnGroup in columnGroups
                                                              where columnGroup.AttributeValue("Usage") == "EQUALITY"
                                                              from column in columnGroup.Descendants()
                                                              select column.AttributeValue("Name"))

                                       let inequalityColumns = (from columnGroup in columnGroups
                                                                where columnGroup.AttributeValue("Usage") == "INEQUALITY"
                                                                from column in columnGroup.Descendants()
                                                                select column.AttributeValue("Name"))

                                       let includeColumns = (from columnGroup in columnGroups
                                                             where columnGroup.AttributeValue("Usage") == "INCLUDE"
                                                             from column in columnGroup.Descendants()
                                                             select column.AttributeValue("Name"))

                                       select new MissingIndexDetails
                                       {
                                           Impact = Convert.ToDouble(missingIndexGroup.AttributeValue("Impact")),

                                           Database = missingIndex.AttributeValue("Database"),
                                           Table = missingIndex.AttributeValue("Table"),
                                           Schema = missingIndex.AttributeValue("Schema"),

                                           EqualityColumns = new List<string>(equalityColumns),
                                           InequalityColumns = new List<string>(inequalityColumns),

                                           IncludeColumns = new List<string>(includeColumns)
                                       }

                         from index in indexes
                         select index;

            return result.ToList();
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
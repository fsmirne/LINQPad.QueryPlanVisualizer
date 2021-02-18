using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace QueryPlanVisualizer.LinqPad6
{
    abstract class DatabaseProcessor
    {
        private DbCommand command;

        internal void Initialize(DbCommand command)
        {
            this.command = command;
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
        public abstract string ConvertPlanToHtml(string rawPlan);
    }

    class PostgresDatabaseProcessor : DatabaseProcessor
    {
        protected override string ExtractPlanInternal(DbCommand command)
        {
            command.CommandText = "EXPLAIN (ANALYZE, COSTS, VERBOSE, BUFFERS) " + command.CommandText;

            using var reader = command.ExecuteReader();
            var plan = string.Join(Environment.NewLine, reader.Cast<IDataRecord>().Select(r => r.GetString(0)));

            return plan;
        }

        public override string ConvertPlanToHtml(string rawPlan)
        {
            return rawPlan;
        }
    }

    class SqlServerDatabaseProcessor : DatabaseProcessor
    {
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

        public override string ConvertPlanToHtml(string rawPlan)
        {
            using var reader = XmlReader.Create(new StringReader(rawPlan));
            var transform = new XslCompiledTransform(true);
            transform.Load("qp.xslt");

            var returnValue = new StringBuilder();

            using (var writer = XmlWriter.Create(returnValue, transform.OutputSettings))
            {
                transform.Transform(reader, writer);
            }

            return returnValue.ToString();
        }
    }
}
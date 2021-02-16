using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace QueryPlanVisualizer.LinqPad6
{
    internal interface IPlanExtractor
    {
        string ExtractPlan(DbCommand command);
    }

    class PostgresPlanExtractor : IPlanExtractor
    {
        public string ExtractPlan(DbCommand command)
        {
            command.CommandText = "EXPLAIN (ANALYZE, COSTS, VERBOSE, BUFFERS) " + command.CommandText;

            using var reader = command.ExecuteReader();
            var plan = string.Join(Environment.NewLine, reader.Cast<IDataRecord>().Select(r => r.GetString(0)));

            return plan;
        }
    }

    class SqlServerPlanExtractor : IPlanExtractor
    {
        public string ExtractPlan(DbCommand command)
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
    }
}
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
            return rawPlan;
        }
    }

    class SqlServerPlanConvertor : IPlanConvertor
    {
        public string ConvertPlanToHtml(string rawPlan)
        {
            return rawPlan;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QueryPlanVisualizer.LinqPad6
{
    public partial class QueryPlanUserControl : UserControl
    {
        public QueryPlanUserControl()
        {
            InitializeComponent();
        }

        internal DatabaseProvider DatabaseProvider { get; set; }
        internal IPlanConvertor PlanConvertor { get; set; }

        public void DisplayPlan(string rawPlan)
        {
            PlanConvertor.ConvertPlanToHtml(rawPlan);
        }
    }
}

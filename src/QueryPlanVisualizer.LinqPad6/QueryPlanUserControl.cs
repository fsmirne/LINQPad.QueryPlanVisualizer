using ExecutionPlanVisualizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace QueryPlanVisualizer.LinqPad6
{
    public partial class QueryPlanUserControl : UserControl
    {
        private string plan;
        private List<MissingIndexDetails> indexes;

        public QueryPlanUserControl()
        {
            InitializeComponent();

#if DEBUG
            webBrowser.IsWebBrowserContextMenuEnabled = true;
#endif
        }

        private void QueryPlanUserControlLoad(object sender, EventArgs e)
        {
            var assocQueryString = NativeMethods.AssocQueryString(NativeMethods.AssocStr.Executable, $".{DatabaseProvider.PlanExtension}");

            if (string.IsNullOrEmpty(assocQueryString))
            {
                openPlanButton.Visible = false;
            }
            else
            {
                var fileDescription = FileVersionInfo.GetVersionInfo(assocQueryString).FileDescription;
                openPlanButton.Text = $"Open with {fileDescription}";
            }

            sharePlanButton.Text = $"Share Plan on {DatabaseProvider.SharePlanWebsite}";
        }

        internal IPlanConvertor PlanConvertor { get; set; }
        internal DatabaseProvider DatabaseProvider { get; set; }

        public void DisplayPlan(string rawPlan)
        {
            plan = rawPlan;

            indexes = DatabaseProvider.GetMissingIndexes(rawPlan);
            webBrowser.DocumentText = PlanConvertor.ConvertPlanToHtml(rawPlan);

            if (indexes.Count > 0 && tabControl.TabPages.Count == 1)
            {
                tabControl.TabPages.Add(indexesTabPage);
            }

            if (indexes.Count == 0 && tabControl.TabPages.Count > 1)
            {
                tabControl.TabPages.Remove(indexesTabPage);
            }

            indexesTabPage.Text = $"{indexes.Count} Missing Index{(indexes.Count > 1 ? "es" : "")}";

            indexesDataGridView.DataSource = indexes;
            indexesDataGridView.ResetBindings();
        }

        private void OpenPlanButtonClick(object sender, EventArgs e)
        {
            var tempFile = Path.ChangeExtension(Path.GetTempFileName(), DatabaseProvider.PlanExtension);
            File.WriteAllText(tempFile, plan);

            try
            {
                Process.Start(new ProcessStartInfo(tempFile)
                {
                    UseShellExecute = true,
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Cannot open execution plan. {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePlanButtonClick(object sender, EventArgs e)
        {
            savePlanFileDialog.Filter = DatabaseProvider.PlanSaveDialogFilter;

            if (savePlanFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(savePlanFileDialog.FileName, plan);

                planLocationLinkLabel.Text = savePlanFileDialog.FileName;
                planSavedLabel.Visible = planLocationLinkLabel.Visible = true;
            }
        }

        private void PlanLocationLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", $"/select,\"{planLocationLinkLabel.Text}\"");
        }

        private async void SharePlanButtonClick(object sender, EventArgs e)
        {
            shareProgressBar.Visible = true;
            planLinkLinkLabel.Visible = planSharedLabel.Visible = false;
            try
            {
                planLinkLinkLabel.Text = await DatabaseProvider.SharePlanAsync(plan);

                planLinkLinkLabel.Visible = planSharedLabel.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error sharing plan: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                shareProgressBar.Visible = false;
            }
        }

        private void PlanLinkLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(planLinkLinkLabel.Text)
            {
                UseShellExecute = true
            });
        }
    }
}

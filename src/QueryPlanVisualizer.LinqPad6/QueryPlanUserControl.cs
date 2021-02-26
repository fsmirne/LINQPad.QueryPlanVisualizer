using ExecutionPlanVisualizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
            try
            {
                SetButtonImages();
            }
            catch
            {
                kofiLinkLabel.Visible = true;
                kofiButton.Visible = githubButton.Visible = false;
            }

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

        private void SetButtonImages()
        {
            var resources = new ComponentResourceManager(typeof(QueryPlanUserControl));

            kofiButton.Image = (Image) resources.GetObject("kofiButton.Image");
            githubButton.Image = (Image) resources.GetObject("githubButton.Image");
        }

        internal IPlanConvertor PlanConvertor { get; set; }
        internal DatabaseProvider DatabaseProvider { get; set; }

        private void StartProcess(string fileName)
        {
            Process.Start(new ProcessStartInfo(fileName)
            {
                UseShellExecute = true
            });
        }

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
                StartProcess(tempFile);
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
            planSharedLabel.Visible = true;
            planSharedLabel.Text = "Sharing your plan...";
            planLinkLinkLabel.Visible = false;

            try
            {
                planLinkLinkLabel.Text = await DatabaseProvider.SharePlanAsync(plan);

                planLinkLinkLabel.Visible = true;
                planSharedLabel.Text = "Plan Shared.";
            }
            catch (Exception exception)
            {
                planSharedLabel.Visible = false;
                MessageBox.Show($"Error sharing plan: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlanLinkLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartProcess(planLinkLinkLabel.Text);
        }

        private void GitHubLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartProcess("https://github.com/Giorgi/LINQPad.QueryPlanVisualizer/");
        }

        private void KofiLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartProcess("https://ko-fi.com/Giorgi");
        }

        private void KofiButtonClick(object sender, EventArgs e)
        {
            StartProcess("https://ko-fi.com/Giorgi");
        }
    }
}

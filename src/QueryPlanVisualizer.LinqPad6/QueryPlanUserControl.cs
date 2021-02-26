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

            kofiButton.Image = (Image)resources.GetObject("kofiButton.Image");
            githubButton.Image = (Image)resources.GetObject("githubButton.Image");
        }

        internal PlanProcessor PlanProcessor { get; set; }
        internal DatabaseProvider DatabaseProvider { get; set; }

        public void DisplayPlan(string rawPlan)
        {
            plan = rawPlan;

            indexes = DatabaseProvider.GetMissingIndexes(rawPlan);
            webBrowser.DocumentText = PlanProcessor.ConvertPlanToHtml(rawPlan);

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

        private void StartProcess(string fileName)
        {
            Process.Start(new ProcessStartInfo(fileName)
            {
                UseShellExecute = true
            });
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
            copyLinkLabel.Text = "Copy";
            planSharedLabel.Text = "Sharing your plan...";
            copyLinkLabel.Visible = planLinkLinkLabel.Visible = false;
            
            try
            {
                planLinkLinkLabel.Text = await PlanProcessor.SharePlanAsync(plan);

                copyLinkLabel.Visible = planLinkLinkLabel.Visible = true;
                planSharedLabel.Text = "Plan Shared.";
            }
            catch (Exception exception)
            {
                copyLinkLabel.Visible = planSharedLabel.Visible = false;
                MessageBox.Show($"Error sharing plan: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(planLinkLinkLabel.Text);
            copyLinkLabel.Text = "Copied!";
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

        private void IndexesDataGridViewDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //http://stackoverflow.com/a/10049887/239438
            for (int i = 0; i < indexesDataGridView.Columns.Count - 1; i++)
            {
                indexesDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            indexesDataGridView.Columns[indexesDataGridView.Columns.Count - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < indexesDataGridView.Columns.Count; i++)
            {
                int width = indexesDataGridView.Columns[i].Width;
                indexesDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                indexesDataGridView.Columns[i].Width = width;
            }
        }

        private async void IndexesDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //http://stackoverflow.com/a/13687844/239438
            if (!(indexesDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0)
            {
                return;
            }

            if (MessageBox.Show("Do you really want to create this index?", "Confirm", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            var script = indexes[e.RowIndex].Script;

            try
            {
                indexesDataGridView.Enabled = false;
                //progressBar.Visible = indexLabel.Visible = true;

                //await DatabaseHelper.CreateIndexAsync(script);

                //IndexCreated?.Invoke(sender, e);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Cannot create index. {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            indexesDataGridView.Enabled = true;
            //progressBar.Visible = indexLabel.Visible = false;
        }
    }
}

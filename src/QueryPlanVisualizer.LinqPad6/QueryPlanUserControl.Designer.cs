
namespace QueryPlanVisualizer.LinqPad6
{
    partial class QueryPlanUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryPlanUserControl));
            this.openPlanButton = new System.Windows.Forms.Button();
            this.savePlanButton = new System.Windows.Forms.Button();
            this.planSavedLabel = new System.Windows.Forms.Label();
            this.planLocationLinkLabel = new MyLinkLabel();
            this.indexProgressBar = new System.Windows.Forms.ProgressBar();
            this.indexLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainTabPage = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.indexesTabPage = new System.Windows.Forms.TabPage();
            this.indexesDataGridView = new System.Windows.Forms.DataGridView();
            this.impactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schemaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scriptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createIndexColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.missingIndexDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.savePlanFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sharePlanButton = new System.Windows.Forms.Button();
            this.planLinkLinkLabel = new MyLinkLabel();
            this.planSharedLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.githubLinkLabel = new MyLinkLabel();
            this.kofiButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.mainTabPage.SuspendLayout();
            this.indexesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingIndexDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openPlanButton
            // 
            this.openPlanButton.AutoSize = true;
            this.openPlanButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openPlanButton.Location = new System.Drawing.Point(2, 14);
            this.openPlanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openPlanButton.Name = "openPlanButton";
            this.openPlanButton.Size = new System.Drawing.Size(296, 30);
            this.openPlanButton.TabIndex = 0;
            this.openPlanButton.Text = "Open with Sql Server Management Studio";
            this.openPlanButton.UseVisualStyleBackColor = true;
            this.openPlanButton.Click += new System.EventHandler(this.OpenPlanButtonClick);
            // 
            // savePlanButton
            // 
            this.savePlanButton.Location = new System.Drawing.Point(400, 14);
            this.savePlanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savePlanButton.Name = "savePlanButton";
            this.savePlanButton.Size = new System.Drawing.Size(94, 30);
            this.savePlanButton.TabIndex = 1;
            this.savePlanButton.Text = "Save Plan";
            this.savePlanButton.UseVisualStyleBackColor = true;
            this.savePlanButton.Click += new System.EventHandler(this.SavePlanButtonClick);
            // 
            // planSavedLabel
            // 
            this.planSavedLabel.AutoSize = true;
            this.planSavedLabel.Location = new System.Drawing.Point(506, 19);
            this.planSavedLabel.Name = "planSavedLabel";
            this.planSavedLabel.Size = new System.Drawing.Size(100, 20);
            this.planSavedLabel.TabIndex = 2;
            this.planSavedLabel.Text = "Plan saved to:";
            this.planSavedLabel.Visible = false;
            // 
            // planLocationLinkLabel
            // 
            this.planLocationLinkLabel.AutoSize = true;
            this.planLocationLinkLabel.Location = new System.Drawing.Point(506, 43);
            this.planLocationLinkLabel.Name = "planLocationLinkLabel";
            this.planLocationLinkLabel.Size = new System.Drawing.Size(165, 20);
            this.planLocationLinkLabel.TabIndex = 3;
            this.planLocationLinkLabel.TabStop = true;
            this.planLocationLinkLabel.Text = "plan location goes here";
            this.planLocationLinkLabel.Visible = false;
            this.planLocationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlanLocationLinkLabelLinkClicked);
            // 
            // indexProgressBar
            // 
            this.indexProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexProgressBar.Location = new System.Drawing.Point(38, 540);
            this.indexProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indexProgressBar.Name = "indexProgressBar";
            this.indexProgressBar.Size = new System.Drawing.Size(189, 28);
            this.indexProgressBar.TabIndex = 4;
            this.indexProgressBar.Visible = false;
            // 
            // indexLabel
            // 
            this.indexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(254, 544);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(105, 20);
            this.indexLabel.TabIndex = 5;
            this.indexLabel.Text = "Creating index";
            this.indexLabel.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.mainTabPage);
            this.tabControl.Controls.Add(this.indexesTabPage);
            this.tabControl.Location = new System.Drawing.Point(0, 55);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1414, 720);
            this.tabControl.TabIndex = 6;
            // 
            // mainTabPage
            // 
            this.mainTabPage.Controls.Add(this.webBrowser);
            this.mainTabPage.Location = new System.Drawing.Point(4, 29);
            this.mainTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTabPage.Size = new System.Drawing.Size(1406, 687);
            this.mainTabPage.TabIndex = 0;
            this.mainTabPage.Text = "Query Execution Plan";
            this.mainTabPage.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(3, 2);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.webBrowser.MinimumSize = new System.Drawing.Size(27, 31);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1400, 683);
            this.webBrowser.TabIndex = 10;
            // 
            // indexesTabPage
            // 
            this.indexesTabPage.Controls.Add(this.indexesDataGridView);
            this.indexesTabPage.Controls.Add(this.indexProgressBar);
            this.indexesTabPage.Controls.Add(this.indexLabel);
            this.indexesTabPage.Location = new System.Drawing.Point(4, 29);
            this.indexesTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indexesTabPage.Name = "indexesTabPage";
            this.indexesTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indexesTabPage.Size = new System.Drawing.Size(1406, 687);
            this.indexesTabPage.TabIndex = 1;
            this.indexesTabPage.Text = "Missing Indexes";
            this.indexesTabPage.UseVisualStyleBackColor = true;
            // 
            // indexesDataGridView
            // 
            this.indexesDataGridView.AllowUserToDeleteRows = false;
            this.indexesDataGridView.AutoGenerateColumns = false;
            this.indexesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.indexesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.indexesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indexesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.impactDataGridViewTextBoxColumn,
            this.schemaDataGridViewTextBoxColumn,
            this.tableDataGridViewTextBoxColumn,
            this.scriptDataGridViewTextBoxColumn,
            this.createIndexColumn});
            this.indexesDataGridView.DataSource = this.missingIndexDetailsBindingSource;
            this.indexesDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.indexesDataGridView.Location = new System.Drawing.Point(3, 2);
            this.indexesDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.indexesDataGridView.Name = "indexesDataGridView";
            this.indexesDataGridView.ReadOnly = true;
            this.indexesDataGridView.RowHeadersWidth = 4;
            this.indexesDataGridView.Size = new System.Drawing.Size(1400, 396);
            this.indexesDataGridView.TabIndex = 1;
            // 
            // impactDataGridViewTextBoxColumn
            // 
            this.impactDataGridViewTextBoxColumn.DataPropertyName = "Impact";
            this.impactDataGridViewTextBoxColumn.FillWeight = 15F;
            this.impactDataGridViewTextBoxColumn.HeaderText = "Impact";
            this.impactDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.impactDataGridViewTextBoxColumn.Name = "impactDataGridViewTextBoxColumn";
            this.impactDataGridViewTextBoxColumn.ReadOnly = true;
            this.impactDataGridViewTextBoxColumn.Width = 84;
            // 
            // schemaDataGridViewTextBoxColumn
            // 
            this.schemaDataGridViewTextBoxColumn.DataPropertyName = "Schema";
            this.schemaDataGridViewTextBoxColumn.FillWeight = 15F;
            this.schemaDataGridViewTextBoxColumn.HeaderText = "Schema";
            this.schemaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.schemaDataGridViewTextBoxColumn.Name = "schemaDataGridViewTextBoxColumn";
            this.schemaDataGridViewTextBoxColumn.ReadOnly = true;
            this.schemaDataGridViewTextBoxColumn.Width = 90;
            // 
            // tableDataGridViewTextBoxColumn
            // 
            this.tableDataGridViewTextBoxColumn.DataPropertyName = "Table";
            this.tableDataGridViewTextBoxColumn.FillWeight = 25F;
            this.tableDataGridViewTextBoxColumn.HeaderText = "Table";
            this.tableDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tableDataGridViewTextBoxColumn.Name = "tableDataGridViewTextBoxColumn";
            this.tableDataGridViewTextBoxColumn.ReadOnly = true;
            this.tableDataGridViewTextBoxColumn.Width = 73;
            // 
            // scriptDataGridViewTextBoxColumn
            // 
            this.scriptDataGridViewTextBoxColumn.DataPropertyName = "Script";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scriptDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.scriptDataGridViewTextBoxColumn.FillWeight = 50F;
            this.scriptDataGridViewTextBoxColumn.HeaderText = "Script";
            this.scriptDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.scriptDataGridViewTextBoxColumn.Name = "scriptDataGridViewTextBoxColumn";
            this.scriptDataGridViewTextBoxColumn.ReadOnly = true;
            this.scriptDataGridViewTextBoxColumn.Width = 76;
            // 
            // createIndexColumn
            // 
            this.createIndexColumn.FillWeight = 20F;
            this.createIndexColumn.HeaderText = "";
            this.createIndexColumn.MinimumWidth = 100;
            this.createIndexColumn.Name = "createIndexColumn";
            this.createIndexColumn.ReadOnly = true;
            this.createIndexColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.createIndexColumn.Text = "Create Index";
            this.createIndexColumn.UseColumnTextForButtonValue = true;
            // 
            // missingIndexDetailsBindingSource
            // 
            this.missingIndexDetailsBindingSource.DataSource = typeof(ExecutionPlanVisualizer.MissingIndexDetails);
            // 
            // savePlanFileDialog
            // 
            this.savePlanFileDialog.Filter = "Execution Plan Files|*.sqlplan";
            this.savePlanFileDialog.RestoreDirectory = true;
            // 
            // sharePlanButton
            // 
            this.sharePlanButton.Location = new System.Drawing.Point(824, 4);
            this.sharePlanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sharePlanButton.Name = "sharePlanButton";
            this.sharePlanButton.Size = new System.Drawing.Size(209, 74);
            this.sharePlanButton.TabIndex = 7;
            this.sharePlanButton.Text = "Share Plan on https://www.brentozar.com/pastetheplan/";
            this.sharePlanButton.UseVisualStyleBackColor = true;
            this.sharePlanButton.Click += new System.EventHandler(this.SharePlanButtonClick);
            // 
            // planLinkLinkLabel
            // 
            this.planLinkLinkLabel.AutoSize = true;
            this.planLinkLinkLabel.Location = new System.Drawing.Point(1040, 43);
            this.planLinkLinkLabel.Name = "planLinkLinkLabel";
            this.planLinkLinkLabel.Size = new System.Drawing.Size(165, 20);
            this.planLinkLinkLabel.TabIndex = 8;
            this.planLinkLinkLabel.TabStop = true;
            this.planLinkLinkLabel.Text = "plan location goes here";
            this.planLinkLinkLabel.Visible = false;
            this.planLinkLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlanLinkLinkLabelLinkClicked);
            // 
            // planSharedLabel
            // 
            this.planSharedLabel.AutoSize = true;
            this.planSharedLabel.Location = new System.Drawing.Point(1040, 14);
            this.planSharedLabel.Name = "planSharedLabel";
            this.planSharedLabel.Size = new System.Drawing.Size(67, 20);
            this.planSharedLabel.TabIndex = 9;
            this.planSharedLabel.Text = "Plan link:";
            this.planSharedLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(7, 777);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 44);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(57, 789);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(160, 20);
            this.githubLinkLabel.TabIndex = 12;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "View Project on GitHub";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabelLinkClicked);
            // 
            // kofiButton
            // 
            this.kofiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kofiButton.BackColor = System.Drawing.Color.Transparent;
            this.kofiButton.Image = ((System.Drawing.Image)(resources.GetObject("kofiButton.Image")));
            this.kofiButton.Location = new System.Drawing.Point(235, 777);
            this.kofiButton.Name = "kofiButton";
            this.kofiButton.Size = new System.Drawing.Size(183, 44);
            this.kofiButton.TabIndex = 13;
            this.kofiButton.UseVisualStyleBackColor = false;
            this.kofiButton.Click += new System.EventHandler(this.KofiButtonClick);
            // 
            // QueryPlanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kofiButton);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.planSharedLabel);
            this.Controls.Add(this.planLocationLinkLabel);
            this.Controls.Add(this.planLinkLinkLabel);
            this.Controls.Add(this.sharePlanButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.planSavedLabel);
            this.Controls.Add(this.savePlanButton);
            this.Controls.Add(this.openPlanButton);
            this.Location = new System.Drawing.Point(327, 10);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QueryPlanUserControl";
            this.Size = new System.Drawing.Size(1423, 822);
            this.Load += new System.EventHandler(this.QueryPlanUserControlLoad);
            this.tabControl.ResumeLayout(false);
            this.mainTabPage.ResumeLayout(false);
            this.indexesTabPage.ResumeLayout(false);
            this.indexesTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingIndexDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openPlanButton;
        private System.Windows.Forms.Button savePlanButton;
        private System.Windows.Forms.Label planSavedLabel;
        private MyLinkLabel planLocationLinkLabel;
        private System.Windows.Forms.ProgressBar indexProgressBar;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mainTabPage;
        private System.Windows.Forms.TabPage indexesTabPage;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.SaveFileDialog savePlanFileDialog;
        private System.Windows.Forms.BindingSource missingIndexDetailsBindingSource;
        private System.Windows.Forms.DataGridView indexesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn impactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schemaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn createIndexColumn;
        private System.Windows.Forms.Button sharePlanButton;
        private MyLinkLabel planLinkLinkLabel;
        private System.Windows.Forms.Label planSharedLabel;
        private System.Windows.Forms.Button button1;
        private MyLinkLabel githubLinkLabel;
        private System.Windows.Forms.Button kofiButton;
    }
}

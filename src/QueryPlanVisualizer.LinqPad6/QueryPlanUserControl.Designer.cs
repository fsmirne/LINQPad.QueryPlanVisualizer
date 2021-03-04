namespace ExecutionPlanVisualizer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openPlanButton = new System.Windows.Forms.Button();
            this.savePlanButton = new System.Windows.Forms.Button();
            this.planSavedLabel = new System.Windows.Forms.Label();
            this.planLocationLinkLabel = new ExecutionPlanVisualizer.MyLinkLabel();
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
            this.planLinkLinkLabel = new ExecutionPlanVisualizer.MyLinkLabel();
            this.planSharedLabel = new System.Windows.Forms.Label();
            this.githubButton = new System.Windows.Forms.Button();
            this.githubLinkLabel = new ExecutionPlanVisualizer.MyLinkLabel();
            this.kofiButton = new System.Windows.Forms.Button();
            this.kofiLinkLabel = new ExecutionPlanVisualizer.MyLinkLabel();
            this.copyLinkLabel = new ExecutionPlanVisualizer.MyLinkLabel();
            this.indexProgressBar = new System.Windows.Forms.ProgressBar();
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
            this.planLocationLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.planLocationLinkLabel.AutoSize = true;
            this.planLocationLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.planLocationLinkLabel.Location = new System.Drawing.Point(506, 43);
            this.planLocationLinkLabel.Name = "planLocationLinkLabel";
            this.planLocationLinkLabel.Size = new System.Drawing.Size(165, 20);
            this.planLocationLinkLabel.TabIndex = 3;
            this.planLocationLinkLabel.TabStop = true;
            this.planLocationLinkLabel.Text = "plan location goes here";
            this.planLocationLinkLabel.Visible = false;
            this.planLocationLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.planLocationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PlanLocationLinkLabelLinkClicked);
            // 
            // indexLabel
            // 
            this.indexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(12, 592);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(114, 20);
            this.indexLabel.TabIndex = 5;
            this.indexLabel.Text = "Creating index...";
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
            this.indexesTabPage.Controls.Add(this.indexLabel);
            this.indexesTabPage.Controls.Add(this.indexesDataGridView);
            this.indexesTabPage.Controls.Add(this.indexProgressBar);
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
            this.indexesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IndexesDataGridViewCellContentClick);
            this.indexesDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.IndexesDataGridViewDataBindingComplete);
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
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.scriptDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.sharePlanButton.Text = "Visualize and Share Plan on https://www.brentozar.com/pastetheplan/";
            this.sharePlanButton.UseVisualStyleBackColor = true;
            this.sharePlanButton.Click += new System.EventHandler(this.SharePlanButtonClick);
            // 
            // planLinkLinkLabel
            // 
            this.planLinkLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.planLinkLinkLabel.AutoSize = true;
            this.planLinkLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.planLinkLinkLabel.Location = new System.Drawing.Point(1040, 43);
            this.planLinkLinkLabel.Name = "planLinkLinkLabel";
            this.planLinkLinkLabel.Size = new System.Drawing.Size(165, 20);
            this.planLinkLinkLabel.TabIndex = 8;
            this.planLinkLinkLabel.TabStop = true;
            this.planLinkLinkLabel.Text = "plan location goes here";
            this.planLinkLinkLabel.Visible = false;
            this.planLinkLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
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
            // githubButton
            // 
            this.githubButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.githubButton.FlatAppearance.BorderSize = 0;
            this.githubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.githubButton.Location = new System.Drawing.Point(7, 777);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(44, 44);
            this.githubButton.TabIndex = 11;
            this.githubButton.UseVisualStyleBackColor = true;
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.githubLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.githubLinkLabel.Location = new System.Drawing.Point(57, 789);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(163, 20);
            this.githubLinkLabel.TabIndex = 12;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "View Project on GitHub";
            this.githubLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabelLinkClicked);
            // 
            // kofiButton
            // 
            this.kofiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kofiButton.BackColor = System.Drawing.Color.Transparent;
            this.kofiButton.Location = new System.Drawing.Point(235, 777);
            this.kofiButton.Name = "kofiButton";
            this.kofiButton.Size = new System.Drawing.Size(183, 44);
            this.kofiButton.TabIndex = 13;
            this.kofiButton.UseVisualStyleBackColor = false;
            this.kofiButton.Click += new System.EventHandler(this.KofiButtonClick);
            // 
            // kofiLinkLabel
            // 
            this.kofiLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kofiLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kofiLinkLabel.AutoSize = true;
            this.kofiLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.kofiLinkLabel.Location = new System.Drawing.Point(244, 789);
            this.kofiLinkLabel.Name = "kofiLinkLabel";
            this.kofiLinkLabel.Size = new System.Drawing.Size(145, 20);
            this.kofiLinkLabel.TabIndex = 14;
            this.kofiLinkLabel.TabStop = true;
            this.kofiLinkLabel.Text = "Support me on Ko-fi";
            this.kofiLinkLabel.Visible = false;
            this.kofiLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.kofiLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.KofiLinkLabelLinkClicked);
            // 
            // copyLinkLabel
            // 
            this.copyLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.copyLinkLabel.AutoSize = true;
            this.copyLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.copyLinkLabel.Location = new System.Drawing.Point(1126, 13);
            this.copyLinkLabel.Name = "copyLinkLabel";
            this.copyLinkLabel.Size = new System.Drawing.Size(43, 20);
            this.copyLinkLabel.TabIndex = 15;
            this.copyLinkLabel.TabStop = true;
            this.copyLinkLabel.Text = "Copy";
            this.copyLinkLabel.Visible = false;
            this.copyLinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.copyLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CopyLinkLabelLinkClicked);
            // 
            // indexProgressBar
            // 
            this.indexProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.indexProgressBar.Location = new System.Drawing.Point(12, 641);
            this.indexProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indexProgressBar.Name = "indexProgressBar";
            this.indexProgressBar.Size = new System.Drawing.Size(189, 28);
            this.indexProgressBar.TabIndex = 4;
            this.indexProgressBar.Visible = false;
            // 
            // QueryPlanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.copyLinkLabel);
            this.Controls.Add(this.kofiLinkLabel);
            this.Controls.Add(this.kofiButton);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.githubButton);
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
        private System.Windows.Forms.Button githubButton;
        private MyLinkLabel githubLinkLabel;
        private System.Windows.Forms.Button kofiButton;
        private MyLinkLabel kofiLinkLabel;
        private MyLinkLabel copyLinkLabel;
        private System.Windows.Forms.ProgressBar indexProgressBar;
    }
}

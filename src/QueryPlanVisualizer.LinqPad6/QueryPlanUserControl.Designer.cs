
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
            this.openPlanButton = new System.Windows.Forms.Button();
            this.savePlanButton = new System.Windows.Forms.Button();
            this.planSavedLabel = new System.Windows.Forms.Label();
            this.planLocationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.tabControl1.SuspendLayout();
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
            this.openPlanButton.Location = new System.Drawing.Point(9, 11);
            this.openPlanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openPlanButton.Name = "openPlanButton";
            this.openPlanButton.Size = new System.Drawing.Size(296, 30);
            this.openPlanButton.TabIndex = 0;
            this.openPlanButton.Text = "Open with Sql Server Management Studio";
            this.openPlanButton.UseVisualStyleBackColor = true;
            // 
            // savePlanButton
            // 
            this.savePlanButton.Location = new System.Drawing.Point(329, 12);
            this.savePlanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savePlanButton.Name = "savePlanButton";
            this.savePlanButton.Size = new System.Drawing.Size(94, 29);
            this.savePlanButton.TabIndex = 1;
            this.savePlanButton.Text = "Save Plan";
            this.savePlanButton.UseVisualStyleBackColor = true;
            // 
            // planSavedLabel
            // 
            this.planSavedLabel.AutoSize = true;
            this.planSavedLabel.Location = new System.Drawing.Point(449, 16);
            this.planSavedLabel.Name = "planSavedLabel";
            this.planSavedLabel.Size = new System.Drawing.Size(100, 20);
            this.planSavedLabel.TabIndex = 2;
            this.planSavedLabel.Text = "Plan saved to:";
            this.planSavedLabel.Visible = false;
            // 
            // planLocationLinkLabel
            // 
            this.planLocationLinkLabel.AutoSize = true;
            this.planLocationLinkLabel.Location = new System.Drawing.Point(554, 16);
            this.planLocationLinkLabel.Name = "planLocationLinkLabel";
            this.planLocationLinkLabel.Size = new System.Drawing.Size(165, 20);
            this.planLocationLinkLabel.TabIndex = 3;
            this.planLocationLinkLabel.TabStop = true;
            this.planLocationLinkLabel.Text = "plan location goes here";
            this.planLocationLinkLabel.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(739, 12);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(189, 28);
            this.progressBar1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Creating index";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.mainTabPage);
            this.tabControl1.Controls.Add(this.indexesTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 55);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1142, 735);
            this.tabControl1.TabIndex = 6;
            // 
            // mainTabPage
            // 
            this.mainTabPage.Controls.Add(this.webBrowser);
            this.mainTabPage.Location = new System.Drawing.Point(4, 29);
            this.mainTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTabPage.Name = "mainTabPage";
            this.mainTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainTabPage.Size = new System.Drawing.Size(1134, 702);
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
            this.webBrowser.Size = new System.Drawing.Size(1128, 698);
            this.webBrowser.TabIndex = 10;
            // 
            // indexesTabPage
            // 
            this.indexesTabPage.Controls.Add(this.indexesDataGridView);
            this.indexesTabPage.Location = new System.Drawing.Point(4, 29);
            this.indexesTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indexesTabPage.Name = "indexesTabPage";
            this.indexesTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.indexesTabPage.Size = new System.Drawing.Size(1134, 702);
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
            this.indexesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexesDataGridView.Location = new System.Drawing.Point(3, 2);
            this.indexesDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.indexesDataGridView.Name = "indexesDataGridView";
            this.indexesDataGridView.ReadOnly = true;
            this.indexesDataGridView.RowHeadersWidth = 4;
            this.indexesDataGridView.Size = new System.Drawing.Size(1128, 698);
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
            // QueryPlanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.planLocationLinkLabel);
            this.Controls.Add(this.planSavedLabel);
            this.Controls.Add(this.savePlanButton);
            this.Controls.Add(this.openPlanButton);
            this.Location = new System.Drawing.Point(327, 10);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QueryPlanUserControl";
            this.Size = new System.Drawing.Size(1151, 814);
            this.tabControl1.ResumeLayout(false);
            this.mainTabPage.ResumeLayout(false);
            this.indexesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.indexesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.missingIndexDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openPlanButton;
        private System.Windows.Forms.Button savePlanButton;
        private System.Windows.Forms.Label planSavedLabel;
        private System.Windows.Forms.LinkLabel planLocationLinkLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
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
    }
}

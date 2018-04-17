namespace ExcelCompare
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CompareBtn = new MetroFramework.Controls.MetroButton();
            this.genSpreadcBox = new MetroFramework.Controls.MetroCheckBox();
            this.openSpeadcBox = new MetroFramework.Controls.MetroCheckBox();
            this.sheetController = new MetroFramework.Controls.MetroTabControl();
            this.mergedViewTab = new MetroFramework.Controls.MetroTabPage();
            this.MergedViewGrid = new System.Windows.Forms.DataGridView();
            this.sideBySide = new MetroFramework.Controls.MetroTabPage();
            this.TableSplitter = new System.Windows.Forms.SplitContainer();
            this.SideBySideGrid1 = new System.Windows.Forms.DataGridView();
            this.SideBySideGrid2 = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.openFileControl2 = new ExcelCompare.OpenFileControl();
            this.openFileControl1 = new ExcelCompare.OpenFileControl();
            this.docTwoSheetsList = new System.Windows.Forms.ListBox();
            this.docOneSheetsList = new System.Windows.Forms.ListBox();
            this.sheetController.SuspendLayout();
            this.mergedViewTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MergedViewGrid)).BeginInit();
            this.sideBySide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableSplitter)).BeginInit();
            this.TableSplitter.Panel1.SuspendLayout();
            this.TableSplitter.Panel2.SuspendLayout();
            this.TableSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SideBySideGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBySideGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // CompareBtn
            // 
            this.CompareBtn.Enabled = false;
            this.CompareBtn.Location = new System.Drawing.Point(1178, 105);
            this.CompareBtn.Name = "CompareBtn";
            this.CompareBtn.Size = new System.Drawing.Size(75, 23);
            this.CompareBtn.TabIndex = 2;
            this.CompareBtn.Text = "Compare";
            this.CompareBtn.UseSelectable = true;
            this.CompareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // genSpreadcBox
            // 
            this.genSpreadcBox.AutoSize = true;
            this.genSpreadcBox.Location = new System.Drawing.Point(1109, 65);
            this.genSpreadcBox.Name = "genSpreadcBox";
            this.genSpreadcBox.Size = new System.Drawing.Size(137, 15);
            this.genSpreadcBox.TabIndex = 4;
            this.genSpreadcBox.Text = "Generate Spreadsheet";
            this.genSpreadcBox.UseSelectable = true;
            this.genSpreadcBox.CheckedChanged += new System.EventHandler(this.genSpreadcBox_CheckedChanged);
            // 
            // openSpeadcBox
            // 
            this.openSpeadcBox.AutoSize = true;
            this.openSpeadcBox.Enabled = false;
            this.openSpeadcBox.Location = new System.Drawing.Point(1109, 84);
            this.openSpeadcBox.Name = "openSpeadcBox";
            this.openSpeadcBox.Size = new System.Drawing.Size(119, 15);
            this.openSpeadcBox.TabIndex = 5;
            this.openSpeadcBox.Text = "Open Spreadsheet";
            this.openSpeadcBox.UseSelectable = true;
            // 
            // sheetController
            // 
            this.sheetController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetController.Controls.Add(this.mergedViewTab);
            this.sheetController.Controls.Add(this.sideBySide);
            this.sheetController.Location = new System.Drawing.Point(23, 134);
            this.sheetController.Name = "sheetController";
            this.sheetController.SelectedIndex = 0;
            this.sheetController.Size = new System.Drawing.Size(1234, 643);
            this.sheetController.TabIndex = 6;
            this.sheetController.UseSelectable = true;
            this.sheetController.SelectedIndexChanged += new System.EventHandler(this.sheetController_SelectedIndexChanged);
            // 
            // mergedViewTab
            // 
            this.mergedViewTab.Controls.Add(this.MergedViewGrid);
            this.mergedViewTab.HorizontalScrollbarBarColor = true;
            this.mergedViewTab.HorizontalScrollbarHighlightOnWheel = false;
            this.mergedViewTab.HorizontalScrollbarSize = 10;
            this.mergedViewTab.Location = new System.Drawing.Point(4, 38);
            this.mergedViewTab.Name = "mergedViewTab";
            this.mergedViewTab.Size = new System.Drawing.Size(1226, 601);
            this.mergedViewTab.TabIndex = 0;
            this.mergedViewTab.Text = "Merged View";
            this.mergedViewTab.VerticalScrollbarBarColor = true;
            this.mergedViewTab.VerticalScrollbarHighlightOnWheel = false;
            this.mergedViewTab.VerticalScrollbarSize = 10;
            // 
            // MergedViewGrid
            // 
            this.MergedViewGrid.AllowUserToAddRows = false;
            this.MergedViewGrid.AllowUserToDeleteRows = false;
            this.MergedViewGrid.AllowUserToResizeRows = false;
            this.MergedViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MergedViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MergedViewGrid.BackgroundColor = System.Drawing.Color.White;
            this.MergedViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MergedViewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MergedViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.MergedViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MergedViewGrid.GridColor = System.Drawing.Color.White;
            this.MergedViewGrid.Location = new System.Drawing.Point(3, 3);
            this.MergedViewGrid.Name = "MergedViewGrid";
            this.MergedViewGrid.ReadOnly = true;
            this.MergedViewGrid.RowHeadersVisible = false;
            this.MergedViewGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.MergedViewGrid.Size = new System.Drawing.Size(1220, 598);
            this.MergedViewGrid.TabIndex = 5;
            // 
            // sideBySide
            // 
            this.sideBySide.Controls.Add(this.TableSplitter);
            this.sideBySide.HorizontalScrollbarBarColor = true;
            this.sideBySide.HorizontalScrollbarHighlightOnWheel = false;
            this.sideBySide.HorizontalScrollbarSize = 10;
            this.sideBySide.Location = new System.Drawing.Point(4, 38);
            this.sideBySide.Name = "sideBySide";
            this.sideBySide.Size = new System.Drawing.Size(1226, 601);
            this.sideBySide.TabIndex = 1;
            this.sideBySide.Text = "Side by side";
            this.sideBySide.VerticalScrollbarBarColor = true;
            this.sideBySide.VerticalScrollbarHighlightOnWheel = false;
            this.sideBySide.VerticalScrollbarSize = 10;
            // 
            // TableSplitter
            // 
            this.TableSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableSplitter.Location = new System.Drawing.Point(3, 3);
            this.TableSplitter.Name = "TableSplitter";
            // 
            // TableSplitter.Panel1
            // 
            this.TableSplitter.Panel1.Controls.Add(this.SideBySideGrid1);
            // 
            // TableSplitter.Panel2
            // 
            this.TableSplitter.Panel2.Controls.Add(this.SideBySideGrid2);
            this.TableSplitter.Size = new System.Drawing.Size(1220, 598);
            this.TableSplitter.SplitterDistance = 608;
            this.TableSplitter.TabIndex = 2;
            // 
            // SideBySideGrid1
            // 
            this.SideBySideGrid1.AllowUserToAddRows = false;
            this.SideBySideGrid1.AllowUserToDeleteRows = false;
            this.SideBySideGrid1.AllowUserToResizeRows = false;
            this.SideBySideGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SideBySideGrid1.BackgroundColor = System.Drawing.Color.White;
            this.SideBySideGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SideBySideGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SideBySideGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.SideBySideGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SideBySideGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideBySideGrid1.GridColor = System.Drawing.Color.White;
            this.SideBySideGrid1.Location = new System.Drawing.Point(0, 0);
            this.SideBySideGrid1.Name = "SideBySideGrid1";
            this.SideBySideGrid1.ReadOnly = true;
            this.SideBySideGrid1.RowHeadersVisible = false;
            this.SideBySideGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SideBySideGrid1.Size = new System.Drawing.Size(608, 598);
            this.SideBySideGrid1.TabIndex = 0;
            this.SideBySideGrid1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
            this.SideBySideGrid1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SideBySideGrid1_Scroll);
            // 
            // SideBySideGrid2
            // 
            this.SideBySideGrid2.AllowUserToAddRows = false;
            this.SideBySideGrid2.AllowUserToDeleteRows = false;
            this.SideBySideGrid2.AllowUserToResizeRows = false;
            this.SideBySideGrid2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SideBySideGrid2.BackgroundColor = System.Drawing.Color.White;
            this.SideBySideGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SideBySideGrid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SideBySideGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.SideBySideGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SideBySideGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideBySideGrid2.GridColor = System.Drawing.Color.White;
            this.SideBySideGrid2.Location = new System.Drawing.Point(0, 0);
            this.SideBySideGrid2.Name = "SideBySideGrid2";
            this.SideBySideGrid2.ReadOnly = true;
            this.SideBySideGrid2.RowHeadersVisible = false;
            this.SideBySideGrid2.Size = new System.Drawing.Size(608, 598);
            this.SideBySideGrid2.TabIndex = 0;
            this.SideBySideGrid2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SideBySideGrid2_Scroll);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(665, 65);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(25, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "To:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(472, 65);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(68, 19);
            this.metroLabel2.TabIndex = 11;
            this.metroLabel2.Text = "Compare:";
            // 
            // openFileControl2
            // 
            this.openFileControl2.Location = new System.Drawing.Point(23, 99);
            this.openFileControl2.Name = "openFileControl2";
            this.openFileControl2.Size = new System.Drawing.Size(427, 29);
            this.openFileControl2.TabIndex = 1;
            this.openFileControl2.Title = "To:";
            this.openFileControl2.UseSelectable = true;
            // 
            // openFileControl1
            // 
            this.openFileControl1.Location = new System.Drawing.Point(23, 64);
            this.openFileControl1.Name = "openFileControl1";
            this.openFileControl1.Size = new System.Drawing.Size(427, 29);
            this.openFileControl1.TabIndex = 0;
            this.openFileControl1.Title = "Compare:";
            this.openFileControl1.UseSelectable = true;
            // 
            // docTwoSheetsList
            // 
            this.docTwoSheetsList.Enabled = false;
            this.docTwoSheetsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.docTwoSheetsList.FormattingEnabled = true;
            this.docTwoSheetsList.ItemHeight = 18;
            this.docTwoSheetsList.Location = new System.Drawing.Point(696, 65);
            this.docTwoSheetsList.Name = "docTwoSheetsList";
            this.docTwoSheetsList.Size = new System.Drawing.Size(100, 58);
            this.docTwoSheetsList.TabIndex = 15;
            this.docTwoSheetsList.SelectedIndexChanged += new System.EventHandler(this.docTwoSheetsList_SelectedIndexChanged);
            // 
            // docOneSheetsList
            // 
            this.docOneSheetsList.Enabled = false;
            this.docOneSheetsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.docOneSheetsList.FormattingEnabled = true;
            this.docOneSheetsList.ItemHeight = 18;
            this.docOneSheetsList.Location = new System.Drawing.Point(546, 65);
            this.docOneSheetsList.Name = "docOneSheetsList";
            this.docOneSheetsList.Size = new System.Drawing.Size(100, 58);
            this.docOneSheetsList.TabIndex = 14;
            this.docOneSheetsList.SelectedIndexChanged += new System.EventHandler(this.docOneSheetsList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.docTwoSheetsList);
            this.Controls.Add(this.docOneSheetsList);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.sheetController);
            this.Controls.Add(this.openSpeadcBox);
            this.Controls.Add(this.genSpreadcBox);
            this.Controls.Add(this.CompareBtn);
            this.Controls.Add(this.openFileControl2);
            this.Controls.Add(this.openFileControl1);
            this.Name = "MainForm";
            this.Text = "Filter";
            this.sheetController.ResumeLayout(false);
            this.mergedViewTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MergedViewGrid)).EndInit();
            this.sideBySide.ResumeLayout(false);
            this.TableSplitter.Panel1.ResumeLayout(false);
            this.TableSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableSplitter)).EndInit();
            this.TableSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SideBySideGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SideBySideGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton CompareBtn;
        private MetroFramework.Controls.MetroCheckBox genSpreadcBox;
        private MetroFramework.Controls.MetroCheckBox openSpeadcBox;
        private MetroFramework.Controls.MetroTabControl sheetController;
        private MetroFramework.Controls.MetroTabPage mergedViewTab;
        private MetroFramework.Controls.MetroTabPage sideBySide;
        private System.Windows.Forms.SplitContainer TableSplitter;
        private System.Windows.Forms.DataGridView SideBySideGrid1;
        private System.Windows.Forms.DataGridView SideBySideGrid2;
        private System.Windows.Forms.DataGridView MergedViewGrid;
        private OpenFileControl openFileControl2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private OpenFileControl openFileControl1;
        private System.Windows.Forms.ListBox docTwoSheetsList;
        private System.Windows.Forms.ListBox docOneSheetsList;
    }
}
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.coSheetsCb = new MetroFramework.Controls.MetroComboBox();
            this.toSheetsCb = new MetroFramework.Controls.MetroComboBox();
            this.sortModeCb = new MetroFramework.Controls.MetroComboBox();
            this.ToolTips = new MetroFramework.Components.MetroToolTip();
            this.ModeLbl = new MetroFramework.Controls.MetroLabel();
            this.idLbl = new MetroFramework.Controls.MetroLabel();
            this.uniqueIdColCb = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.openFileControl1 = new ExcelCompare.OpenFileControl();
            this.openFileControl2 = new ExcelCompare.OpenFileControl();
            this.hasHeader = new MetroFramework.Controls.MetroCheckBox();
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
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompareBtn
            // 
            this.CompareBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareBtn.Enabled = false;
            this.CompareBtn.Location = new System.Drawing.Point(1182, 137);
            this.CompareBtn.Name = "CompareBtn";
            this.CompareBtn.Size = new System.Drawing.Size(75, 23);
            this.CompareBtn.TabIndex = 2;
            this.CompareBtn.Text = "Compare";
            this.CompareBtn.UseSelectable = true;
            this.CompareBtn.Click += new System.EventHandler(this.CompareBtn_Click);
            // 
            // genSpreadcBox
            // 
            this.genSpreadcBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.genSpreadcBox.AutoSize = true;
            this.genSpreadcBox.Location = new System.Drawing.Point(3, 30);
            this.genSpreadcBox.Name = "genSpreadcBox";
            this.genSpreadcBox.Size = new System.Drawing.Size(137, 15);
            this.genSpreadcBox.TabIndex = 4;
            this.genSpreadcBox.Text = "Generate Spreadsheet";
            this.genSpreadcBox.UseSelectable = true;
            this.genSpreadcBox.CheckedChanged += new System.EventHandler(this.genSpreadcBox_CheckedChanged);
            // 
            // openSpeadcBox
            // 
            this.openSpeadcBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSpeadcBox.AutoSize = true;
            this.openSpeadcBox.Enabled = false;
            this.openSpeadcBox.Location = new System.Drawing.Point(3, 51);
            this.openSpeadcBox.Name = "openSpeadcBox";
            this.openSpeadcBox.Size = new System.Drawing.Size(119, 15);
            this.openSpeadcBox.TabIndex = 5;
            this.openSpeadcBox.Text = "Open Spreadsheet";
            this.openSpeadcBox.UseSelectable = true;
            this.openSpeadcBox.CheckedChanged += new System.EventHandler(this.openSpeadcBox_CheckedChanged);
            // 
            // sheetController
            // 
            this.sheetController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetController.Controls.Add(this.mergedViewTab);
            this.sheetController.Controls.Add(this.sideBySide);
            this.sheetController.Location = new System.Drawing.Point(23, 166);
            this.sheetController.Name = "sheetController";
            this.sheetController.SelectedIndex = 1;
            this.sheetController.Size = new System.Drawing.Size(1234, 611);
            this.sheetController.Style = MetroFramework.MetroColorStyle.Green;
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
            this.mergedViewTab.Size = new System.Drawing.Size(1226, 569);
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
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MergedViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.MergedViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MergedViewGrid.GridColor = System.Drawing.Color.White;
            this.MergedViewGrid.Location = new System.Drawing.Point(3, 3);
            this.MergedViewGrid.Name = "MergedViewGrid";
            this.MergedViewGrid.ReadOnly = true;
            this.MergedViewGrid.RowHeadersVisible = false;
            this.MergedViewGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.MergedViewGrid.Size = new System.Drawing.Size(1220, 566);
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
            this.sideBySide.Size = new System.Drawing.Size(1226, 569);
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
            this.TableSplitter.Size = new System.Drawing.Size(1220, 566);
            this.TableSplitter.SplitterDistance = 614;
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
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SideBySideGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.SideBySideGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SideBySideGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideBySideGrid1.GridColor = System.Drawing.Color.White;
            this.SideBySideGrid1.Location = new System.Drawing.Point(0, 0);
            this.SideBySideGrid1.Name = "SideBySideGrid1";
            this.SideBySideGrid1.ReadOnly = true;
            this.SideBySideGrid1.RowHeadersVisible = false;
            this.SideBySideGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SideBySideGrid1.Size = new System.Drawing.Size(614, 566);
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
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SideBySideGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.SideBySideGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SideBySideGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SideBySideGrid2.GridColor = System.Drawing.Color.White;
            this.SideBySideGrid2.Location = new System.Drawing.Point(0, 0);
            this.SideBySideGrid2.Name = "SideBySideGrid2";
            this.SideBySideGrid2.ReadOnly = true;
            this.SideBySideGrid2.RowHeadersVisible = false;
            this.SideBySideGrid2.Size = new System.Drawing.Size(602, 566);
            this.SideBySideGrid2.TabIndex = 0;
            this.SideBySideGrid2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SideBySideGrid2_Scroll);
            // 
            // coSheetsCb
            // 
            this.coSheetsCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.coSheetsCb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.coSheetsCb.FormattingEnabled = true;
            this.coSheetsCb.ItemHeight = 19;
            this.coSheetsCb.Location = new System.Drawing.Point(59, 27);
            this.coSheetsCb.Name = "coSheetsCb";
            this.coSheetsCb.Size = new System.Drawing.Size(121, 25);
            this.coSheetsCb.TabIndex = 12;
            this.ToolTips.SetToolTip(this.coSheetsCb, "Select Table from the older document (Compare)");
            this.coSheetsCb.UseSelectable = true;
            this.coSheetsCb.SelectedValueChanged += new System.EventHandler(this.coSheetsCb_SelectedIndexChanged);
            // 
            // toSheetsCb
            // 
            this.toSheetsCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.toSheetsCb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toSheetsCb.FormattingEnabled = true;
            this.toSheetsCb.ItemHeight = 19;
            this.toSheetsCb.Location = new System.Drawing.Point(59, 62);
            this.toSheetsCb.Name = "toSheetsCb";
            this.toSheetsCb.Size = new System.Drawing.Size(121, 25);
            this.toSheetsCb.TabIndex = 13;
            this.ToolTips.SetToolTip(this.toSheetsCb, "Select Table from the newer document (To)");
            this.toSheetsCb.UseSelectable = true;
            this.toSheetsCb.SelectedValueChanged += new System.EventHandler(this.toSheetsCb_SelectedIndexChanged);
            // 
            // sortModeCb
            // 
            this.sortModeCb.Enabled = false;
            this.sortModeCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.sortModeCb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sortModeCb.FormattingEnabled = true;
            this.sortModeCb.ItemHeight = 19;
            this.sortModeCb.Items.AddRange(new object[] {
            "Cell",
            "Row by row"});
            this.sortModeCb.Location = new System.Drawing.Point(75, 27);
            this.sortModeCb.Name = "sortModeCb";
            this.sortModeCb.Size = new System.Drawing.Size(121, 25);
            this.sortModeCb.TabIndex = 15;
            this.sortModeCb.UseSelectable = true;
            this.sortModeCb.SelectedIndexChanged += new System.EventHandler(this.sortModeCb_SelectedIndexChanged);
            // 
            // ToolTips
            // 
            this.ToolTips.Style = MetroFramework.MetroColorStyle.Blue;
            this.ToolTips.StyleManager = null;
            this.ToolTips.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ModeLbl
            // 
            this.ModeLbl.AutoSize = true;
            this.ModeLbl.Location = new System.Drawing.Point(6, 30);
            this.ModeLbl.Name = "ModeLbl";
            this.ModeLbl.Size = new System.Drawing.Size(44, 19);
            this.ModeLbl.TabIndex = 16;
            this.ModeLbl.Text = "Mode";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(3, 64);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(66, 19);
            this.idLbl.TabIndex = 18;
            this.idLbl.Text = "Unique ID";
            this.idLbl.Visible = false;
            // 
            // uniqueIdColCb
            // 
            this.uniqueIdColCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.uniqueIdColCb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.uniqueIdColCb.FormattingEnabled = true;
            this.uniqueIdColCb.ItemHeight = 19;
            this.uniqueIdColCb.Location = new System.Drawing.Point(75, 62);
            this.uniqueIdColCb.Name = "uniqueIdColCb";
            this.uniqueIdColCb.Size = new System.Drawing.Size(121, 25);
            this.uniqueIdColCb.TabIndex = 17;
            this.uniqueIdColCb.UseSelectable = true;
            this.uniqueIdColCb.Visible = false;
            this.uniqueIdColCb.SelectedIndexChanged += new System.EventHandler(this.uniqueIdColCb_SelectedIndexChanged);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.hasHeader);
            this.metroPanel1.Controls.Add(this.openFileControl1);
            this.metroPanel1.Controls.Add(this.openFileControl2);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(17, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(431, 104);
            this.metroPanel1.TabIndex = 19;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.metroLabel6);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.Controls.Add(this.coSheetsCb);
            this.metroPanel2.Controls.Add(this.toSheetsCb);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(453, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(191, 104);
            this.metroPanel2.TabIndex = 20;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 64);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(50, 19);
            this.metroLabel6.TabIndex = 28;
            this.metroLabel6.Text = "Table 2";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(5, 30);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 19);
            this.metroLabel5.TabIndex = 27;
            this.metroLabel5.Text = "Table 1";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.metroLabel3);
            this.metroPanel3.Controls.Add(this.uniqueIdColCb);
            this.metroPanel3.Controls.Add(this.idLbl);
            this.metroPanel3.Controls.Add(this.sortModeCb);
            this.metroPanel3.Controls.Add(this.ModeLbl);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(650, 63);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(200, 104);
            this.metroPanel3.TabIndex = 21;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Controls.Add(this.metroLabel4);
            this.metroPanel4.Controls.Add(this.openSpeadcBox);
            this.metroPanel4.Controls.Add(this.genSpreadcBox);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(854, 63);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(166, 104);
            this.metroPanel4.TabIndex = 22;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(26, 63);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(79, 19);
            this.metroLabel1.TabIndex = 23;
            this.metroLabel1.Text = "Documents";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(5, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(49, 19);
            this.metroLabel2.TabIndex = 24;
            this.metroLabel2.Text = "Sheets";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(6, -1);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(105, 19);
            this.metroLabel3.TabIndex = 25;
            this.metroLabel3.Text = "Compare Mode";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(3, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(37, 19);
            this.metroLabel4.TabIndex = 26;
            this.metroLabel4.Text = "Misc";
            // 
            // openFileControl1
            // 
            this.openFileControl1.Location = new System.Drawing.Point(1, 25);
            this.openFileControl1.Name = "openFileControl1";
            this.openFileControl1.Size = new System.Drawing.Size(427, 29);
            this.openFileControl1.TabIndex = 0;
            this.openFileControl1.Title = "Compare";
            this.ToolTips.SetToolTip(this.openFileControl1, "Original document");
            this.openFileControl1.UseSelectable = true;
            // 
            // openFileControl2
            // 
            this.openFileControl2.Location = new System.Drawing.Point(1, 60);
            this.openFileControl2.Name = "openFileControl2";
            this.openFileControl2.Size = new System.Drawing.Size(427, 29);
            this.openFileControl2.TabIndex = 1;
            this.openFileControl2.Title = "To";
            this.ToolTips.SetToolTip(this.openFileControl2, "Newer document");
            this.openFileControl2.UseSelectable = true;
            // 
            // hasHeader
            // 
            this.hasHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hasHeader.AutoSize = true;
            this.hasHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hasHeader.Location = new System.Drawing.Point(330, 3);
            this.hasHeader.Name = "hasHeader";
            this.hasHeader.Size = new System.Drawing.Size(89, 15);
            this.hasHeader.TabIndex = 7;
            this.hasHeader.Text = "Has Header?";
            this.hasHeader.UseSelectable = true;
            this.hasHeader.CheckedChanged += new System.EventHandler(this.hasHeader_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel4);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.sheetController);
            this.Controls.Add(this.CompareBtn);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Spreadsheet Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
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
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
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
        private OpenFileControl openFileControl1;
        private MetroFramework.Controls.MetroComboBox coSheetsCb;
        private MetroFramework.Controls.MetroComboBox toSheetsCb;
        private MetroFramework.Controls.MetroComboBox sortModeCb;
        private MetroFramework.Components.MetroToolTip ToolTips;
        private MetroFramework.Controls.MetroLabel ModeLbl;
        private MetroFramework.Controls.MetroLabel idLbl;
        private MetroFramework.Controls.MetroComboBox uniqueIdColCb;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroCheckBox hasHeader;
    }
}
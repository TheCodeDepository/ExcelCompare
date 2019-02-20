namespace SpreadsheetCompare
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CompareBtn = new MetroFramework.Controls.MetroButton();
            this.genSpreadcBox = new MetroFramework.Controls.MetroCheckBox();
            this.openSpeadcBox = new MetroFramework.Controls.MetroCheckBox();
            this.sheetController = new MetroFramework.Controls.MetroTabControl();
            this.mergedViewTab = new MetroFramework.Controls.MetroTabPage();
            this.meViewGrid = new System.Windows.Forms.DataGridView();
            this.sideBySide = new MetroFramework.Controls.MetroTabPage();
            this.TableSplitter = new System.Windows.Forms.SplitContainer();
            this.coViewGrid = new System.Windows.Forms.DataGridView();
            this.toViewGrid = new System.Windows.Forms.DataGridView();
            this.singleViewTab = new System.Windows.Forms.TabPage();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.selectedView = new MetroFramework.Controls.MetroComboBox();
            this.singleViewGrid = new System.Windows.Forms.DataGridView();
            this.coSheetsCb = new MetroFramework.Controls.MetroComboBox();
            this.toSheetsCb = new MetroFramework.Controls.MetroComboBox();
            this.sortModeCb = new MetroFramework.Controls.MetroComboBox();
            this.ToolTips = new MetroFramework.Components.MetroToolTip();
            this.ModeLbl = new MetroFramework.Controls.MetroLabel();
            this.idLbl = new MetroFramework.Controls.MetroLabel();
            this.uniqueIdColCb = new MetroFramework.Controls.MetroComboBox();
            this.hasHeader = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.openFileControl1 = new SpreadsheetCompare.OpenFileControl();
            this.openFileControl2 = new SpreadsheetCompare.OpenFileControl();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.AboutLbl = new MetroFramework.Controls.MetroLabel();
            this.sheetController.SuspendLayout();
            this.mergedViewTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meViewGrid)).BeginInit();
            this.sideBySide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableSplitter)).BeginInit();
            this.TableSplitter.Panel1.SuspendLayout();
            this.TableSplitter.Panel2.SuspendLayout();
            this.TableSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coViewGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toViewGrid)).BeginInit();
            this.singleViewTab.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleViewGrid)).BeginInit();
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
            this.CompareBtn.Location = new System.Drawing.Point(1095, 127);
            this.CompareBtn.Name = "CompareBtn";
            this.CompareBtn.Size = new System.Drawing.Size(75, 23);
            this.CompareBtn.TabIndex = 9;
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
            this.genSpreadcBox.TabIndex = 7;
            this.genSpreadcBox.Text = "Generate Spreadsheet";
            this.ToolTips.SetToolTip(this.genSpreadcBox, "Generate a .xlsx file containing merged results");
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
            this.openSpeadcBox.TabIndex = 8;
            this.openSpeadcBox.Text = "Open Spreadsheet";
            this.ToolTips.SetToolTip(this.openSpeadcBox, "Open exported spreadsheet on completion");
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
            this.sheetController.Controls.Add(this.singleViewTab);
            this.sheetController.Location = new System.Drawing.Point(23, 166);
            this.sheetController.Name = "sheetController";
            this.sheetController.SelectedIndex = 0;
            this.sheetController.Size = new System.Drawing.Size(1154, 611);
            this.sheetController.Style = MetroFramework.MetroColorStyle.Green;
            this.sheetController.TabIndex = 10;
            this.sheetController.UseSelectable = true;
            this.sheetController.SelectedIndexChanged += new System.EventHandler(this.sheetController_SelectedIndexChanged);
            // 
            // mergedViewTab
            // 
            this.mergedViewTab.Controls.Add(this.meViewGrid);
            this.mergedViewTab.HorizontalScrollbarBarColor = true;
            this.mergedViewTab.HorizontalScrollbarHighlightOnWheel = false;
            this.mergedViewTab.HorizontalScrollbarSize = 10;
            this.mergedViewTab.Location = new System.Drawing.Point(4, 38);
            this.mergedViewTab.Name = "mergedViewTab";
            this.mergedViewTab.Size = new System.Drawing.Size(1146, 569);
            this.mergedViewTab.TabIndex = 0;
            this.mergedViewTab.Text = "Merged View";
            this.mergedViewTab.VerticalScrollbarBarColor = true;
            this.mergedViewTab.VerticalScrollbarHighlightOnWheel = false;
            this.mergedViewTab.VerticalScrollbarSize = 10;
            // 
            // meViewGrid
            // 
            this.meViewGrid.AllowUserToAddRows = false;
            this.meViewGrid.AllowUserToDeleteRows = false;
            this.meViewGrid.AllowUserToResizeRows = false;
            this.meViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.meViewGrid.BackgroundColor = System.Drawing.Color.White;
            this.meViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.meViewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.meViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.meViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.meViewGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.meViewGrid.GridColor = System.Drawing.Color.White;
            this.meViewGrid.Location = new System.Drawing.Point(-1, 3);
            this.meViewGrid.Name = "meViewGrid";
            this.meViewGrid.ReadOnly = true;
            this.meViewGrid.RowHeadersVisible = false;
            this.meViewGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.meViewGrid.Size = new System.Drawing.Size(1147, 563);
            this.meViewGrid.TabIndex = 13;
            // 
            // sideBySide
            // 
            this.sideBySide.Controls.Add(this.TableSplitter);
            this.sideBySide.HorizontalScrollbarBarColor = true;
            this.sideBySide.HorizontalScrollbarHighlightOnWheel = false;
            this.sideBySide.HorizontalScrollbarSize = 10;
            this.sideBySide.Location = new System.Drawing.Point(4, 38);
            this.sideBySide.Name = "sideBySide";
            this.sideBySide.Size = new System.Drawing.Size(1146, 569);
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
            this.TableSplitter.Panel1.Controls.Add(this.coViewGrid);
            // 
            // TableSplitter.Panel2
            // 
            this.TableSplitter.Panel2.Controls.Add(this.toViewGrid);
            this.TableSplitter.Size = new System.Drawing.Size(1140, 566);
            this.TableSplitter.SplitterDistance = 566;
            this.TableSplitter.SplitterWidth = 8;
            this.TableSplitter.TabIndex = 2;
            // 
            // coViewGrid
            // 
            this.coViewGrid.AllowUserToAddRows = false;
            this.coViewGrid.AllowUserToDeleteRows = false;
            this.coViewGrid.AllowUserToResizeRows = false;
            this.coViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.coViewGrid.BackgroundColor = System.Drawing.Color.White;
            this.coViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.coViewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.coViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.coViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.coViewGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.coViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coViewGrid.GridColor = System.Drawing.Color.White;
            this.coViewGrid.Location = new System.Drawing.Point(0, 0);
            this.coViewGrid.Name = "coViewGrid";
            this.coViewGrid.ReadOnly = true;
            this.coViewGrid.RowHeadersVisible = false;
            this.coViewGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.coViewGrid.Size = new System.Drawing.Size(566, 566);
            this.coViewGrid.TabIndex = 12;
            this.coViewGrid.ColumnDividerDoubleClick += new System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventHandler(this.ColumnDividerDoubleClick);
            this.coViewGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
            this.coViewGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SideBySideGrid1_Scroll);
            // 
            // toViewGrid
            // 
            this.toViewGrid.AllowUserToAddRows = false;
            this.toViewGrid.AllowUserToDeleteRows = false;
            this.toViewGrid.AllowUserToResizeRows = false;
            this.toViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.toViewGrid.BackgroundColor = System.Drawing.Color.White;
            this.toViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toViewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.toViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.toViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.toViewGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.toViewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toViewGrid.GridColor = System.Drawing.Color.White;
            this.toViewGrid.Location = new System.Drawing.Point(0, 0);
            this.toViewGrid.Name = "toViewGrid";
            this.toViewGrid.ReadOnly = true;
            this.toViewGrid.RowHeadersVisible = false;
            this.toViewGrid.Size = new System.Drawing.Size(566, 566);
            this.toViewGrid.TabIndex = 13;
            this.toViewGrid.ColumnDividerDoubleClick += new System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventHandler(this.ColumnDividerDoubleClick);
            this.toViewGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SideBySideGrid2_Scroll);
            // 
            // singleViewTab
            // 
            this.singleViewTab.Controls.Add(this.metroPanel5);
            this.singleViewTab.Location = new System.Drawing.Point(4, 38);
            this.singleViewTab.Name = "singleViewTab";
            this.singleViewTab.Size = new System.Drawing.Size(1146, 569);
            this.singleViewTab.TabIndex = 2;
            this.singleViewTab.Text = "Single View";
            // 
            // metroPanel5
            // 
            this.metroPanel5.Controls.Add(this.selectedView);
            this.metroPanel5.Controls.Add(this.singleViewGrid);
            this.metroPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(0, 0);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(1146, 569);
            this.metroPanel5.TabIndex = 25;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // selectedView
            // 
            this.selectedView.FormattingEnabled = true;
            this.selectedView.ItemHeight = 23;
            this.selectedView.Items.AddRange(new object[] {
            "Compare",
            "To"});
            this.selectedView.Location = new System.Drawing.Point(3, 3);
            this.selectedView.Name = "selectedView";
            this.selectedView.Size = new System.Drawing.Size(142, 29);
            this.selectedView.TabIndex = 13;
            this.selectedView.UseSelectable = true;
            this.selectedView.SelectedIndexChanged += new System.EventHandler(this.selectedView_SelectedIndexChanged);
            // 
            // singleViewGrid
            // 
            this.singleViewGrid.AllowUserToAddRows = false;
            this.singleViewGrid.AllowUserToDeleteRows = false;
            this.singleViewGrid.AllowUserToResizeRows = false;
            this.singleViewGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.singleViewGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.singleViewGrid.BackgroundColor = System.Drawing.Color.White;
            this.singleViewGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.singleViewGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.singleViewGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.singleViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.singleViewGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.singleViewGrid.GridColor = System.Drawing.Color.White;
            this.singleViewGrid.Location = new System.Drawing.Point(0, 38);
            this.singleViewGrid.Name = "singleViewGrid";
            this.singleViewGrid.ReadOnly = true;
            this.singleViewGrid.RowHeadersVisible = false;
            this.singleViewGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.singleViewGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.singleViewGrid.Size = new System.Drawing.Size(1146, 528);
            this.singleViewGrid.TabIndex = 12;
            // 
            // coSheetsCb
            // 
            this.coSheetsCb.Enabled = false;
            this.coSheetsCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.coSheetsCb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.coSheetsCb.FormattingEnabled = true;
            this.coSheetsCb.ItemHeight = 19;
            this.coSheetsCb.Location = new System.Drawing.Point(59, 27);
            this.coSheetsCb.Name = "coSheetsCb";
            this.coSheetsCb.Size = new System.Drawing.Size(121, 25);
            this.coSheetsCb.TabIndex = 3;
            this.ToolTips.SetToolTip(this.coSheetsCb, "Select Table from the older document (Compare)");
            this.coSheetsCb.UseSelectable = true;
            this.coSheetsCb.SelectedValueChanged += new System.EventHandler(this.coSheetsCb_SelectedIndexChanged);
            // 
            // toSheetsCb
            // 
            this.toSheetsCb.Enabled = false;
            this.toSheetsCb.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.toSheetsCb.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toSheetsCb.FormattingEnabled = true;
            this.toSheetsCb.ItemHeight = 19;
            this.toSheetsCb.Location = new System.Drawing.Point(59, 62);
            this.toSheetsCb.Name = "toSheetsCb";
            this.toSheetsCb.Size = new System.Drawing.Size(121, 25);
            this.toSheetsCb.TabIndex = 4;
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
            this.sortModeCb.TabIndex = 5;
            this.ToolTips.SetToolTip(this.sortModeCb, "Comparison Options");
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
            this.ToolTips.SetToolTip(this.ModeLbl, "Comparison Options");
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(3, 64);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(66, 19);
            this.idLbl.TabIndex = 18;
            this.idLbl.Text = "Unique ID";
            this.ToolTips.SetToolTip(this.idLbl, "Select unique identifier column");
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
            this.uniqueIdColCb.TabIndex = 6;
            this.ToolTips.SetToolTip(this.uniqueIdColCb, "Select unique identifier column");
            this.uniqueIdColCb.UseSelectable = true;
            this.uniqueIdColCb.Visible = false;
            this.uniqueIdColCb.SelectedIndexChanged += new System.EventHandler(this.uniqueIdColCb_SelectedIndexChanged);
            // 
            // hasHeader
            // 
            this.hasHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hasHeader.AutoSize = true;
            this.hasHeader.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hasHeader.Location = new System.Drawing.Point(335, 2);
            this.hasHeader.Name = "hasHeader";
            this.hasHeader.Size = new System.Drawing.Size(89, 15);
            this.hasHeader.TabIndex = 0;
            this.hasHeader.Text = "Has Header?";
            this.ToolTips.SetToolTip(this.hasHeader, "Use first row as column names");
            this.hasHeader.UseSelectable = true;
            this.hasHeader.CheckedChanged += new System.EventHandler(this.hasHeader_CheckedChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 64);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(50, 19);
            this.metroLabel6.TabIndex = 28;
            this.metroLabel6.Text = "Table 2";
            this.ToolTips.SetToolTip(this.metroLabel6, "Select Table from the newer document (To)");
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(5, 30);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(48, 19);
            this.metroLabel5.TabIndex = 27;
            this.metroLabel5.Text = "Table 1";
            this.ToolTips.SetToolTip(this.metroLabel5, "Select Table from the older document (Compare)");
            // 
            // openFileControl1
            // 
            this.openFileControl1.ConnectionPath = null;
            this.openFileControl1.FilePath = "";
            this.openFileControl1.Location = new System.Drawing.Point(1, 25);
            this.openFileControl1.Name = "openFileControl1";
            this.openFileControl1.Size = new System.Drawing.Size(427, 29);
            this.openFileControl1.TabIndex = 1;
            this.openFileControl1.Title = "Compare";
            this.ToolTips.SetToolTip(this.openFileControl1, "Original document");
            this.openFileControl1.UseSelectable = true;
            // 
            // openFileControl2
            // 
            this.openFileControl2.ConnectionPath = null;
            this.openFileControl2.FilePath = "";
            this.openFileControl2.Location = new System.Drawing.Point(1, 60);
            this.openFileControl2.Name = "openFileControl2";
            this.openFileControl2.Size = new System.Drawing.Size(427, 29);
            this.openFileControl2.TabIndex = 2;
            this.openFileControl2.Title = "To";
            this.ToolTips.SetToolTip(this.openFileControl2, "Newer document");
            this.openFileControl2.UseSelectable = true;
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
            // AboutLbl
            // 
            this.AboutLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutLbl.AutoSize = true;
            this.AboutLbl.FontSize = MetroFramework.MetroLabelSize.Small;
            this.AboutLbl.Location = new System.Drawing.Point(1079, 8);
            this.AboutLbl.Name = "AboutLbl";
            this.AboutLbl.Size = new System.Drawing.Size(39, 15);
            this.AboutLbl.TabIndex = 14;
            this.AboutLbl.Text = "About";
            this.AboutLbl.Click += new System.EventHandler(this.AboutLbl_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.AboutLbl);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroPanel4);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.sheetController);
            this.Controls.Add(this.CompareBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Spreadsheet Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sheetController.ResumeLayout(false);
            this.mergedViewTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meViewGrid)).EndInit();
            this.sideBySide.ResumeLayout(false);
            this.TableSplitter.Panel1.ResumeLayout(false);
            this.TableSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TableSplitter)).EndInit();
            this.TableSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coViewGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toViewGrid)).EndInit();
            this.singleViewTab.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.singleViewGrid)).EndInit();
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
        private System.Windows.Forms.DataGridView coViewGrid;
        private System.Windows.Forms.DataGridView toViewGrid;
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
        private MetroFramework.Controls.MetroLabel AboutLbl;
        private System.Windows.Forms.TabPage singleViewTab;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroComboBox selectedView;
        private System.Windows.Forms.DataGridView singleViewGrid;
        private System.Windows.Forms.DataGridView meViewGrid;
    }
}
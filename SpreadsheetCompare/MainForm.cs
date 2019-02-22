using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using SpreadsheetLogic;

namespace SpreadsheetCompare
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private FormController ctrl;
        private GridColorController view;

        private TableImport TableOne;
        private TableImport TableTwo;

        private string outputPath { get; set; }

        public MainForm()
        {
            InitializeComponent();
            openFileControl1._TextChanged += GetSheetNamesOne;
            openFileControl2._TextChanged += GetSheetNamesTwo;

            coViewGrid.MouseWheel += ScrollSideOne;

            compareHandler = CompareThreadCompleted;
            ctrl = new FormController(Compare_OnComplete);

            //sortModeCb.DropDownStyle = ComboBoxStyle.DropDownList;

            sortModeCb.SelectedIndex = (int)ctrl.sortMethod;
            genSpreadcBox.Checked = ctrl.GenerateSpreadsheet;
            openSpeadcBox.Checked = ctrl.OpenSpreadsheet;
            selectedView.SelectedIndex = ctrl.SelectedSingleView;
        }

        /* Get Sheet Names and Datatable */
        private void GetSheetNamesOne(object sender, EventArgs e)
        {
            TableOne = new TableImport(openFileControl1.ConnectionPath, hasHeader.Checked);
            UpdateSheets(openFileControl1, TableOne, coSheetsCb);
        }
        private void GetSheetNamesTwo(object sender, EventArgs e)
        {
            TableTwo = new TableImport(openFileControl2.ConnectionPath, hasHeader.Checked);
            UpdateSheets(openFileControl2, TableTwo, toSheetsCb);
        }
        private void UpdateSheets(OpenFileControl file, TableImport import, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            if (file.ConnectionPath != null)
            {
                foreach (string tableName in import.GetTableNames())
                {
                    comboBox.Items.Add(tableName);
                }
                comboBox.SelectedIndex = 0;
            }
            comboBox.Enabled = true;
        }

        private void coSheetsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coSheetsCb.Text != "" && coSheetsCb.Enabled)
            {
                ctrl.tableOne = TableOne.GetDataTable(coSheetsCb.Text);
                CheckSelections();
            }
        }
        private void toSheetsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toSheetsCb.Text != "" && toSheetsCb.Enabled)
            {
                ctrl.tableTwo = TableTwo.GetDataTable(toSheetsCb.Text);
                CheckSelections();
            }
        }


        /* Sorting Mode */
        private void sortModeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctrl.tableOne != null && ctrl.tableTwo != null)
            {
                ctrl.sortMethod = (SortMethod)sortModeCb.SelectedIndex;
                CheckSortMethod();
            }
        }
        private void uniqueIdColCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uniqueIdColCb.SelectedIndex > -1)
            {
                ctrl.columnIndex = uniqueIdColCb.SelectedIndex;
                CompareBtn.Enabled = true;
            }
            else
            {
                CompareBtn.Enabled = false;
            }
        }
        private void hasHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (ctrl.tableOne != null)
            {
                TableOne.hasHeader = hasHeader.Checked;
                ctrl.tableOne = TableOne.GetDataTable(coSheetsCb.Text);
            }
            if (ctrl.tableTwo != null)
            {
                TableTwo.hasHeader = hasHeader.Checked;
                ctrl.tableTwo = TableTwo.GetDataTable(coSheetsCb.Text);
            }
            ColumnNamesforUID();
        }
        private void CheckSortMethod()
        {
            if (ctrl.tableOne != null && ctrl.tableTwo != null)
            {
                CompareBtn.Enabled = true;
                switch ((SortMethod)sortModeCb.SelectedIndex)
                {
                    case SortMethod.CellbyCell:
                        uniqueIdColCb.Visible = false;
                        idLbl.Visible = false;
                        break;
                    case SortMethod.RowByRow:
                        CompareBtn.Enabled = false;
                        ColumnNamesforUID();
                        break;
                }
            }

        }
        private void ColumnNamesforUID()
        {
            if (sortModeCb.SelectedIndex > -1)
            {
                ctrl.sortMethod = (SortMethod)sortModeCb.SelectedIndex;
            }
            if (ctrl.sortMethod == SortMethod.RowByRow)
            {
                uniqueIdColCb.Items.Clear();
                uniqueIdColCb.Visible = true;
                idLbl.Visible = true;
                foreach (DataColumn item in ctrl.tableOne.Columns)
                {
                    uniqueIdColCb.Items.Add(item.ColumnName);
                }
                if (uniqueIdColCb.Items.Count > 0)
                {
                    uniqueIdColCb.SelectedIndex = 0;
                }
            }
        }

        /* Compare button */
        private delegate void CompareComplete();
        private CompareComplete compareHandler;

        private void CompareBtn_Click(object sender, EventArgs e)
        {
            if (ctrl.AreTablesValid())
            {
                CompareBtn.Enabled = false;
                try
                {
                    ctrl.CompareThreadGo();
                }
                catch (Exception m)
                {
                    MetroFramework.MetroMessageBox.Show(this, $"An Exception has occured, please close the application and try again./n{m.Message}");
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Invalid Tables. Please ensure tables have the same number of columns. Tables Should contain more than one Column and Row.");
            }
        }

        private void Compare_OnComplete(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(compareHandler);
                }
                catch (Exception m)
                {
                    MetroFramework.MetroMessageBox.Show(this, $"An Exception has occured, please close the application and try again.\n{m.Message}");
                }
            }
            else
            {
                CompareThreadCompleted();
            }
        }

        /* Form Behavior */
        private void SideBySideGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            if (toViewGrid.Rows.Count > coViewGrid.FirstDisplayedScrollingRowIndex)
            {
                this.toViewGrid.FirstDisplayedScrollingRowIndex = this.coViewGrid.FirstDisplayedScrollingRowIndex;
            }
        }
        private void SideBySideGrid2_Scroll(object sender, ScrollEventArgs e)
        {
            if (coViewGrid.Rows.Count > toViewGrid.FirstDisplayedScrollingRowIndex)
            {
                this.coViewGrid.FirstDisplayedScrollingRowIndex = this.toViewGrid.FirstDisplayedScrollingRowIndex;
            }
        }
        private void ColumnDividerDoubleClick(object sender, DataGridViewColumnDividerDoubleClickEventArgs e)
        {
            view.SetColumnWidth();
        }
        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            view.SetColumnWidth();
        }
        private void CheckSelections()
        {
            CheckSortMethod();
            if (ctrl.tableOne != null && ctrl.tableTwo != null)
            {
                sortModeCb.Enabled = true;
            }
            else
            {
                sortModeCb.Enabled = false;
            }
        }
        private void ScrollSideOne(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && coViewGrid.FirstDisplayedScrollingRowIndex > 0)
            {
                coViewGrid.FirstDisplayedScrollingRowIndex--;
            }
            else if (e.Delta < 0)
            {
                coViewGrid.FirstDisplayedScrollingRowIndex++;
            }
        }
        private void selectedView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrl.SelectedSingleView = selectedView.SelectedIndex;
            UpdateSingleView();
        }


        /* Load Data to form */
        private void CompareThreadCompleted()
        {
            if (meViewGrid.DataSource != null)
            {
                meViewGrid.DataSource = null;
                coViewGrid.DataSource = null;
                toViewGrid.DataSource = null;
            }
            view = new GridColorController(meViewGrid, coViewGrid, toViewGrid, singleViewGrid, ctrl.resultContext);
            meViewGrid.DataSource = ctrl.mergedView;
            coViewGrid.DataSource = ctrl.tableOne;
            toViewGrid.DataSource = ctrl.tableTwo;
            view.PushColorsToTables();
            UpdateSingleView();
            SaveReportDialog();
            CompareBtn.Enabled = true;
        }
        private void SaveReportDialog()
        {
            if (genSpreadcBox.Checked)
            {
                var shouldRetry = DialogResult.Cancel;
                do
                {
                    shouldRetry = DialogResult.Cancel;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        outputPath = saveFileDialog.FileName;
                        try
                        {
                            ctrl.ExportMergedTable(outputPath);
                            if (openSpeadcBox.Checked)
                            {
                                System.Diagnostics.Process.Start(outputPath);
                            }
                        }
                        catch (Exception m)
                        {
                            shouldRetry = MetroFramework.MetroMessageBox.Show(this, $"{m.Message}\nPlease ensure the target file is closed.", "An Error has occured", MessageBoxButtons.RetryCancel);
                        }

                    }
                } while (shouldRetry == DialogResult.Retry);
            }
        }
        private void UpdateSingleView()
        {
            singleViewGrid.DataSource = null;
            if (ctrl.resultContext != null)
            {
                switch (selectedView.SelectedIndex)
                {
                    case 0:
                        singleViewGrid.DataSource = ctrl.tableOne;
                        break;
                    case 1:
                        singleViewGrid.DataSource = ctrl.tableTwo;
                        break;
                }
                view.PushSingleView(selectedView.SelectedIndex);
            }
        }
        private void sheetController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (view != null)
            {
                switch (sheetController.SelectedIndex)
                {
                    case 0:
                        view.PushMerged();
                        break;
                    case 1:
                        view.PushSideBySide();
                        break;
                    case 2:
                        UpdateSingleView();
                        break;

                }
            }
        }

        /* Misc/About button */
        private void AboutLbl_Click(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string about = string.Format($"This is a spreadsheet comparison tool designed to compare spreadsheets and output the differences.\nVersion Number: {version}\nAuthor: Martin White");
            MetroFramework.MetroMessageBox.Show(this, about, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void genSpreadcBox_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.GenerateSpreadsheet = genSpreadcBox.Checked;

            switch (ctrl.GenerateSpreadsheet)
            {
                case true:
                    openSpeadcBox.Enabled = true;
                    break;
                default:
                    openSpeadcBox.Enabled = false;
                    openSpeadcBox.Checked = false;
                    break;
            }

        }
        private void openSpeadcBox_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.OpenSpreadsheet = openSpeadcBox.Checked;
        }

        /* Load and Exit */
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!ctrl.isValidDomain())
            {
                MetroFramework.MetroMessageBox.Show(this, "You are not registered to company domain, please contain your system administrator.", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            sheetController.SelectedIndex = 0;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.SaveConfig();
        }

    }
}

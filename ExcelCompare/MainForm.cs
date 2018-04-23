using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using SpreadsheetLogic;
using System.Collections.Generic;

namespace ExcelCompare
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private FormController ctrl;

        public delegate void CompareComplete();
        CompareComplete compareHandler;

        public string docPathOne { get { return openFileControl1.FilePath; } }
        public string docPathTwo { get { return openFileControl2.FilePath; } }
        public string outputPath { get; private set; }



        public MainForm()
        {
            InitializeComponent();
            openFileControl1._TextChanged += GetSheetNamesOne;
            openFileControl2._TextChanged += GetSheetNamesTwo;
          
            
            SideBySideGrid1.MouseWheel += ScrollSideOne;
            

            compareHandler = CompareThreadCompleted;
            ctrl = new FormController(Compare_OnComplete);
            hasHeader.Checked = ctrl.hasHeader;
            sortModeCb.SelectedIndex = (int)ctrl.sortMethod;
            genSpreadcBox.Checked = ctrl.GenerateSpreadsheet;
            openSpeadcBox.Checked = ctrl.OpenSpreadsheet;
            
        }
        private void ScrollSideOne(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && SideBySideGrid1.FirstDisplayedScrollingRowIndex > 0)
            {
                SideBySideGrid1.FirstDisplayedScrollingRowIndex--;
            }
            else if (e.Delta < 0)
            {
                SideBySideGrid1.FirstDisplayedScrollingRowIndex++;
            }
        }
        private void CompareBtn_Click(object sender, EventArgs e)
        {

            CompareBtn.Enabled = false;
            if (ctrl.AreColumnsEqual())
            {
                try
                {
                    ctrl.CompareThreadGo();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Ensure the tables start in the top right of the spreadsheet and contain atleast 2 columns and 2 rows. Spreadsheets must contain the same number of columns.");                    
                }
            }
            else
            {
                MessageBox.Show("Columns are not equal, please ensure table column count is equal.");
            }
        }
        private void Compare_OnComplete(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(compareHandler);
            }
            else
            {
                CompareThreadCompleted();
            }
        }
        private void GetSheetNamesOne(object sender, EventArgs e)
        {
            if (!File.Exists(docPathOne))
                return;
            coSheetsCb.Items.Clear();
            if (Path.GetExtension(docPathOne) == ".xlsx")
            {
                coSheetsCb.Enabled = true;
                ctrl.workbookOne = ctrl.GetWorkBook(docPathOne);
                foreach (DataTable table in ctrl.workbookOne.Tables)
                {
                    coSheetsCb.Items.Add(table.TableName);
                }
                coSheetsCb.SelectedIndex = 0;
            }
            else
            {
                coSheetsCb.Enabled = false;
                coSheetsCb.Items.Add("CSV file selected");
                ctrl.tableOne = ctrl.GetDataTable(docPathOne);
            }
        }
        private void GetSheetNamesTwo(object sender, EventArgs e)
        {
            if (!File.Exists(docPathTwo))
            {
                return;
            }
            toSheetsCb.Items.Clear();
            if (Path.GetExtension(docPathTwo) == ".xlsx")
            {
                toSheetsCb.Enabled = true;
                ctrl.workbookTwo = ctrl.GetWorkBook(docPathTwo);
                foreach (DataTable table in ctrl.workbookTwo.Tables)
                {
                    toSheetsCb.Items.Add(table.TableName);
                }
                toSheetsCb.SelectedIndex = 0;

            }
            else
            {
                toSheetsCb.Enabled = false;
                toSheetsCb.Items.Add("CSV file selected");
                ctrl.tableTwo = ctrl.GetDataTable(docPathTwo);
            }
        }
        private void SideBySideGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            this.SideBySideGrid2.FirstDisplayedScrollingRowIndex = this.SideBySideGrid1.FirstDisplayedScrollingRowIndex;
            this.SideBySideGrid2.HorizontalScrollingOffset = this.SideBySideGrid1.HorizontalScrollingOffset;
        }
        private void SideBySideGrid2_Scroll(object sender, ScrollEventArgs e)
        {
            this.SideBySideGrid1.FirstDisplayedScrollingRowIndex = this.SideBySideGrid2.FirstDisplayedScrollingRowIndex;
            this.SideBySideGrid1.HorizontalScrollingOffset = this.SideBySideGrid2.HorizontalScrollingOffset;
        }
        private void sheetController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctrl != null)
            {
                if (ctrl.diffrenceCount > 0)
                {
                    switch (sheetController.SelectedIndex)
                    {
                        case 0:
                            PushMergedDifferences();
                            break;
                        case 1:
                            PushSideBySide();
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        private void coSheetsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (coSheetsCb.SelectedIndex > -1)
            {
                ctrl.tableOne = ctrl.GetTableByIndex(coSheetsCb.SelectedIndex, ctrl.workbookOne);
                CheckSelections();
            }
        }
        private void toSheetsCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toSheetsCb.SelectedIndex > -1)
            {
                ctrl.tableTwo = ctrl.GetTableByIndex(toSheetsCb.SelectedIndex, ctrl.workbookTwo);
                CheckSelections();
            }
        }
        private void CompareThreadCompleted()
        {
            PushTablesToView();
            CompareBtn.Enabled = true;
        }
        private void PushTablesToView()
        {
            PushMergedDifferences();
            PushSideBySide();
            SetGridViewSortState(MergedViewGrid, DataGridViewColumnSortMode.NotSortable);
            SetGridViewSortState(SideBySideGrid1, DataGridViewColumnSortMode.NotSortable);
            SetGridViewSortState(SideBySideGrid2, DataGridViewColumnSortMode.NotSortable);
            QueryUserReport();
        }
        private void PushMergedDifferences()
        {
            MergedViewGrid.DataSource = ctrl.mergedView;

            switch (ctrl.sortMethod)
            {
                case SortMethod.CellbyCell:
                    ProcessDifferences(MergedViewGrid, ctrl.DiffLocations);
                    break;
                case SortMethod.RowByRow:
                    ProcessDeletedRows(MergedViewGrid, ctrl.ViewContext.meDeletedRows);
                    ProcessNewRows(MergedViewGrid, ctrl.ViewContext.meAddedRows);
                    ProcessDifferences(MergedViewGrid, ctrl.ViewContext.meCells);
                    break;
                default:
                    break;
            }

        }
        private void PushSideBySide()
        {
            SideBySideGrid1.DataSource = ctrl.tableOne;
            SideBySideGrid2.DataSource = ctrl.tableTwo;
            

            switch (ctrl.sortMethod)
            {
                case SortMethod.CellbyCell:
                    ProcessDifferences(SideBySideGrid1, ctrl.DiffLocations);
                    ProcessDifferences(SideBySideGrid2, ctrl.DiffLocations);
                    break;
                case SortMethod.RowByRow:
                    SideBySideGrid1.DataSource = ctrl.tableOne;
                    ProcessDeletedRows(SideBySideGrid1, ctrl.ViewContext.DeletedRows);
                    ProcessDifferences(SideBySideGrid1, ctrl.ViewContext.coCells);

                    SideBySideGrid2.DataSource = ctrl.tableTwo;
                    ProcessNewRows(SideBySideGrid2, ctrl.ViewContext.AddedRows);
                    ProcessDifferences(SideBySideGrid2, ctrl.ViewContext.toCells);
                    break;
                default:
                    break;
            }

        }
        private void ProcessNewRows(DataGridView grid, ICollection<int> indexList)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Green;
            diffStyle.ForeColor = Color.White;
            foreach (int item in indexList)
            {
                for (int i = 0; i < grid.ColumnCount; i++)
                {
                    grid.Rows[item].Cells[i].Style = diffStyle;
                }

            }
        }
        private void ProcessDeletedRows(DataGridView grid, ICollection<int> indexList)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Red;
            diffStyle.ForeColor = Color.White;
            foreach (int item in indexList)
            {
                for (int i = 0; i < grid.ColumnCount; i++)
                {
                    grid.Rows[item].Cells[i].Style = diffStyle;
                }

            }
        }
        public void SetGridViewSortState(DataGridView dgv, DataGridViewColumnSortMode sortMode)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = sortMode;
            }
        }
        private void QueryUserReport()
        {
            if (genSpreadcBox.Checked)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputPath = saveFileDialog.FileName;
                    switch (ctrl.sortMethod)
                    {
                        case SortMethod.CellbyCell:
                            ctrl.ExportMergedTable(outputPath);
                            break;
                        case SortMethod.RowByRow:
                            ctrl.ExportMergedTableWithRowData(outputPath);
                            break;
                        default:
                            break;
                    }
                    if (openSpeadcBox.Checked)
                    {
                        System.Diagnostics.Process.Start(outputPath);
                    }
                }
            }
        }
        private void ProcessDifferences(DataGridView ResultView, ICollection<Cell> collection)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Orange;
            diffStyle.ForeColor = Color.Black;

            foreach (var item in collection)
            {
                ResultView.Rows[item.x].Cells[item.y].Style = diffStyle;
            }
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
        private void DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MergedViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SideBySideGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SideBySideGrid2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void CheckSelections()
        {
            if (ctrl.tableOne != null && ctrl.tableTwo != null)
            {
                sortModeCb.Enabled = true;
            }
            else
            {
                sortModeCb.Enabled = false;
            }
        }

        private void sortModeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((SortMethod)sortModeCb.SelectedIndex)
            {
                case SortMethod.CellbyCell:
                    CompareBtn.Enabled = true;
                    uniqueIdColCb.Visible = false;
                    idLbl.Visible = false;
                    break;
                case SortMethod.RowByRow:
                    CompareBtn.Enabled = false;
                    ColumnNamesforUID();
                    break;
                default:
                    break;
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
                uniqueIdColCb.SelectedIndex = 0;
            }

        }

        private void uniqueIdColCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uniqueIdColCb.SelectedIndex > -1)
            {
                CompareBtn.Enabled = true;
            }
            else
            {
                CompareBtn.Enabled = false;
            }
        }

        private void hasHeader_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.hasHeader = hasHeader.Checked;

            if (ctrl.workbookOne != null)
            {
                ctrl.workbookOne = ctrl.GetWorkBook(docPathOne);
                ctrl.tableOne = ctrl.GetTableByIndex(coSheetsCb.SelectedIndex, ctrl.workbookOne);

            }
            if (ctrl.workbookTwo != null)
            {
                ctrl.workbookTwo = ctrl.GetWorkBook(docPathTwo);
                ctrl.tableTwo = ctrl.GetTableByIndex(toSheetsCb.SelectedIndex, ctrl.workbookTwo);
            }
            ColumnNamesforUID();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!ctrl.ValidateDomain())
            {
                MessageBox.Show("You are not registered to company domain, please contain your system administrator.","Error",MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.SaveConfig();
        }
    }
}

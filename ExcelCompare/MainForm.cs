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
        public SortMethod sortMethod { get; private set; }


        public MainForm()
        {
            InitializeComponent();
            openFileControl1._TextChanged += GetSheetNamesOne;
            openFileControl2._TextChanged += GetSheetNamesTwo;
          
            sortMethod = SortMethod.RowByRow;
            SideBySideGrid1.MouseWheel += ScrollSideOne;

            compareHandler = CompareThreadCompleted;
            ctrl = new FormController(Compare_OnComplete);
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
            ctrl.CompareThreadGo(SortMethod.RowByRow);
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
            if (!File.Exists(this.docPathOne))
                return;
            docOneSheetsList.Items.Clear();
            if (Path.GetExtension(this.docPathOne) == ".xlsx")
            {
                docOneSheetsList.Enabled = true;
                ctrl.workbookOne = this.ctrl.GetWorkBook(docPathOne);
                foreach (DataTable table in ctrl.workbookOne.Tables)
                {
                    docOneSheetsList.Items.Add(table.TableName);
                }
            }
            else
            {
                docOneSheetsList.Enabled = false;
                docOneSheetsList.Items.Add("CSV file selected");
                ctrl.tableOne = ctrl.GetDataTable(docPathOne);
            }
        }
        private void GetSheetNamesTwo(object sender, EventArgs e)
        {
            if (!File.Exists(docPathTwo))
            {
                return;
            }
            docTwoSheetsList.Items.Clear();
            if (Path.GetExtension(docPathTwo) == ".xlsx")
            {
                docTwoSheetsList.Enabled = true;
                ctrl.workbookTwo = ctrl.GetWorkBook(docPathTwo);
                foreach (DataTable table in ctrl.workbookTwo.Tables)
                {
                    docTwoSheetsList.Items.Add((object)table.TableName);
                }
            }
            else
            {
                docTwoSheetsList.Enabled = false;
                docTwoSheetsList.Items.Add("CSV file selected");
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
        private void docOneSheetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (docOneSheetsList.SelectedIndex > -1)
            {
                ctrl.tableOne = ctrl.GetTableByIndex(docOneSheetsList.SelectedIndex, ctrl.workbookOne);
                CheckSelections();
            }
        }
        private void docTwoSheetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (docTwoSheetsList.SelectedIndex > -1)
            {
                ctrl.tableTwo = ctrl.GetTableByIndex(docTwoSheetsList.SelectedIndex, ctrl.workbookTwo);
                CheckSelections();
            }
        }

        private void CompareThreadCompleted()
        {

            if (ctrl.diffrenceCount < 0)
            {
                MessageBox.Show("There are no differences between the two documents");
            }

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

            switch (sortMethod)
            {
                case SortMethod.CellbyCell:
                    ProcessDifferences(MergedViewGrid, ctrl.DiffLocations);
                    break;
                case SortMethod.RowByRow:
                    ProcessDeletedRows(MergedViewGrid, ctrl.differencesID.meDeletedRows);
                    ProcessNewRows(MergedViewGrid, ctrl.differencesID.meAddedRows);
                    ProcessDifferences(MergedViewGrid, ctrl.differencesID.meCells);
                    break;
                default:
                    break;
            }

        }
        private void PushSideBySide()
        {
            SideBySideGrid1.DataSource = ctrl.tableOne;
            SideBySideGrid2.DataSource = ctrl.tableTwo;
            

            switch (sortMethod)
            {
                case SortMethod.CellbyCell:
                    ProcessDifferences(SideBySideGrid1, ctrl.DiffLocations);
                    ProcessDifferences(SideBySideGrid2, ctrl.DiffLocations);
                    break;
                case SortMethod.RowByRow:
                    SideBySideGrid1.DataSource = ctrl.tableOne;
                    ProcessDeletedRows(SideBySideGrid1, ctrl.differencesID.DeletedRows);
                    ProcessDifferences(SideBySideGrid1, ctrl.differencesID.coCells);

                    SideBySideGrid2.DataSource = ctrl.tableTwo;
                    ProcessNewRows(SideBySideGrid2, ctrl.differencesID.AddedRows);
                    ProcessDifferences(SideBySideGrid2, ctrl.differencesID.toCells);
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

            MessageBox.Show(string.Format("There are {0} inconsistent cells.", ctrl.diffrenceCount));
            if (!genSpreadcBox.Checked)
            {
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            outputPath = saveFileDialog.FileName;
            switch (sortMethod)
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
            switch (genSpreadcBox.Checked)
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
                CompareBtn.Enabled = true;
            }
            else
            {
                CompareBtn.Enabled = false;
            }
        }

    }
}

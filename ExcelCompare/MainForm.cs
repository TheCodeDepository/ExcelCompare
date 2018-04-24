﻿using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ExcelCompare
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private FormController ctrl;
        private GridViewController view;

        private delegate void CompareComplete();
        CompareComplete compareHandler;

        public string docPathOne { get { return openFileControl1.FilePath; } }
        public string docPathTwo { get { return openFileControl2.FilePath; } }
        public string outputPath { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            openFileControl1._TextChanged += GetSheetNamesOne;
            openFileControl2._TextChanged += GetSheetNamesTwo;
            coViewGrid.MouseWheel += ScrollSideOne;
            compareHandler = CompareThreadCompleted;
            ctrl = new FormController(Compare_OnComplete);
            hasHeader.Checked = ctrl.hasHeader;

            sortModeCb.SelectedIndex = (int)ctrl.sortMethod;
            genSpreadcBox.Checked = ctrl.GenerateSpreadsheet;
            openSpeadcBox.Checked = ctrl.OpenSpreadsheet;

        }
        private void sheetController_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctrl != null)
            {
                switch (sheetController.SelectedIndex)
                {
                    case 0:
                        view.PushMerged();
                        break;
                    case 1:
                        view.PushSideBySide();
                        break;

                }
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
        private void CompareBtn_Click(object sender, EventArgs e)
        {

            CompareBtn.Enabled = false;
            if (ctrl.AreTablesValid())
            {
                ctrl.CompareThreadGo();

                try
                {
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Ensure the tables start in the top right of the spreadsheet and contain atleast 2 columns and 2 rows. Spreadsheets must contain the same number of columns.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Tables. Please ensure tables have the same number of columns. Tables Should contain more than one Column and Row.");
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
                ctrl.tableOne = ctrl.ReturnFirstDataTable(docPathOne);
                CheckSelections();
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
                ctrl.tableTwo = ctrl.ReturnFirstDataTable(docPathTwo);
                CheckSelections();
            }
        }
        private void SideBySideGrid1_Scroll(object sender, ScrollEventArgs e)
        {
            this.toViewGrid.FirstDisplayedScrollingRowIndex = this.coViewGrid.FirstDisplayedScrollingRowIndex;
            this.toViewGrid.HorizontalScrollingOffset = this.coViewGrid.HorizontalScrollingOffset;
        }
        private void SideBySideGrid2_Scroll(object sender, ScrollEventArgs e)
        {
            this.coViewGrid.FirstDisplayedScrollingRowIndex = this.toViewGrid.FirstDisplayedScrollingRowIndex;
            this.coViewGrid.HorizontalScrollingOffset = this.toViewGrid.HorizontalScrollingOffset;
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
            meViewGrid.DataSource = ctrl.mergedView;
            coViewGrid.DataSource = ctrl.tableOne;
            toViewGrid.DataSource = ctrl.tableTwo;
            view = new GridViewController(meViewGrid,coViewGrid,toViewGrid,ctrl.resultContext);
            view.PushTablesToView();
            QueryUserReport();
            CompareBtn.Enabled = true;
        }       
        private void QueryUserReport()
        {
            if (genSpreadcBox.Checked)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv";     
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    outputPath = saveFileDialog.FileName;
                    ctrl.ExportMergedTable(outputPath);
                    if (openSpeadcBox.Checked)
                    {
                        System.Diagnostics.Process.Start(outputPath);
                    }
                }
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
            meViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            coViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            toViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            CheckSortMethod();
        }
        private void CheckSortMethod()
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
                if (Path.GetExtension(docPathOne).ToLower() == ".xlsx")
                {
                    ctrl.tableOne = ctrl.GetTableByIndex(coSheetsCb.SelectedIndex, ctrl.workbookOne);

                }
                else
                {
                    ctrl.tableOne = ctrl.ReturnFirstDataTable(docPathOne);
                }

            }
            if (ctrl.workbookTwo != null)
            {
                ctrl.workbookTwo = ctrl.GetWorkBook(docPathTwo);
                if (Path.GetExtension(docPathTwo).ToLower() == ".xlsx")
                {
                    ctrl.tableTwo = ctrl.GetTableByIndex(toSheetsCb.SelectedIndex, ctrl.workbookTwo);

                }
                else
                {
                    ctrl.tableTwo = ctrl.ReturnFirstDataTable(docPathTwo);

                }
            }
            ColumnNamesforUID();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!ctrl.isValidDomain())
            {
                MessageBox.Show("You are not registered to company domain, please contain your system administrator.", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrl.SaveConfig();
        }
    }
}

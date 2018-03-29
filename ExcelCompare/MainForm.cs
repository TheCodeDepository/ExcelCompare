using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ExcelCompare
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private FormController ctrl;

        Thread backgroundThread;

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

            sheetController.SelectTab(0);
            SideBySideGrid1.MouseWheel += ScrollSideOne;
            ctrl = new FormController();

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

            compareHandler = CompareThreadCompleted;
            ctrl.CompareComplete += Compare_OnComplete;

            ThreadStart start = new ThreadStart(ctrl.CompareTables);
            backgroundThread = new Thread(start);
            backgroundThread.Start();


        }

        private void Compare_OnComplete(object sender, EventArgs e)
        {
            var send = (FormController)sender;
            if (this.InvokeRequired)
            {
                this.Invoke(compareHandler);
            }
            else
            {
                CompareThreadCompleted();
            }
        }

        private void CompareThreadCompleted()
        {
            if (ctrl.DiffLocations.Count < 0)
            {
                MessageBox.Show("There are no differences bwtween the two documents");
            }


            PushTableToView(MergedViewGrid, ctrl.mergedView);
            PushTableToView(SideBySideGrid1, ctrl.tableOne);
            PushTableToView(SideBySideGrid2, ctrl.tableTwo);
            SetGridViewSortState(MergedViewGrid, DataGridViewColumnSortMode.NotSortable);
            SetGridViewSortState(SideBySideGrid1, DataGridViewColumnSortMode.NotSortable);
            SetGridViewSortState(SideBySideGrid2, DataGridViewColumnSortMode.NotSortable);
            QueryUserReport();

            CompareBtn.Enabled = true;


        }

        private void GetSheetNamesOne(object sender, EventArgs e)
        {
            if (File.Exists(docPathOne))
            {
                docOneSheetsList.Items.Clear();

                if (Path.GetExtension(docPathOne) == ".xlsx")
                {
                    docOneSheetsList.Enabled = true;

                    ctrl.workbookOne = ctrl.GetWorkBook(docPathOne);
            
                    foreach (DataTable item in ctrl.workbookOne.Tables)
                    {
                        docOneSheetsList.Items.Add(item.TableName);
                    }

                }
                else
                {
                    docOneSheetsList.Enabled = false;
                    docOneSheetsList.Items.Add("CSV file selected");
                    ctrl.tableOne = ctrl.GetDataTable(docPathOne);
                }

            }
        }

        private void GetSheetNamesTwo(object sender, EventArgs e)
        {
            if (File.Exists(docPathTwo))
            {
                docTwoSheetsList.Items.Clear();

                if (Path.GetExtension(docPathTwo) == ".xlsx")
                {
                    docTwoSheetsList.Enabled = true;

                    ctrl.workbookTwo = ctrl.GetWorkBook(docPathTwo);
                  
                    foreach (DataTable item in ctrl.workbookTwo.Tables)
                    {
                        docTwoSheetsList.Items.Add(item.TableName);
                    }
                }
                else
                {
                    docTwoSheetsList.Enabled = false;
                    docTwoSheetsList.Items.Add("CSV file selected");
                    ctrl.tableTwo = ctrl.GetDataTable(docPathTwo);
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

            MessageBox.Show($"There are {ctrl.DiffLocations.Count} inconsistent cells.");
            if (genSpreadcBox.Checked)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    outputPath = save.FileName;
                    // reportWorker.RunWorkerAsync();
                }
            }
        }

        private void PushTableToView(DataGridView ResultView, DataTable table)
        {

            ResultView.DataSource = table;

            if (ctrl.DiffLocations.Count > 1)
            {
                ProcessDifferences(ResultView);
            }
        }

        private void ProcessDifferences(DataGridView ResultView)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Green;
            diffStyle.ForeColor = Color.White;

            foreach (var item in ctrl.DiffLocations)
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
                if (ctrl.DiffLocations != null)
                {
                    switch (sheetController.SelectedIndex)
                    {
                        case 0:
                            ProcessDifferences(MergedViewGrid);
                            break;
                        case 1:
                            ProcessDifferences(SideBySideGrid1);
                            ProcessDifferences(SideBySideGrid2);
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

        private void button1_Click(object sender, EventArgs e)
        {

            MergedViewGrid.Refresh();

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

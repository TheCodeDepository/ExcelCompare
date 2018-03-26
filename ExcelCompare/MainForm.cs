using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ComparisonLogic;
using System.Threading;

namespace ExcelCompare
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private BackgroundWorker compareWorker;
        private BackgroundWorker reportWorker;
        private CompareFiles comp;

        public string docPathOne { get { return openFileControl1.FilePath; } }
        public string docPathTwo { get { return openFileControl2.FilePath; } }
        public string outputPath { get; private set; }


        public MainForm()
        {
            InitializeComponent();

            compareWorker = new BackgroundWorker();
            compareWorker.RunWorkerCompleted += CompareWorkerCompleted;
            compareWorker.DoWork += CompareDoWork;

            reportWorker = new BackgroundWorker();
            reportWorker.RunWorkerCompleted += ReportWorkerCompleted;
            reportWorker.DoWork += ReportDoWork;

            openFileControl1._TextChanged += CheckDocumentsEvt;
            openFileControl2._TextChanged += CheckDocumentsEvt;

            sheetController.SelectTab(0);
            SideBySideGrid1.MouseWheel += ScrollSideOne;
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
            comp = new CompareFiles(docPathOne, docPathTwo);
            if (comp.AreFilesinUse())
            {
                MessageBox.Show("Please insure all files involved are closed.");
            }
            else
            {
                comp.OnComplete += Comp_OnComplete;
                Thread thread = new Thread(new ThreadStart(comp.Go));
                thread.Start();

                CompareBtn.Enabled = true;
            }

        }

        private void Comp_OnComplete(object sender, EventArgs e)
        {
            var send = (CompareFiles)sender;
            if (this.InvokeRequired)
            {
                this.Invoke();
            }
            else
            {

            }
        }


        //private void CompareBtn_Click(object sender, EventArgs e)
        //{
        //    CompareBtn.Enabled = false;
        //    comp = new CompareFiles(docPathOne, docPathTwo);
        //    if (comp.AreFilesinUse())
        //    {
        //        MessageBox.Show("Please insure all files involved are closed.");
        //    }
        //    else
        //    {

        //        await compareWorker.RunWorkerAsync();

        //        CompareBtn.Enabled = true;
        //    }

        //}
        private void CheckDocumentsEvt(object sender, EventArgs e)
        {
            bool one = File.Exists(docPathOne);
            bool two = File.Exists(docPathTwo);
            if (one && two)
            {
                CompareBtn.Enabled = true;
            }
            else
            {
                CompareBtn.Enabled = false;
            }
        }

        //Worker Events

        private void CompareDoWork(object sender, DoWorkEventArgs e)
        {
            comp.Go();
        }

        private void CompareThreadCompleted()
        {

            if (comp.DiffLocations.Count > 0)
            {

                PushTableToView(MergedViewGrid, comp.mergedResults);
                PushTableToView(SideBySideGrid1, comp.docOne);
                PushTableToView(SideBySideGrid2, comp.docTwo);
                SetGridViewSortState(MergedViewGrid, DataGridViewColumnSortMode.NotSortable);
                SetGridViewSortState(SideBySideGrid1, DataGridViewColumnSortMode.NotSortable);
                SetGridViewSortState(SideBySideGrid2, DataGridViewColumnSortMode.NotSortable);



                //ScaleWindow();
                QueryUserReport();

            }
            else
            {
                MessageBox.Show($"There are no differences between these documents.");
            }

        }

        public void SetGridViewSortState(DataGridView dgv, DataGridViewColumnSortMode sortMode)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = sortMode;
            }
        }

        private bool cancel = false;
        private void ReportDoWork(object sender, DoWorkEventArgs e)
        {
            bool retry = false;
            do
            {
                try
                {
                    comp.GenerateReport(outputPath);
                    retry = false;
                }
                catch (Exception)
                {
                    var errorMess = MessageBox.Show("Please ensure the all involved documents are closed", "Error", MessageBoxButtons.RetryCancel);
                    if (errorMess == DialogResult.Retry)
                    {
                        retry = true;
                    }
                    else
                    {
                        retry = false;
                        cancel = true;
                        break;
                    }
                }
            } while (retry);
        }

        private void ReportWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            if (!cancel)
            {
                if (openSpeadcBox.Checked)
                {
                    System.Diagnostics.Process.Start(outputPath);
                }
            } 

        }

        private void QueryUserReport()
        {
            MessageBox.Show($"There are {comp.DiffLocations.Count} inconsistent cells.");
            if (genSpreadcBox.Checked)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    outputPath = save.FileName;
                    reportWorker.RunWorkerAsync();
                }
            }
        }

        private void PushTableToView(DataGridView ResultView, DataTable table)
        {
            try
            {
                ResultView.DataSource = table;
            }
            catch (Exception m)
            {
                throw m;
            }
            ProcessDifferences(ResultView);
        }

        private void ProcessDifferences(DataGridView ResultView)
        {
            DataGridViewCellStyle diffStyle = new DataGridViewCellStyle();
            diffStyle.BackColor = Color.Green;
            diffStyle.ForeColor = Color.White;
            foreach (var item in comp.DiffLocations)
            {
                ResultView.Rows[item.Item1].Cells[item.Item2].Style = diffStyle;
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
            if (comp != null)
            {
                if (comp.DiffLocations!=null)
                {
                    switch (sheetController.SelectedIndex)
                    {
                        case 0: ProcessDifferences(MergedViewGrid);
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
    }
}

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace ExcelCompare
{
    public partial class Main : MetroForm
    {
        private BackgroundWorker compareWorker;
        private BackgroundWorker reportWorker;
        private CompareFiles comp;

        public Main()
        {
            InitializeComponent();
            compareWorker = new BackgroundWorker();
            compareWorker.RunWorkerCompleted += CompareWorkerCompleted;
            compareWorker.DoWork += CompareDoWork;

            reportWorker = new BackgroundWorker();
            reportWorker.RunWorkerCompleted += ReportWorkerCompleted;
            reportWorker.DoWork += ReportDoWork;

            FileOne._TextChanged += CheckDocumentsEvt;
            FileTwo._TextChanged += CheckDocumentsEvt;
            Output._TextChanged += CheckDocumentsEvt;
        }

        private void CompareBtn_Click(object sender, EventArgs e)
        {
            //CompareBtn.Enabled = false;
            //comp = new CompareFiles(FileOne.FilePath, FileTwo.FilePath, Output.FilePath);
            //compareWorker.RunWorkerAsync();
        }

        private void CheckDocumentsEvt(object sender, EventArgs e)
        {
            //var w1 = File.Exists(FileOne.FilePath);
            //var w2 = File.Exists(FileTwo.FilePath);
            //var w3 = Output.FilePath != null;
            //if (w1 && w2 && w3)
            //{
            //    CompareBtn.Enabled = true;
            //    return;
            //}
        }

        //Worker Events

        private void ReportDoWork(object sender, DoWorkEventArgs e)
        {
            //bool retry = false;
            //do
            //{
            //    try
            //    {
            //        comp.GenerateReport();
            //    }
            //    catch (Exception)
            //    {
            //        var errorMess = MessageBox.Show("Please ensure the all involved documents are closed", "Error", MessageBoxButtons.RetryCancel);
            //        if (errorMess == DialogResult.Retry)
            //        {
            //            retry = true;
            //        }
            //        else
            //        {
            //            retry = false;
            //        }
            //    }
            //} while (retry);
        }

        private void ReportWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done!");
            this.Enabled = true;

        }


        private void CompareDoWork(object sender, DoWorkEventArgs e)
        {

            comp.Go();

        }

        private void CompareWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UQueryReport();

            PushTableToView(ResultView, comp);
            ScaleWindow();

        }

        private void UQueryReport()
        {
            if (comp.DiffLocations.Count > 0)
            {
                MessageBox.Show($"There are {comp.DiffLocations.Count} inconsistent cells.");
                var tmp = MessageBox.Show("Would you like to genarate a report?", "Generate Report", MessageBoxButtons.YesNo);
                if (tmp == DialogResult.Yes)
                {

                    reportWorker.RunWorkerAsync();
                    System.Diagnostics.Process.Start(Output.FilePath);

                }
            }
            else
            {
                MessageBox.Show($"There are no differences between these documents.");
            }
        }

        private void PushTableToView(DataGridView ResultView, CompareFiles comp)
        {
            ResultView.DataSource = comp.comparisonResult;
            foreach (var item in comp.DiffLocations)
            {
                DataGridViewCellStyle background = new DataGridViewCellStyle();
                background.BackColor = Color.Red;

                ResultView.Rows[item.Item1].Cells[item.Item2].Style = background;
            }

        }

        private void ScaleWindow()
        {
            Rectangle screenHeight = Screen.GetWorkingArea(this);
            this.DesktopLocation = new Point(0, 0);

            this.SetClientSizeCore(screenHeight.Width, (screenHeight.Height - ((screenHeight.Height / 100) * 3)));
            CompareBtn.Enabled = true;
        }
    }
}

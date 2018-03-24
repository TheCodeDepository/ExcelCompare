using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.IO;

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
        //public DataGridView ResultView { get; private set; }

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
            openFileControl1._TextChanged += CheckDocumentsEvt;

        }


        private void CompareBtn_Click(object sender, EventArgs e)
        {
            CompareBtn.Enabled = false;
            comp = new CompareFiles(docPathOne, docPathTwo);
            compareWorker.RunWorkerAsync();
        }

        private void CheckDocumentsEvt(object sender, EventArgs e)
        {
            if (File.Exists(docPathOne) && File.Exists(docPathOne))
            {
                CompareBtn.Enabled = true;
                return;
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

        private void CompareWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (comp.DiffLocations.Count > 0)
            {
                
                //PushTableToView(ResultView, comp);
                ScaleWindow();
                QueryUserReport();

            }
            else
            {
                MessageBox.Show($"There are no differences between these documents.");
            }

        }


        private void ReportDoWork(object sender, DoWorkEventArgs e)
        {
            bool retry = false;
            do
            {
                try{

                    comp.GenerateReport(outputPath);
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
                    }
                }
            } while (retry);


        }

        private void ReportWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            if (openSpeadcBox.Checked)
            {
                System.Diagnostics.Process.Start(outputPath);

            }
            MessageBox.Show("Done");
        }

       

        private void QueryUserReport()
        {
            MessageBox.Show($"There are {comp.DiffLocations.Count} inconsistent cells.");
            if (genSpreadcBox.Checked)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";                
                if (save.ShowDialog() == DialogResult.OK)
                {
                    outputPath = save.FileName;
                    reportWorker.RunWorkerAsync();


                }
            }
        }

        private void PushTableToView(DataGridView ResultView, CompareFiles comp)
        {
            try
            {
                ResultView.DataSource = comp.comparisonResult;

            }
            catch (Exception m)
            {

                throw m;
            }
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

        private void CheckChanged(object sender, EventArgs e)
        {

        }
    }
}

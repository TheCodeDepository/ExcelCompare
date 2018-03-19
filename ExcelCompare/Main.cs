using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExcelCompare
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
         

        }

        private void CompareBtn_Click(object sender, EventArgs e)
        {
            CompareBtn.Enabled = false;
            CheckDocuments.Enabled = false;
            CompareFiles comp = new CompareFiles(FileOne.FilePath, FileTwo.FilePath, Output.FilePath, ".xlsx");
            comp.Compare();
            if (comp.DiffLocations.Count > 0)
            {
                MessageBox.Show($"There are {comp.DiffLocations.Count} inconsistent cells.");
            }
            else
            {
                MessageBox.Show($"There are no differences between these documents.");
            }
            CompareBtn.Enabled = true;
            CheckDocuments.Enabled = true;


        }

        private void CheckDocuments_Click(object sender, EventArgs e)
        {

            if (FileOne.FilePath != null && FileTwo.FilePath != null && Output.FilePath != null)
            { 
                CompareBtn.Enabled = true;
                return;

            }
            MessageBox.Show("Please select a vaild path.");
        }
    }
}

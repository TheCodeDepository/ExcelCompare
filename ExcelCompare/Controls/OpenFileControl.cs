using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.IO;

namespace SpreadsheetCompare
{
    public partial class OpenFileControl : MetroFramework.Controls.MetroUserControl
    {

        public OpenFileControl()
        {
            InitializeComponent();
        }
        public string Title
        {
            get { return label.Text; }
            set { label.Text = value; }

        }
        public string FilePath
        {
            get { return pathTextBox.Text; }
            set { pathTextBox.Text = value; }
        }

        public event EventHandler _TextChanged;
        private void path_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged(this, e);
            }


        }
        private void OpenDialog_Click(object sender, EventArgs e)
        {
            bool retry = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported Types|*.xlsx*.csv|Excel files (*.xlsx)|*.xlsx|CSV files (*.csv)|*.csv";
            openFileDialog.Multiselect = false;
            do
            {
                retry = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(openFileDialog.FileName).ToLower();
                    if (ext == ".xlsx" || ext == ".csv")
                    {
                        FilePath = openFileDialog.FileName;
                    }
                    else
                    {
                        var mess = MessageBox.Show("Invalid file type", "Error", MessageBoxButtons.RetryCancel);
                        if (mess == DialogResult.Retry)
                        {
                            retry = true;
                        }
                    }
                }
            } while (retry);

        }
    }
}

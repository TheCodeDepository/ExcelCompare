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

namespace ExcelCompare
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
            private set { pathTextBox.Text = value; }
        }



        public event EventHandler _TextChanged;
        private void path_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged!=null)
            {
                _TextChanged(this, e);
            }      

            
        }

        private void OpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Supported Types|*.xlsx;*.csv;*.txt|Excel files (*.xlsx)|*.xlsx|CSV files (*.csv)|*.csv|Fixed-Width files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
            }
        }
    }
}

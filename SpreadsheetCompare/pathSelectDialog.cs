using System;
using System.Windows.Forms;
using MetroFramework;

namespace SpreadsheetCompare
{
    public partial class pathSelectDialog : MetroFramework.Controls.MetroUserControl
    {
        public pathSelectDialog()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return labellbl.Text; }
            set { labellbl.Text = value; }

        }

        public string FilePath
        {
            get { return pathTextBox.Text; }
            private set { pathTextBox.Text = value; }
        }

        public event EventHandler _TextChanged;
        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {

            if (_TextChanged != null)
            {
                _TextChanged(this, e);
            }
        }

        private void dialogBtn_Click(object sender, EventArgs e)
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

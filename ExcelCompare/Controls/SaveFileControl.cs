using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelCompare
{
    public partial class SaveFileControl : UserControl
    {
        public SaveFileControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return Label.Text; }
            set { Label.Text = value; }

        }

        public string FilePath
        {
            get { return path.Text; }
            private set { path.Text = value; }
        }


        private void Label_Click(object sender, EventArgs e)
        {

        }

        public event EventHandler _TextChanged;
        private void path_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged(this, e);
            }


        }

        private void SaveDialog_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = saveFileDialog.FileName;
  
            }
        }
    }
}

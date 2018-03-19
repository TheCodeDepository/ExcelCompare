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
    public partial class OpenFileControl : UserControl
    {

        public OpenFileControl()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return Label.Text; }
            set { Label.Text = value; }

        }

        public string FilePath { get; private set; }


        private void Label_Click(object sender, EventArgs e)
        {

        }

        private void path_TextChanged(object sender, EventArgs e)
        {

        }

        private void OpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog.SafeFileName;
                FilePath = openFileDialog.FileName;
            }
        }
    }
}

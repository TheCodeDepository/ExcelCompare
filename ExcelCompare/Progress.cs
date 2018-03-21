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
    public partial class Progress : Form
    {
        public Progress()
        {
            InitializeComponent();
        }

        public int ProgressBarPercentage {
            private get
            {
                return ProgressBar.Value;
            }
            set
            {
                ProgressBar.Value = value;
            }
        }

        private void Progress_Load(object sender, EventArgs e)
        {

        }
    }
}

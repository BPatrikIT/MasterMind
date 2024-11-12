using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMind
{
    public partial class loseScreen : Form
    {
        public loseScreen()
        {
            InitializeComponent();
        }

        private void buttonLose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

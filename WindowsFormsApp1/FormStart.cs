using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void labelBeClient_Click(object sender, EventArgs e)
        {
            Form f = new FormClientLink();
            f.ShowDialog();
        }

        private void labelBeServer_Click(object sender, EventArgs e)
        {
            Form f = new FormServerLink();
            f.ShowDialog();
        }
    }
}

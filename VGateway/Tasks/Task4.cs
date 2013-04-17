using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VGateway.Tasks
{
    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = (int)numericUpDown1.Value % 2 == 0 ? "Sudé" : "Liché";
        }

        private void Task4_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = int.MaxValue;
        }
    }
}

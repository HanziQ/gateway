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
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Compute();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Compute();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Compute();
        }

        private void Compute()
        {
            numericUpDown4.Value = numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value;
        }

        private void Task1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = decimal.MinValue;
            numericUpDown1.Maximum = decimal.MaxValue;
            numericUpDown2.Minimum = decimal.MinValue;
            numericUpDown2.Maximum = decimal.MaxValue;
            numericUpDown3.Minimum = decimal.MinValue;
            numericUpDown3.Maximum = decimal.MaxValue;
            numericUpDown4.Minimum = decimal.MinValue;
            numericUpDown4.Maximum = decimal.MaxValue;
        }
    }
}

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
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (numericUpDown1.Value * 4).ToString();
            textBox2.Text = (numericUpDown1.Value * numericUpDown1.Value).ToString();
        }

        private void Task3_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = (decimal)Math.Floor(Math.Sqrt(int.MaxValue));
        }
    }
}

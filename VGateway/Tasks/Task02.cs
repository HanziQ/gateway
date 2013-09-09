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
    public partial class Task02 : Form
    {
        public Task02()
        {
            InitializeComponent();
        }

        private void Task2_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = int.MaxValue;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, (int)numericUpDown1.Value);
            label1.Text = (ts.Days * 24 + ts.Hours).ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
        }
    }
}

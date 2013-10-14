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
    public partial class Task23 : Form
    {
        double seconds = 0;

        public Task23()
        {
            InitializeComponent();
        }

        private void Task23_Load(object sender, EventArgs e)
        {
            label1.Text = seconds.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            seconds = 0;
            label1.Text = seconds.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds+= 0.1d;
            label1.Text = Math.Round(seconds, 1).ToString("F1");
        }
    }
}

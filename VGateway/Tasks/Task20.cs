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
    public partial class Task20 : Form
    {
        string pwd = "heslo";
        int timer = 15;
        public Task20()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (--timer == 0)
            {
                Close();
            }
            label2.Text = timer.ToString();
        }

        private void Task20_Load(object sender, EventArgs e)
        {
            label2.Text = timer.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == pwd)
            {
                timer1.Enabled = false;
                MessageBox.Show("Správné heslo.");
            }
            else
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}

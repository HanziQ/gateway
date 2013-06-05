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
    public partial class Task8 : Form
    {
        public Task8()
        {
            InitializeComponent();
        }

        private void Task8_Load(object sender, EventArgs e)
        {
            button1.Text = "\u2191";
            button2.Text = "\u2191";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (button1.Text == "\u2191")
            {
                button1.Text = "\u2193";
                label3.Text = "Nepřímá úměrnost";
            }
            else
            {
                button1.Text = "\u2191";
                label3.Text = "Přímá úměrnost";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double a, b, c;
            a = (double)numericUpDown1.Value;
            b = (double)numericUpDown3.Value;
            c = (double)numericUpDown2.Value;
            if (button1.Text == "\u2191")
            {
                textBox1.Text = ((b * c) / a).ToString();
            }
            else
            {
                textBox1.Text = ((b * a) / c).ToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}

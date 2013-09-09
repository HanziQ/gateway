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
    public partial class Task06 : Form
    {
        public Task06()
        {
            InitializeComponent();
        }

        private Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int rand = r.Next(1, 10);
            int num = (int)numericUpDown1.Value;
            if (num == rand)
            {
                label1.Text = "Uhádl jsi!";
            }
            else
            {
                label1.Text = "Neuhádl jsi, číslo bylo: " + rand.ToString();
            }
        }
    }
}

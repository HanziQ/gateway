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
    public partial class Task12 : Form
    {
        public Task12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = textBox1.Text.Trim().Split(' ');
            label3.Text = data[0];
            if(data.Length >= 2)
                label4.Text = data[1];
        }
    }
}

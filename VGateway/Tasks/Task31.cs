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
    public partial class Task31 : Form
    {
        public Task31()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            label1.Text =  Math.Sign(textBox2.Text.Length - textBox1.Text.Length).ToString();
            
        }
    }
}

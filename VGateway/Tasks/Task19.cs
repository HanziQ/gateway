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
    public partial class Task19 : Form
    {
        public Task19()
        {
            InitializeComponent();
        }
        
        private void toolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {
            bool display = toolStripMenuItem1.Checked;
            label2.Visible = display;
            label4.Visible = display;
        }

        private void toolStripMenuItem2_CheckedChanged(object sender, EventArgs e)
        {
            bool display = toolStripMenuItem2.Checked;
            label1.Visible = display;
            label3.Visible = display;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
        }

        private void Task19_Load(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongDateString();
        }
     }
}

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
    public partial class Task32 : Form
    {
        public Task32()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
            this.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
            this.ForeColor = Color.Red;
        }
    }
}

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
    public partial class Task24 : Form
    {
        public Task24()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Task24_Load(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            label1.Text = dateTimePicker1.Value.ToLongDateString() + " " + dateTimePicker2.Value.ToLongTimeString();
        }
    }
}

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
    public partial class Task27 : Form
    {
        public Task27()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Boží soud bude dne " + dateTimePicker1.Value.AddDays(1).AddYears(1).ToLongDateString());
        }
    }
}

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
    public partial class Task29 : Form
    {
        public Task29()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            if (dt1 > dt2)
            {
                DateTime temp = dt1;
                dt1 = dt2;
                dt2 = temp;
            }
            TimeSpan span = dt2 - dt1;
            span = new TimeSpan(span.Hours, span.Minutes, (int)Math.Round(span.Seconds + 0.001d * span.Milliseconds));
            MessageBox.Show("Rozdíl je - " + span.ToString(@"hh\:mm\:ss"));
        }
    }
}

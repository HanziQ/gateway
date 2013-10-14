using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace VGateway.Tasks
{
    public partial class Task21 : Form
    {
        string alarm;

        public Task21()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alarm != null)
            {
                if (alarm.Equals(DateTime.Now.ToLongTimeString()))
                {
                    MessageBox.Show("ALARM");
                    SystemSounds.Beep.Play();
                }
            }
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alarm = dateTimePicker1.Value.ToLongTimeString();
        }

        private void Task21_Load(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}

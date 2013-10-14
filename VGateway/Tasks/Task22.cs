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
    public partial class Task22 : Form
    {
        int seconds;

        public Task22()
        {
            InitializeComponent();
        }

        bool running = false;

        private void button1_Click(object sender, EventArgs e)
        {
            running = !running;
            button1.Text = !running ? "Start" : "Stop";
            if (running)
            {
                seconds = (int)numericUpDown1.Value;
                label1.Text = seconds.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            running = false;
            seconds = (int)numericUpDown1.Value;
            label1.Text = seconds.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (running)
            {
                if (--seconds == 0)
                {
                    running = false;
                    MessageBox.Show("Konec odpočítávání.");
                    SystemSounds.Beep.Play();
                    seconds = (int)numericUpDown1.Value;
                    button1.Text = "Start";
                }

                label1.Text = seconds.ToString();
            }
        }

        private void Task22_Load(object sender, EventArgs e)
        {
            seconds = (int)numericUpDown1.Value;
            label1.Text = seconds.ToString();
        }
    }
}

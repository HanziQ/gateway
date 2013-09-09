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
    public partial class Task04 : Form
    {
        public Task04()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Recalculate();
        }

        private void Recalculate()
        {
            float mass = (float)numericUpDown1.Value;
            float height = (float)numericUpDown2.Value;
            float BMI = mass / (height * height);
            label4.Text = BMI.ToString("F2");
            string text = "";
            if (BMI <= 16.5f)
            {
                text = "těžká podvýživa";
            }
            else if (BMI <= 18.5f)
            {
                text = "podváha";
            }
            else if (BMI <= 25f)
            {
                text = "ideální váha";
            }
            else if (BMI <= 30f)
            {
                text = "nadváha";
            }
            else if (BMI <= 35f)
            {
                text = "mírná obezita";
            }
            else if (BMI <= 40f)
            {
                text = "střední obezita";
            }
            else
            {
                text = "morbidní obezita";
            }
            label5.Text = text;
        }
    }
}

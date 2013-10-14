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
    public partial class Task34 : Form
    {
        public Task34()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = (double)numericUpDown1.Value;
            double b = (double)numericUpDown2.Value;
            MessageBox.Show(Calculate(a, b, textBox1.Text));
        }

        private string Calculate(double a, double b, string op)
        {
            string res = "";
            switch (op)
            {
                case "+": res = (a + b).ToString();
                    break;
                case "-": res = (a - b).ToString();
                    break;
                case "*": res = (a * b).ToString();
                    break;
                case "/":
                    if (b == 0)
                        res = "Nelze dělit nulou.";
                    else
                        res = (a / b).ToString("F2");
                    break;
                default:
                    res = "Chybný operand.";
                    break;

            }
            return res;
        }
    }
}

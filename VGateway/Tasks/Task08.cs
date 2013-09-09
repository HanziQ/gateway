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
    public partial class Task08 : Form
    {
        public Task08()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c;
            a = (double)numericUpDown1.Value;
            if (a == 0)
            {
                MessageBox.Show("a nesmí být nula.");
                return;
            }
            b = (double)numericUpDown2.Value;
            c = (double)numericUpDown3.Value;
            double d = b * b - 4 * a * c;
            if (d > 0)
            {
                double res = (-b + Math.Sqrt(d)) / (2 * a);
                double res2 = (-b - Math.Sqrt(d)) / (2 * a);
                MessageBox.Show(string.Format("Výsledky: {0,8:f4} a {1,8:f4}", res, res2));
            }
            else if (d == 0)
            {
                MessageBox.Show(string.Format("Výsledek: {0,8:f4}", (-b) / (2 * a)));
            }
            else
            {
                double real = (-b) / (2 * a);
                double imag = Math.Sqrt(-d) / (2 * a);
                MessageBox.Show(string.Format("Výsledky: {0,8:f4} + {1,8:f4}i a {2,8:f4} - {3,8:f4}i", real, imag, real, imag));
            }
        }
    }
}

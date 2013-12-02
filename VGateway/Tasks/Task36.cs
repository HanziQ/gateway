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
    public partial class Task36 : Form
    {
        public Task36()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = (int)numericUpDown1.Value;
            int b = (int)numericUpDown2.Value;
            int c = (int)numericUpDown3.Value;
            bool valid = Validate(a, b, c);
            bool right = IsRight(a, b, c);
            MessageBox.Show(valid ? (right ? "Pravoúhlý": "Není pravoúhlý") : "Není trojúhelník.");
        }

        private bool IsRight(int a, int b, int c)
        {
            List<int> l = new List<int>() {a, b, c};
            l.Sort();
            return l[2] * l[2] == l[1] * l[1] + l[0] * l[0];
        }

        private bool Validate(int a, int b, int c)
        {
            return a + b >= c && b + c >= a && c + a >= b;
        }
    }
}

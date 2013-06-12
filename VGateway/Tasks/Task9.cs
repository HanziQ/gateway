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
    enum Operation
    {
        Add, Subtract, Multiply, Divide, None
    }

    public partial class Task9 : Form
    {
        Dictionary<Operation, string> chars = new Dictionary<Operation, string>()
        {
            {Operation.Add, "+"},
            {Operation.Subtract, "-"},
            {Operation.Multiply, "*"},
            {Operation.Divide, "/"}
        };

        int p1a, p1b, p2a, p2b;
        bool ins1 = true;
        bool n1hasDot, n2hasDot;
        Operation op = Operation.None;
        bool hasRes = false;
        float res;

        public Task9()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            textBox1.Text = "";
            op = Operation.None;
            ins1 = true;
            n1hasDot = n2hasDot = false;
            p1a = p1b = p2a = p2b = 0;
            hasRes = false;
            res = 0;
            UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            textBox1.Text = p1a.ToString() + (n1hasDot ? ("." + p1b.ToString()) : "") + (op != Operation.None ? (" " + chars[op] + " " + p2a.ToString() + (n2hasDot ? ("." + p2b.ToString()) : "")) : "");
            if (hasRes && op != Operation.None)
            {
                res = GetN1();
                float n2 = GetN2();                
                switch (op)
                {
                    case Operation.Add:
                        res += n2;
                        break;
                    case Operation.Subtract:
                        res -= n2;
                        break;
                    case Operation.Multiply:
                        res *= n2;
                        break;
                    case Operation.Divide:
                        if (n2 == 0)
                        {
                            MessageBox.Show("Nemůžete dělit nulou.");
                            Reset();
                            return;
                        }
                        res /= n2;
                        break;
                }
                textBox1.Text += " = " + res.ToString();
            }
        }

        private float GetN1()
        {
            float n = (float)p1a;
            if (n1hasDot)
            {
                n += (float)p1b * (float)Math.Pow(10, -p1b.ToString().Length);
            }
            return n;
        }

        private float GetN2()
        {
            float n = (float)p2a;
            if (n2hasDot)
            {
                n += (float)p2b * (float)Math.Pow(10, -p2b.ToString().Length);
            }
            return n;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ins1)
            {
                if (!n1hasDot)
                {
                    n1hasDot = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hasRes = true;
            UpdateTextBox();
        }

        private void AddNum(int num)
        {
            if (ins1)
            {
                if (n1hasDot)
                {
                    p1b *= 10;
                    p1b += num;
                }
                else
                {
                    p1a *= 10;
                    p1a += num;
                }
            }
            else
            {
                if (n2hasDot)
                {
                    p2b *= 10;
                    p2b += num;
                }
                else
                {
                    p2a *= 10;
                    p2a += num;
                }
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (hasRes)
                Reset();
            AddNum(int.Parse(((Button)sender).Text));
            UpdateTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hasRes)
            {
                p2a = p2b = 0;
                p1a = (int)Math.Floor(res);
                p1b = (int)(res - p1a);
                p1b *= (int)Math.Pow(10, p1b.ToString().Length);
                hasRes = false;
                op = Operation.Add;
                UpdateTextBox();
            }
            if (ins1)
            {
                ins1 = false;
                op = Operation.Add;
                UpdateTextBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (hasRes)
            {
                p2a = p2b = 0;
                p1a = (int)Math.Floor(res);
                p1b = (int)(res - p1a);
                p1b *= (int)Math.Pow(10, p1b.ToString().Length);
                hasRes = false;
                op = Operation.Subtract;
                UpdateTextBox();
            }
            if (ins1)
            {
                ins1 = false;
                op = Operation.Subtract;
                UpdateTextBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hasRes)
            {
                p2a = p2b = 0;
                p1a = (int)Math.Floor(res);
                p1b = (int)(res - p1a);
                p1b *= (int)Math.Pow(10, p1b.ToString().Length);
                hasRes = false;
                op = Operation.Multiply;
                UpdateTextBox();
            }
            if (ins1)
            {
                ins1 = false;
                op = Operation.Multiply;
                UpdateTextBox();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (hasRes)
            {
                p2a = p2b = 0;
                p1a = (int)Math.Floor(res);
                p1b = (int)(res - p1a);
                p1b *= (int)Math.Pow(10, p1b.ToString().Length);
                hasRes = false;
                op = Operation.Divide;
                UpdateTextBox();
            }
            if (ins1)
            {
                ins1 = false;
                op = Operation.Divide;
                UpdateTextBox();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ins1)
            {
                p1a = -p1a;
            }
            else
            {
                p2a = -p2a;
            }
            UpdateTextBox();
        }
    }
}

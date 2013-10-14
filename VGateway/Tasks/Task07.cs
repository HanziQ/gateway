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
    public partial class Task07 : Form
    {
        public Task07()
        {
            InitializeComponent();
        }

        Random r = new Random();

        private void Task07_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
            label1.Text = r.Next(20).ToString();
            label2.Text = r.Next(20).ToString() + " = ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string op = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked).Text;
            int val, v1, v2;
            v1 = int.Parse(label1.Text);
            v2 = int.Parse(label2.Text.Substring(0, label2.Text.Length - 2));
            switch (op)
            {
                case "+":
                    val = v1 + v2;
                    break;
                case "-":
                    val = v1 - v2;
                    break;
                case "*":
                    val = v1 * v2;
                    break;
                case "/":
                    val = v1 / v2;
                    break;
                default:
                    val = 0;
                    break;
            }
            if (val.ToString() == textBox1.Text)
            {
                MessageBox.Show("Správně!");
                label1.Text = r.Next(20).ToString();
                label2.Text = r.Next(20).ToString() + " = ";
            }
            else
            {
                MessageBox.Show("Chyba, správná odpověd je: '" + val.ToString() + "'");
                label1.Text = r.Next(20).ToString();
                label2.Text = r.Next(20).ToString() + " = ";
            }
        }
    }
}

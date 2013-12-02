using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VGateway.Tasks
{
    public partial class Task39 : Form
    {
        enum Op
        {
            Add,
            Sub,
            Mul,
            Div,
            None
        }

        public Task39()
        {
            InitializeComponent();
        }

        Dictionary<Op, string> signs = new Dictionary<Op, string>()
        {
            {Op.Add, "+"},
            {Op.Sub, "-"},
            {Op.Mul, "*"},
            {Op.Div, "/"}
        };

        Random r = new Random();
        List<string> arr = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            int min = (int)numericUpDown1.Value;
            int max = (int)numericUpDown2.Value + 1;
            int count = (int)numericUpDown3.Value;
            if (count == 0)
                return;
            if (max < min)
            {
                MessageBox.Show("Maximum musí být větší nebo rovno než minimum.");
                return;
            }
            if (max == 1)
            {
                MessageBox.Show("Maximum nesmí být nula.");
                return;
            }
            
            bool add = checkBox1.Checked;
            bool sub = checkBox2.Checked;
            bool mul = checkBox3.Checked;
            bool div = checkBox4.Checked;
            arr = new List<string>();
            for (int i = 0; i < count; i++)
            {
                Op o = randOp(add, sub, mul, div);
                if (o == Op.None)
                {
                    MessageBox.Show("Musíte vybrat nějakou operaci.");
                    return;
                }


                int a = r.Next(min, max);
                int b;
                do {
                b = r.Next(min, max);
                }
                while(o == Op.Div && b == 0);
                arr.Add(a.ToString() + " " + signs[o] + " " + b.ToString());
            }
            saveFileDialog1.ShowDialog();
        }

        private Op randOp(bool add, bool sub, bool mul, bool div)
        {
            List<Op> ops = new List<Op>();
            if (add)
                ops.Add(Op.Add);
            if (sub)
                ops.Add(Op.Sub);
            if (mul)
                ops.Add(Op.Mul);
            if (div)
                ops.Add(Op.Div);
            if (ops.Count == 0)
                return Op.None;
             return ops[r.Next(ops.Count)];
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllLines(saveFileDialog1.FileName, arr);
        }

        private void Task39_Load(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
        }
    }
}

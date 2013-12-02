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
    public partial class Task35 : Form
    {
        public Task35()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Generate((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value).ForEach((x) => { listBox1.Items.Add(x); });
        }
        private List<int> Generate(int from, int to, int count)
        {            
            Random r = new Random();
            List<int> arr = new List<int>();

            if (to <= from || to - from < count)
            {
                return arr;
            }

            for (int i = 0; i < count; i++)
            {
                int k;
                do {
                    k = r.Next(from, to);
                } while(arr.Contains(k));
                arr.Add(k);
            }
            return arr;
        }

        private void Task35_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}

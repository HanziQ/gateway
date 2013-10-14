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
    public partial class Task25 : Form
    {
        public Task25()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Reload();
        }

        private void Task25_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            DateTime dt = new DateTime(2004, 1, 1);
            listBox1.Items.Clear();
            int count = (int)numericUpDown1.Value;
            for (int i = 0; i < count; i++)
            {
                dt = dt.AddDays(10);
                listBox1.Items.Add(dt.ToLongDateString());
            }
        }
    }
}

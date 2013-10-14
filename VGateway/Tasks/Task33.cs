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
    public partial class Task33 : Form
    {
        public Task33()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for(int i = (int)numericUpDown1.Value; i <= numericUpDown2.Value; i+= (int)numericUpDown3.Value)
            {
                sum += i;
            }
            MessageBox.Show(sum.ToString());
        }
    }
}

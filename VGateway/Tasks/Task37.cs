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
    public partial class Task37 : Form
    {
        public Task37()
        {
            InitializeComponent();
        }

        private void Task37_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
            
        }
    }
}

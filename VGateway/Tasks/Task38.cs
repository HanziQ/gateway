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
    public partial class Task38 : Form
    {
        public Task38()
        {
            InitializeComponent();
        }

        private void Task38_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "-copy" + Path.GetExtension(openFileDialog1.FileName), File.ReadAllText(openFileDialog1.FileName, Encoding.Default) + Environment.NewLine + "DALŠÍ TEXT");
            Close();
        }
    }
}

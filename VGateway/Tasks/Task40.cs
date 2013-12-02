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
    public partial class Task40 : Form
    {
        public Task40()
        {
            InitializeComponent();
        }

        private void Task40_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.ShowDialog();
        }

        string[] lines2;

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] lines = File.ReadAllLines(openFileDialog1.FileName, Encoding.Default);
            lines2 = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineData = lines[i].Split(',');
                lines2[i] = lineData[0] + "," + computeAge(lineData[1]);
            }

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
        }

        private int computeAge(string date)
        {
            DateTime dt = DateTime.Parse(date);
            return (int)((DateTime.Now - dt).TotalDays / 365f);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllLines(saveFileDialog1.FileName, lines2);
        }
    }
}

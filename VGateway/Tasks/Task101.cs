using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VGateway.Tasks
{
    public partial class Task101 : Form
    {
        public Task101()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = Interaction.InputBox("Zadejte text.", "Zadejte text");
            if (string.IsNullOrWhiteSpace(text))
                return;
            if (listBox1.Items.Contains(text))
                return;
            listBox1.Items.Add(text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndices[i]]);
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = listBox2.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Add(listBox2.Items[listBox2.SelectedIndices[i]]);
                listBox2.Items.RemoveAt(listBox2.SelectedIndices[i]);
            }
        }
    }
}

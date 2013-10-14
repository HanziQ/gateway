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
    public partial class Task15 : Form
    {


        //12;37
        int width = 5;
        int height = 5;

        int GRID = 30;
        int OFFSET_X = 12;
        int OFFSET_Y = 37;

        Font stringFont = new Font(FontFamily.GenericSansSerif, 10);


        Matrix matrix;

        public Task15()
        {
            InitializeComponent();
        }

        private void Task15_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;  
            matrix = Matrix.GenerateRandom(width, height);
        }

        protected override void  OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    g.DrawString(matrix[i][j].ToString(), stringFont, Brushes.Black, i * GRID + OFFSET_X, j * GRID + OFFSET_Y);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            width = (int)numericUpDown1.Value;
            height = (int)numericUpDown2.Value;
            matrix = Matrix.GenerateRandom(width, height);
            Invalidate();
        }
    }
}

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
    public partial class Task18 : Form
    {


        //12;37
        int N = 5;

        int GRID = 30;
        int OFFSET_X = 12;
        int OFFSET_Y = 37;

        Font stringFont = new Font(FontFamily.GenericSansSerif, 10);


        Matrix matrix;

        public Task18()
        {
            InitializeComponent();
        }

        private void Task18_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            matrix = Matrix.GenerateDiagonal(N);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    g.DrawString(matrix[i][j].ToString(), stringFont, Brushes.Black, i * GRID + OFFSET_X, j * GRID + OFFSET_Y);
                }               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            N = (int)numericUpDown1.Value;
            matrix = Matrix.GenerateDiagonal(N);
            Invalidate();
        }
    }
}

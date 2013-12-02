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
    public partial class Task48 : Form
    {
        public Task48()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            double parameter = (Math.PI * (double)DateTime.Now.Millisecond) / 500d;
            int height = 100 + (int)(40 * Math.Sin(parameter));
            int width = 50 + (int)(20 * Math.Cos(parameter));

            Point Org = new Point(150 + (int)(100 * Math.Sin(parameter)), 150 +(int)(100 * Math.Cos(parameter)));
            drawCuboid(g, width, height, Org);

            Font f = new Font(FontFamily.GenericSansSerif, 10);
            Brush b = Brushes.Black;

            g.DrawString("V = a * b * c", f, b, new PointF(5, 5));
            g.DrawString("S = 2 * ( ab + bc + ca )", f, b, new PointF(5, 25));

            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            UpdateCubes();

            foreach (Cube c in cubes)
            {
                drawCuboid(e.Graphics, c.size, c.size, c.pos);
                //g.DrawRectangle(new Pen(Color.Red, 1f),c.bb);
            }
            Font f = new Font(FontFamily.GenericSansSerif, 10);
            Brush b = Brushes.Black;

            g.DrawString("V = a^3", f, b, new PointF(5, 5));
            g.DrawString("S = 6 * a^2", f, b, new PointF(5, 25));
        }

        DateTime last = DateTime.Now;

        private void UpdateCubes()
        {
            double delta = (DateTime.Now - last).TotalSeconds;
            last = DateTime.Now;

            foreach (Cube c in cubes)
            {
                double rad = (Math.PI * c.angle) / 180d;
                c.pos.X += (int)(Math.Cos(rad) * c.speed);
                c.pos.Y += (int)(Math.Sin(rad) * c.speed);
                c.bb = new Rectangle(c.pos.X, c.pos.Y - c.size / 2, c.size + c.size / 2, c.size + c.size / 2);

                if (c.bb.Left <= 0 || c.bb.Right >= panel2.Width)
                {
                    c.angle = 180 - c.angle;
                }
                if (c.bb.Top <= 0 || c.bb.Bottom >= panel2.Height)
                {
                    c.angle = 360 - c.angle;
                }
            }
        }

        private void drawCuboid(Graphics g, int width, int height, Point position)
        {
            double parameter = (Math.PI * (double)DateTime.Now.Millisecond) / 500d;
            Pen pencil = new Pen(Color.Blue, 1f);
            Rectangle R = new Rectangle(position.X, position.Y, width, height);

            g.DrawRectangle(pencil, R);
            g.DrawLine(pencil, position.X, position.Y, position.X + width / 2, position.Y - height / 2); // /#
            g.DrawLine(pencil, position.X + width, position.Y, position.X + width / 2 + width, position.Y - height / 2); // #/
            g.DrawLine(pencil, position.X + width / 2, position.Y - height / 2, position.X + width + width / 2, position.Y - height / 2); // top _
            g.DrawLine(pencil, position.X + width, position.Y + height, position.X + width + width / 2, position.Y + height - height / 2); // bottom /
            g.DrawLine(pencil, position.X + width + width / 2, position.Y - height / 2, position.X + width + width / 2, position.Y + height - height / 2); // right
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            double parameter = (Math.PI * (double)DateTime.Now.Millisecond) / 500d;
            int height = 100 + (int)(40 * Math.Sin(parameter));
            int width = 50 + (int)(20 * Math.Cos(parameter));
            Point Org = new Point(150 + (int)(100 * Math.Sin(parameter)), 150 + (int)(100 * Math.Cos(parameter)));
            Pen pencil = new Pen(Color.Blue, 1f);
            g.DrawEllipse(pencil, Org.X, Org.Y, width, height / 4f);
            g.DrawEllipse(pencil, Org.X, Org.Y + height, width, height / 4f);
            g.DrawLine(pencil, Org.X, Org.Y + height / 8, Org.X , Org.Y + 9 * height/ 8);
            g.DrawLine(pencil, Org.X + width , Org.Y + height / 8, Org.X + width , Org.Y + 9 * height / 8);

            Font f = new Font(FontFamily.GenericSansSerif, 10);
            Brush b = Brushes.Black;

            g.DrawString("V = PI * r^2 * v", f, b, new PointF(5, 5));
            g.DrawString("S = 2 * PI * r * (r + h)", f, b, new PointF(5, 25));
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            double parameter = (Math.PI * (double)DateTime.Now.Millisecond) / 500d;
            int height = 100 + (int)(40 * Math.Sin(parameter));
            int width = 50 + (int)(20 * Math.Cos(parameter));
            Point Org = new Point(150 + (int)(100 * Math.Sin(parameter)), 150 + (int)(100 * Math.Cos(parameter)));
            Pen pencil = new Pen(Color.Blue, 1f);
            g.DrawEllipse(pencil, Org.X, Org.Y + height, width, height / 4f);
            g.DrawLine(pencil, Org.X + width/ 2, Org.Y + height / 8, Org.X, Org.Y + 9 * height / 8);
            g.DrawLine(pencil, Org.X + width / 2, Org.Y + height / 8, Org.X + width, Org.Y + 9 * height / 8);

            Font f = new Font(FontFamily.GenericSansSerif, 10);
            Brush b = Brushes.Black;

            g.DrawString("V = (PI * r^2 * v) / 3", f, b, new PointF(5, 5));
            g.DrawString("S = PI * r * (r + s)", f, b, new PointF(5, 25));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
            panel2.Invalidate();
            panel3.Invalidate();
            panel4.Invalidate();
        }

        class Cube
        {
            public Point pos = new Point();
            public int speed;
            public double angle;
            public Rectangle bb;
            public int size;
        }

        List<Cube> cubes = new List<Cube>();

        private void Task48_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                Cube c = new Cube();
                c.size = r.Next(25, 75);
                c.pos.X = r.Next(5, panel2.Width - c.size - 5);
                c.pos.Y = r.Next(5, panel2.Height - c.size - 5);
                c.angle = r.Next(360);
                c.speed = r.Next(5, 25);
                c.bb = new Rectangle(c.pos.X, c.pos.Y - c.size / 2, c.size + c.size / 2, c.size + c.size / 2);
                cubes.Add(c);
            }
        }
    }
}

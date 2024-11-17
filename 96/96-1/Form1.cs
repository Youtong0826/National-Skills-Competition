using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _96_1
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Point> pts;
        double n45_Len = 0, on45_Len = 0;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pts.Count < 3) return;
            g.Clear(Color.White);
            drawPoints();

            var a = Math.Abs(pts[0].Y - pts[1].Y);
            var target = new Point(pts[1].X > pts[0].X ? pts[0].X + a : pts[0].X - a, pts[1].Y);
            on45_Len = 0;

            Console.WriteLine($"{pts[0].X} {pts[0].Y}");
            Console.WriteLine($"{pts[1].X} {pts[1].Y}");
            Console.WriteLine($"{pts[2].X} {pts[2].Y}");
            Console.WriteLine(!((pts[0].X < pts[1].X) ^ (pts[0].X > pts[2].X)));

            if (((target.X > pts[1].X) ^ (pts[0].X < pts[1].X)) && ((pts[0].X < pts[1].X) ^ (pts[0].X > pts[2].X))) {
                g.DrawLine(new Pen(Color.Black), pts[0], target);
                g.DrawLine(new Pen(Color.Black), pts[1], target);
                on45_Len += getDistance(pts[0], target) + getDistance(pts[1], target);
            }
            else
            {
                g.DrawLine(new Pen(Color.Black), pts[0], new Point(pts[0].X, pts[1].Y));
                g.DrawLine(new Pen(Color.Black), pts[1], new Point(pts[0].X, pts[1].Y));
                on45_Len += Math.Abs(pts[0].Y - pts[1].Y) + Math.Abs(pts[0].X - pts[1].X);
            }

            a = Math.Abs(pts[2].Y - pts[1].Y);
            target = new Point(pts[1].X > pts[2].X ? pts[2].X + a : pts[2].X - a, pts[1].Y);

            if ((target.X > pts[1].X) ^ (pts[2].X < pts[1].X) && ((pts[2].X < pts[1].X) ^ (pts[2].X > pts[0].X)))
            {
                g.DrawLine(new Pen(Color.Black), pts[2], target);
                g.DrawLine(new Pen(Color.Black), pts[1], target);
                on45_Len += getDistance(pts[2], target) + getDistance(pts[1], target);
            }

            else
            {
                g.DrawLine(new Pen(Color.Black), pts[2], new Point(pts[2].X, pts[1].Y));
                g.DrawLine(new Pen(Color.Black), pts[1], new Point(pts[2].X, pts[1].Y));
                on45_Len += Math.Abs(pts[2].Y - pts[1].Y) + Math.Abs(pts[2].X - pts[1].X);
            }

            label1.Text = $"Non-45 Length: {n45_Len}";
            label2.Text = $"on-45 Length: {on45_Len:0.00}";
            label3.Text = $"Saving: {n45_Len - on45_Len:0.00}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pts = new List<Point>();
            var rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                pts.Add(new Point(rnd.Next(30, 300), rnd.Next(30, 300)));
                g.FillRectangle(Brushes.Blue, pts[i].X - 2, pts[i].Y - 2, 4, 4);
            }

            pts.Sort((A, B) => A.Y.CompareTo(B.Y));

            g.DrawLine(new Pen(Color.Black), pts[0], new Point(pts[0].X, pts[1].Y));
            g.DrawLine(new Pen(Color.Black), pts[2], new Point(pts[2].X, pts[1].Y));
            g.DrawLine(new Pen(Color.Black), pts[1], new Point(pts[0].X, pts[1].Y));
            g.DrawLine(new Pen(Color.Black), pts[1], new Point(pts[2].X, pts[1].Y));

            n45_Len = Math.Abs(pts[1].Y - pts[0].Y)
                    + Math.Abs(pts[1].Y - pts[2].Y)
                    + Math.Abs(pts[1].X - pts[0].X)
                    + Math.Abs(pts[1].X - pts[2].X);

            label1.Text = $"Non-45 Length: {n45_Len}";
            label2.Text = $"on-45 Length: {0:0.00}";
            label3.Text = $"Saving: {0:0.00}";
        }

        void drawPoints()
        {
            for (int i = 0; i < 3; i++)
            {
                g.FillRectangle(Brushes.Blue, pts[i].X - 2, pts[i].Y - 2, 4, 4);
            }
        }

        private double getDistance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
    }
}

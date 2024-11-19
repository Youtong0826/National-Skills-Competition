using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using static System.Math;
using static System.Console;
using static System.Convert;
using static System.Environment;

namespace _100_1
{
    public partial class Form1 : Form
    {
        int N; string C;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            var N = ToInt32(textBox1.Text);

            Dictionary<string, Brush> mp = new Dictionary<string, Brush>
            {
                { "B", Brushes.Black},
                { "R", Brushes.Red},
                { "G", Brushes.Green},
                { "L", Brushes.Blue},
            };

            float X = panel1.Width / 2, Y = panel1.Height / 2, R = 200f;
            List<PointF> pts = new List<PointF>();
            WriteLine(R * Cos(360d / N) + X);
            WriteLine(R * Sin(360d / N) + Y);
            for (int i = 1; i <= N; i++)
            {
                // g.FillRectangle(Brushes.Blue, R * (float)Cos(2 * PI * i / N) + X, R * (float)Sin(2 * PI * i / N) + Y, 5, 5);
                pts.Add(new PointF(R * (float)Cos(2 * PI * i / N) + X, (R * (float)Sin(2 * PI * i / N) + Y)));
            }

            foreach (var p in pts)
            {
                foreach (var p2 in pts)
                {
                    g.DrawLine(new Pen(mp[textBox2.Text]), p, p2);
                }
            }
        }
    }
}

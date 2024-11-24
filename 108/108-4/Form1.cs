using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _108_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
            panel2.Paint += panel2_Paint;
            label1.Visible = false;
        }

        private void draw()
        {
            var g = panel1.CreateGraphics(); 
            g.Clear(Color.White);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(new Pen(Brushes.Black, 2), i * 20 + 10, 10, i * 20 + 10, 190);
                g.DrawLine(new Pen(Brushes.Black, 2), 10, i * 20 + 10, 190, i * 20 + 10);
            }
        }

        private bool inside(int x, int y)
        {
            return x >= 0 && x <= 9 && y >= 0 && y <= 9;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            draw();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            var g = panel2.CreateGraphics();
            g.FillEllipse(Brushes.Black, 0, 0, 12, 12);
            g.DrawEllipse(new Pen(Brushes.Blue, 2), 1, 17, 10, 10);
            g.DrawRectangle(new Pen(Brushes.Red, 2), 2, 35, 10, 10);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            draw();
            var g = panel1.CreateGraphics();
            bool[,] mp = new bool[10, 10];
            var rnd = new Random();
            List<Tuple<int, int>> lis = new List<Tuple<int, int>>();
            // draw();
            for (int i = 0; i < 32; i++)
            {
                int x = rnd.Next(0, 9), y = rnd.Next(0, 9);
                lis.Add(new Tuple<int, int>(x, y));
                mp[x, y] = true;
                g.FillEllipse(Brushes.Black, x * 20 + 5, y * 20 + 5, 10, 10);
            }

            int sx = rnd.Next(0, 9), sy = rnd.Next(0, 9), ex = rnd.Next(0, 9), ey = rnd.Next(0, 9);
            while (mp[sx, sy])
            {
                sx = rnd.Next(0, 9); sy = rnd.Next(0, 9);
            }

            while (mp[ex, ey] || (ex == sx && ey == sy))
            {
                ex = rnd.Next(0, 9); ey = rnd.Next(0, 9);
            }

            g.DrawEllipse(new Pen(Brushes.Blue, 2), sx * 20 + 5, sy * 20 + 5, 10, 10);
            g.DrawRectangle(new Pen(Brushes.Red, 2), ex * 20 + 5, ey * 20 + 5, 10, 10);

            Console.WriteLine($"start {sx} {sy}");
            Console.WriteLine($"end {ex} {ey}");

            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
            Tuple<int, int>[,] last = new Tuple<int, int>[10, 10];
            bool[,] vis = new bool[10, 10];
            int[,] dir = { {0,1 }, {1, 0}, {-1, 0 }, {0, -1}};
            q.Enqueue(new Tuple<int, int>(sx, sy));
            while (q.Count > 0)
            {
                var top = q.Dequeue();
                int x = top.Item1, y = top.Item2;
                if (vis[x, y]) continue;
                // Console.WriteLine($"{x}, {y}");
                vis[x, y] = true;
                for (int i = 0; i < 4; i++)
                {
                    int dx = x + dir[i, 0], dy = y + dir[i, 1];
                    if (inside(dx, dy) && !vis[dx, dy] && !mp[dx, dy])
                    {
                        var t = new Tuple<int, int>(dx, dy);
                        last[dx, dy] = top;
                        if (dx == ex && dy == ey)
                        {
                            var l = last[dx, dy];
                            int px = l.Item1, py = l.Item2;
                            while (px != sx || py != sy)
                            {
                                g.DrawLine(new Pen(Brushes.Blue, 3), dx * 20 + 10, dy * 20 + 10, px * 20 + 10, py * 20 + 10);
                                dx = px;  
                                dy = py;
                                l = last[dx, dy];
                                px = l.Item1; 
                                py = l.Item2;
                            }
                            g.DrawLine(new Pen(Brushes.Blue, 3), dx * 20 + 10, dy * 20 + 10, px * 20 + 10, py * 20 + 10);
                            g.DrawEllipse(new Pen(Brushes.Blue, 2), sx * 20 + 5, sy * 20 + 5, 10, 10);
                            g.DrawRectangle(new Pen(Brushes.Red, 2), ex * 20 + 5, ey * 20 + 5, 10, 10);
                            g.FillEllipse(Brushes.White, sx * 20 + 6, sy * 20 + 6, 7.5f, 7.5f);
                            g.FillRectangle(Brushes.White, ex * 20 + 6, ey * 20 + 6, 7.5f, 7.5f);
                            label1.Visible = true;
                            label1.Text = "路徑規劃成功";
                            return;
                        }
                        q.Enqueue(t);
                    }
                }
            }

            label1.Visible = true;
            label1.Text = "路徑規劃失敗";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            draw();
        }
    }
}

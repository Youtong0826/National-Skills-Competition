using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _112_5
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<int>[] pts = new List<int>[4];
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            Console.WriteLine(panel1.Width);
            Console.WriteLine(panel1.Height);
        }
        private bool inside(int x, int y, int s1, int t1, int s2, int t2)
        {
            return x < s2 && x > s1 && y < t2 && y > t1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //600 300
            g.Clear(Color.White);
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                int x = rnd.Next(0, 340), y = rnd.Next(0, 130), r = rnd.Next(60, 100);

                pts[i] = new List<int>();
                pts[i].Add(x);
                pts[i].Add(y);
                pts[i].Add(r);

                g.DrawLine(new Pen(Brushes.Black), x, y, x + r, y);
                g.DrawLine(new Pen(Brushes.Black), x, y, x, y + r);
                g.DrawLine(new Pen(Brushes.Black), x + r, y + r, x + r, y);
                g.DrawLine(new Pen(Brushes.Black), x + r, y + r, x, y + r);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= panel1.Width; i++)
            {
                for (int j = 0; j <= panel1.Height; j++)
                {
                    int cnt = 0;
                    foreach (var pt in pts)
                    {
                        if (inside(i, j, pt[0], pt[1], pt[0] + pt[2], pt[1] + pt[2]))
                        {
                            cnt++;
                        }
                    }

                    if (cnt >= 2)
                    {
                        g.FillRectangle(Brushes.Pink, new Rectangle(i, j, 1, 1));
                    }
                }
            }
        }
    }
}

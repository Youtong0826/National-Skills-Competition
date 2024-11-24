using System;
using System.Collections;
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
using static System.Console;
using static System.Convert;
using static System.Environment;
using static System.Math;
using static System.Linq.Enumerable;

namespace _110_1
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool[,] mp = new bool[11, 11];
        List<Tuple<int, int>> list = new List<Tuple<int, int>>();
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void draw()
        {
            foreach (var item in list)
            {
                int x = item.Item1, y = item.Item2;
                g.FillEllipse(Brushes.Black, x * 20 + 5, y * 20 + 5, 9, 9);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            list.Clear();
            for (int i = 0; i < 11; i++) for (int j = 0; j < 11; j++) mp[i, j] = false;
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(new Pen(Brushes.Black, 2), 10, i * 20 + 10, 190, i * 20 + 10);
                g.DrawLine(new Pen(Brushes.Black, 2), i * 20 + 10, 10, i * 20 + 10, 190);
            }

            var rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                int x = rnd.Next(0, 9), y = rnd.Next(0, 9);
                mp[x, y] = true;
                list.Add(new Tuple<int, int>(x, y));
            }
            draw();
        }

        private bool inside(int x, int y)
        {
            return x >= 0 && x <= 9 && y >= 0 && y <= 9;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            var mid = list[3];
            int mn = int.MaxValue, mx = int.MinValue, sum = 0;
            int[] draw_up = new int[10], draw_down = new int[10];
            for (int i = 0; i < 10; i++) draw_up[i] = draw_down[i] = mid.Item2;    
            foreach ( var item in list )
            {
                g.DrawLine(new Pen(Brushes.Red, 3), item.Item1 * 20 + 10, item.Item2 * 20 + 10, item.Item1 * 20 + 10, mid.Item2 * 20 + 10);
                if (item.Item2 > draw_up[item.Item1]) 
                {
                    sum += Math.Abs(item.Item2 - draw_up[item.Item1]);
                    draw_up[item.Item1] = item.Item2;
                } 
                else if (item.Item2 < draw_down[item.Item1]) {
                    sum += Math.Abs(item.Item2 - draw_down[item.Item1]);
                    draw_down[item.Item1] = item.Item2;
                }
                mn = Math.Min(mn, item.Item1);
                mx = Math.Max(mx, item.Item1);
            }
            sum += Math.Abs(mn - mx);
            g.DrawLine(new Pen(Brushes.Red, 3), mn * 20 + 10, mid.Item2 * 20 + 10, mx * 20 + 10, mid.Item2 * 20 + 10);
            textBox1.Text = $"{sum}";
            draw();
        }
    }
}

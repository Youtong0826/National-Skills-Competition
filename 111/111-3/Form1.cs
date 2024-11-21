using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _111_3
{
    public partial class Form1 : Form
    {
        Graphics g1, g2;
        Brush[,] mp = new Brush[4, 4]; 
        public Form1()
        {
            InitializeComponent();
            g1 = panel1.CreateGraphics();
            g2 = panel2.CreateGraphics();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void randomColored()
        {
            Brush[] b =
            {
                Brushes.Black, Brushes.Yellow, Brushes.Red, Brushes.Blue,
                Brushes.Pink, Brushes.Purple, Brushes.Orange, Brushes.SkyBlue,
                Brushes.Green, Brushes.Gray, Brushes.Brown, Brushes.DarkRed
            };

            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mp[i, j] = b[rnd.Next(0, b.Length)];
                }
            }
        }

        private void draw(Graphics g)
        {
            int len = 200;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.FillRectangle(mp[i, j], new Rectangle(i * len / 4, j * len / 4, len / 4, len / 4));
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // middle
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var temp = mp[i, j];
                    mp[i, j] = mp[i, 4 - j - 1];
                    mp[i, 4 - j - 1] = temp;
                }
            }
            draw(g2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var temp = mp[i, j];
                    mp[i, j] = mp[4 - i - 1, j];
                    mp[4 - i - 1, j] = temp;
                }
            }
            draw(g2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 0 0 0 1 0 2 0 3   -> 0 3 1 3 2 3 3 3
            // 1 0 1 1 1 2 1 3   -> 0 2 1 2

            var temp = new Brush[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[i, j] = mp[i, j];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mp[i, j] = temp[j, 4 - i - 1];
                }
            }
            draw(g2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var temp = new Brush[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[i, j] = mp[i, j];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mp[i, j] = temp[4 - j - 1, i];
                }
            }

            draw(g2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomColored();
            draw(g1);

        }
    }
}

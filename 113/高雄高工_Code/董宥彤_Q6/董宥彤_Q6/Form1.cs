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

namespace 董宥彤_Q6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) { 
                var img = Image.FromFile(ofd.FileName);
                pictureBox1.Image = img;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < bmp.Width; i++) 
            { 
                for (int j = 0; j < bmp.Height; j++)
                {
                    var t = bmp.GetPixel(i, j);
                    var g = (int)(t.R * 0.3 + t.G * 0.59 + t.B * 0.11);
                    bmp.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }
            pictureBox2.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] Gx = new int[3, 3]
            {
                {-1, 0, 1 },
                {-2, 0, 2 },
                {-1, 0, 1 },
            }, Gy = new int[3, 3]
            {
                {-1, -2, -1 },
                {0, 0, 0 },
                {1, 2, 1 },
            };

            var bmp = new Bitmap(pictureBox1.Image);
            var bmp2 = new Bitmap(bmp.Width - 2, bmp.Height - 2);
            //int[,] px = new int[bmp.Width - 2, bmp.Height - 2];
            //int[,] py = new int[bmp.Width - 2, bmp.Height - 2];
            //int[,] G = new int[bmp.Width - 2, bmp.Height - 2];
            for (int i = 0; i < bmp.Width - 2; i++)
            {
                for (int j = 0; j < bmp.Height - 2; j++)
                {
                    int sum = 0, sum2 = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            var t = bmp.GetPixel(i+k, j+c);
                            var g = (int)(t.R * 0.3 + t.G * 0.59 + t.B * 0.11);
                            sum += g * Gx[k, c];
                            sum2 += g * Gy[k, c];
                        }
                    }
           
                    var G = (int)Math.Sqrt(sum*sum + sum2*sum2);
                    G = Math.Min(G, 255);
                    G = Math.Max(G, 0);
                    bmp2.SetPixel(i, j, Color.FromArgb(G, G, G));
                }
            }

            pictureBox2.Image = bmp2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var bmp = pictureBox2.Image;
            if (saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                bmp.Save(saveFileDialog.FileName);
            }
        }
    }
}

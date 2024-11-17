using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _94_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() {
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }

            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    var rgb = bmp.GetPixel(i, j);
                    var g = (rgb.R + rgb.G + rgb.B) / 3;
                    bmp2.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            pictureBox3.Image = bmp2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                InitialDirectory = Directory.GetCurrentDirectory()
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(ofd.FileName);
            }

            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    var rgb = bmp.GetPixel(i, j);
                    var g = (rgb.R + rgb.G + rgb.B) / 3;
                    bmp2.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            pictureBox4.Image = bmp2;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap A = new Bitmap(pictureBox2.Image);
            Bitmap B = new Bitmap(pictureBox3.Image);
            Bitmap C = new Bitmap(pictureBox4.Image);
            Bitmap D = new Bitmap(A.Width, A.Height);

            for (int i = 0; i < A.Height; i++)
            {
                for (int j = 0; j < A.Width; j++)
                {
                    var d = Math.Abs(C.GetPixel(i, j).ToArgb() - B.GetPixel(i, j).ToArgb());
                    Console.WriteLine(d);

                    if (d > 50)
                    {
                        D.SetPixel(i, j, A.GetPixel(i, j));
                    }
                }
            }

            pictureBox5.Image = D;
        }
    }
}

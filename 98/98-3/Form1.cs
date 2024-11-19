using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _98_3
{
    public partial class Form1 : Form
    {
        int sampleSize, sample;
        double len;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void raise()
        {
            MessageBox.Show("該檔案不是指定的格式", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BinaryReader rd = new BinaryReader(File.OpenRead(textBox1.Text));
            if (new string(rd.ReadChars(4)) != "RIFF") 
            { 
                raise();
                return;
            }

            rd.BaseStream.Seek(0x8, SeekOrigin.Begin);
            // Console.WriteLine(rd.ReadChars(7));
            if (new string(rd.ReadChars(7)) != "WAVEfmt")
            {
                raise();
                return;
            }
            rd.BaseStream.Seek(0x14, SeekOrigin.Begin);
            // Console.WriteLine(rd.ReadInt16());
            // Console.WriteLine(rd.ReadInt16());
            if (rd.ReadInt16() != 1)
            {
                raise();
                return;
            }
            // Console.WriteLine(rd.ReadInt16());
            if (rd.ReadInt16() != 1)
            {
                raise();
                return;
            }
            sample = rd.ReadInt32();
            Console.WriteLine(sample);
            rd.BaseStream.Seek(0x22, SeekOrigin.Begin);
            // Console.WriteLine(rd.ReadInt16());
            if (rd.ReadInt16() != 8)
            {
                raise();
                return;
            }

            rd.BaseStream.Seek(0x28, SeekOrigin.Begin);
            sampleSize = rd.ReadInt32();
            len = sampleSize / (float)sample;

            bmp = new Bitmap(sampleSize, pictureBox1.Height);
            var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Black);
            rd.BaseStream.Seek(0x2C, SeekOrigin.Begin);
            for (int i = 0; i < sampleSize; i++)
            {
                int val = rd.ReadByte(); // 0 ~ 255
                // 128 = middle
                float value;
                // if (val == 0x80) continue;
                if (val > 0x80)
                {
                    value = (val - 0x80) / (float)(0xFF - 0x80);
                }
                else
                {
                    value = -(val - 0x80) / (float)(0xFF - 0x80);
                }

                value *= pictureBox1.Height;
                g.DrawLine(Pens.Green, i, (pictureBox1.Height - value) * 0.5f, i, (pictureBox1.Height + value) * 0.5f);
            }
            hScrollBar1.Maximum = sampleSize - pictureBox1.Width;
            hScrollBar1.Minimum = 0;
            hScrollBar1.Value = 0;
            textBox2.Text = $"{0f:f5}";
            textBox3.Text = $"{len:f5}";
            Bitmap bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp2);
            g.DrawImageUnscaled(bmp, -hScrollBar1.Value, 0);
            pictureBox1.Image = bmp2;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (bmp == null)
                return;
            Bitmap bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp2);
            // Console.WriteLine(hScrollBar1.Value);
            g.DrawImageUnscaled(bmp, -hScrollBar1.Value, 0);
            pictureBox1.Image = bmp2;
            textBox2.Text = $"{hScrollBar1.Value / (float)sample:f5}";
        }
    }
}

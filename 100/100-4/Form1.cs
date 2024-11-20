using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _100_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 開啟彩色影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            if (odf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(odf.FileName);
            }
        }

        private void 結束離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        int[] grays = new int[256];
        private void 色彩影像轉詼諧影像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            for (int i = 0; i < 256; i++) grays[i] = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color px = bmp.GetPixel(i, j);
                    var g = (int)((px.R * 0.3 + px.G * 0.59 + px.B * 0.11));
                    // Console.WriteLine(g);
                    grays[g]++;
                    bmp.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            pictureBox2.Image = bmp;
        }

        private void 畫出詼諧影像圖ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                chart1.Series[0].Points.AddXY(i, grays[i]);
            }
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
        }

        private void 求最小詼諧和最大詼諧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minG = 255, maxG = 0;
            for (int i = 0; i < 256; i++)
            {
                if (grays[i] > 0)
                {
                    minG = i;
                    break;
                }
            }
            for (int i = 255; i >= 0; i--)
            {
                if (grays[i] > 0)
                {
                    maxG = i;
                    break;
                }
            }

            label2.Text = $"最小詼諧亮度為 {minG}";
            label3.Text = $"最大詼諧亮度為 {maxG}";
        }

        private void 求出現最多次詼諧機率ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int  maxG = int.MinValue, sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += grays[i];
                maxG = Math.Max(maxG, grays[i]);
            }

            label5.Text = $"出現最多詼諧亮度為 {maxG}";
            label6.Text = $"最多詼諧亮度之機率為 {((double)maxG / sum):f5}";
        }
    }
}

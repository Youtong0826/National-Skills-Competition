using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using static System.Console;
using static System.Convert;
using System.Windows.Forms.DataVisualization.Charting;

namespace _98_5
{
    public partial class Form1 : Form
    {
        double minV, maxV, Avr;

        public Form1()
        {
            InitializeComponent();
        }

        private (List<double> X, List<double> Y) getPos()
        {
            List<double> X = new List<double>(), Y = new List<double>();
            foreach (var item in groupBox1.Controls)
            {
                TextBox txt;
                try { txt = (TextBox)item; }
                catch { continue; }
                try
                {
                    if (txt.Name.StartsWith("X")) X.Add(ToDouble(txt.Text));
                    else Y.Add(ToDouble(txt.Text));
                }
                catch
                {
                    MessageBox.Show("資料點格式錯誤", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            return (X, Y);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int N;
            if (textBox1.Text == "")
            {
                groupBox1.Controls.Clear();
            }
            try { N = ToInt32(textBox1.Text); }
            catch { return; }



            for (int i = 1; i <= N; i++)
            {
                // 15 110 160
                Label lb = new Label()
                {
                    Text = $"請輸入座標點 {i}:",
                    Location = new Point(15, 30 * i),
                };
                TextBox txtX = new TextBox()
                {
                    Name = $"X{i}",
                    Text = "",
                    Location = new Point(120, 30 * i - 5),
                    Size = new Size(45, 25)
                };
                TextBox txtY = new TextBox()
                {
                    Name = $"Y{i}",
                    Text = "",
                    Location = new Point(170, 30 * i - 5),
                    Size = new Size(45, 25)
                };

                groupBox1.Controls.Add(lb);
                groupBox1.Controls.Add(txtX);
                groupBox1.Controls.Add(txtY);
            }
        }

        private bool Calc()
        {
            (List<double> X, List<double> Y) = getPos();
            if (X.Count < 1 || Y.Count < 1)
            {
                MessageBox.Show("請先輸入資料點", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            double sx, sy;
            try
            {
                sx = ToDouble(textBox2.Text);
                sy = ToDouble(textBox3.Text);
            } catch
            {
                MessageBox.Show("測試點格式不正確", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            double maxV = double.MinValue;
            double minV = double.MaxValue;
            double sum = 0;
            for (int i = 0; i < X.Count; i++)
            {
                maxV = Max(maxV, Sqrt((sx - X[i]) * (sx - X[i]) + (sy - Y[i]) * (sy - Y[i])));
                minV = Min(minV, Sqrt((sx - X[i]) * (sx - X[i]) + (sy - Y[i]) * (sy - Y[i])));
                sum += Sqrt((sx - X[i]) * (sx - X[i]) + (sy - Y[i]) * (sy - Y[i]));
            }

            this.maxV = maxV;
            this.minV = minV;
            this.Avr = sum / X.Count;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Calc())
                textBox4.Text = $"{maxV:f3}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Calc())
                textBox5.Text = $"{minV:f3}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Calc())
                textBox6.Text = $"{Avr:f3}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (List<double> X, List<double> Y) = getPos();
            if (X.Count < 1 || Y.Count < 1)
            {
                MessageBox.Show("請先輸入資料點", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double sx, sy;
            try
            {
                sx = ToDouble(textBox2.Text);
                sy = ToDouble(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("測試點格式不正確", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            chart1.Visible = true;
            chart1.Series[1].Points.AddXY(sx, sy);
            for (int i = 0; i < X.Count; i++)
            {
                chart1.Series[0].Points.AddXY(X[i], Y[i]);
            }
        }
    }
}

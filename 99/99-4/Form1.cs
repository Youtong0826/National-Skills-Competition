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
using static System.Console;
using static System.Convert;
using static System.Environment;
using static System.Math;
using static System.Linq.Enumerable;

namespace _99_4
{
    public partial class Form1 : Form
    {
        string dir = "正向";
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            var N = ToInt32(textBox1.Text);
            label1.Text += $"數值: {N} {NewLine}";
            label1.Text += $"方向: {dir} {NewLine}";
            for (int i = 1; i < N; i += 2)
            {
                label1.Text += string.Join("", Repeat("　", (N-i)/2)) 
                    + string.Join("", Repeat("＊", i)) 
                    + string.Join("", Repeat("　", (N - i) / 2))
                    + NewLine;
            }
            label1.Text += string.Join("", Repeat("＊", N)) + NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            dir = "正向";
            var N = ToInt32(textBox1.Text);
            label1.Text += $"數值: {N} {NewLine}";
            label1.Text += $"方向: {dir} {NewLine}";
            for (int i = 1; i < N; i += 2)
            {
                label1.Text += string.Join("", Repeat("　", (N - i) / 2))
                    + string.Join("", Repeat("＊", i))
                    + NewLine;
            }
            label1.Text += string.Join("", Repeat("＊", N)) + NewLine;

            label2.Text += $"數值: {N} {NewLine}";
            label2.Text += $"方向: {dir} {NewLine}";
            label2.Text += string.Join("", Repeat("　", (N - 1) / 2)) + "＊" + NewLine;
            for (int i = 3; i < N; i += 2)
            {
                label2.Text += string.Join("", Repeat("　", (N - i) / 2))
                    + "＊" + string.Join("", Repeat("　", i - 2))
                    + "＊" + NewLine;
            }
            label2.Text += string.Join("", Repeat("＊", N)) + NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            dir = "反轉";
            var N = ToInt32(textBox1.Text);
            label1.Text += $"數值: {N} {NewLine}";
            label1.Text += $"方向: {dir} {NewLine}";
            for (int i = N; i >= 0; i -= 2)
            {
                label1.Text += string.Join("", Repeat("　", (N - i) / 2))
                    + string.Join("", Repeat("＊", i))
                    + NewLine;
            }
            label2.Text = "";
            label2.Text += $"數值: {N} {NewLine}";
            label2.Text += $"方向: {dir} {NewLine}";
            label2.Text += string.Join("", Repeat("＊", N)) + NewLine; 
            for (int i = N - 2; i > 1; i -= 2)
            {
                label2.Text += string.Join("", Repeat("　", (N - i) / 2))
                    + "＊" + string.Join("", Repeat("　", i - 2))
                    + "＊" + NewLine;
            }
            label2.Text += string.Join("", Repeat("　", (N - 1) / 2)) + "＊" + NewLine;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = !label2.Visible;
            label2.Text = "";
            var N = ToInt32(textBox1.Text);
            label2.Text += $"數值: {N} {NewLine}";
            label2.Text += $"方向: {dir} {NewLine}";
            if (dir == "正向")
            {
                label2.Text += string.Join("", Repeat("　", (N - 1) / 2)) + "＊" + NewLine;
                for (int i = 3; i < N; i += 2)
                {
                    label2.Text += string.Join("", Repeat("　", (N - i) / 2))
                        + "＊" + string.Join("", Repeat("　", i - 2))
                        + "＊" + NewLine;
                }
                label2.Text += string.Join("", Repeat("＊", N)) + NewLine;
            }
            
            else
            {
                label2.Text += string.Join("", Repeat("＊", N)) + NewLine;
                for (int i = N - 2; i > 1; i -= 2)
                {
                    label2.Text += string.Join("", Repeat("　", (N - i) / 2))
                        + "＊" + string.Join("", Repeat("　", i - 2))
                        + "＊" + NewLine;
                }
                label2.Text += string.Join("", Repeat("　", (N - 1) / 2)) + "＊" + NewLine;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

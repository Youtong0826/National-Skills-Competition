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

namespace _99_3
{
    public partial class Form1 : Form
    {
        int n = -1, idx = 1;
        List<double> list = new List<double>();
        public Form1()
        {
            InitializeComponent();
            for (int i = 2; i < 7; i++)
                dataGridView1.Columns[i].DefaultCellStyle.Format = "N3";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { n = -1; return; }
            n = ToInt32(textBox1.Text);
            idx = 1;
            label2.Text = $"輸入第 1 筆資料";
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n == -1)
            {
                return;
            }

            if (idx > n)
            {
                return;
            }
            // 算術平均數 標準差 幾何平均數 均方根平均數 調和平均數
            var val = ToDouble(textBox2.Text);
            list.Add(val);
            double av, sd, gm, rmsa, hm;
            double sum = 0, sum2 = 0, mul = 1, div = 0;
            foreach (double v in list)
            {
                sum += v;
                sum2 += v * v;
                mul *= v;
                div += 1 / v;
            }

            int N = list.Count;
            av = sum / N;
            sd = Sqrt((N * sum2 - sum * sum) / N * (N - 1));
            gm = Pow(mul, 1.0 / N);
            rmsa = sum2 / N;
            hm = N / div;

            dataGridView1.Rows.Add(idx, val, av, sd, gm, rmsa, hm);
            idx++;
            if (idx > n) return;
            label2.Text = $"輸入第 {idx} 筆資料";
        }
    }
}

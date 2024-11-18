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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { n = -1; return; }
            n = ToInt32(textBox1.Text);
            label2.Text = $"輸入第 1 筆資料";
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
            double av, sd;
            foreach (double v in list)
            {
                
            }
            dataGridView1.Rows.Add(idx, val, );
            label2.Text = $"輸入第 {++idx} 筆資料";
        }
    }
}

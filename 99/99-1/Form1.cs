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

namespace _99_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var binArray = Repeat("0", 36).Concat(Repeat("1", 4)).ToArray();
            binArray = binArray.OrderBy(x => rnd.Next()).ToArray();
            textBox1.Text = string.Join("", binArray);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bin = textBox1.Text;
            int len = 0;
            List<int> lis = new List<int>();
            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] == '1')
                {
                    lis.Add(len);
                    len = 0;
                }
                len++;
            }

            List<string> lis2 = new List<string>();
            foreach (var num in lis)
            {
                lis2.Add(Convert.ToString(num, 2));
            }

            textBox2.Text = string.Join(" ", lis2);
            textBox3.Text = $"{(textBox2.Text.Length / (float)textBox1.Text.Length * 100):f1} %";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

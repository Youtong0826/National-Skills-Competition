using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Convert;
using static System.Math;

namespace _96_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var A = ToInt64(textBox1.Text);
            var B = ToInt64(textBox2.Text);
            var C = ToInt64(textBox3.Text);
            Console.WriteLine($"{A} {B} {C}");
            var bin = Convert.ToString(B, 2);
            Console.WriteLine(bin);
            double S = A;

            for (int i = 1; i < bin.Length; i++)
            {
                S = S * S % C;
                if (bin[i] == '1')
                {
                    
                    S = S * A % C;
                }
                Console.WriteLine($"{i} {bin[i]} {S}");
            }

            textBox4.Text = $"{S}";
        }
    }
}

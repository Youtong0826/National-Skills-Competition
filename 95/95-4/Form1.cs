using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _95_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var a = Convert.ToDouble(textBox1.Text);
            var b = Convert.ToDouble(textBox2.Text);
            var c = Convert.ToDouble(textBox3.Text);

            textBox4.Text = $"{a}X^2 + {b}x + {c}";

            if (a == 0)
            {
                if (b == 0)
                    textBox5.Text = c != 0 ? "無解" : "無限多組解";
                else
                {
                    textBox5.Text = Math.Round(-c / b, 2).ToString();
                    textBox6.Text = "只有一解";
                }
                return;
            }

            var d = b * b - (4 * a * c);
            if (d < 0)
            {
                textBox5.Text = Math.Round(-b / 2 / a, 2).ToString() + "+" + Math.Round(Math.Sqrt(-d) / 2 / a, 2).ToString()+"i";
                textBox6.Text = Math.Round(-b / 2 / a, 2).ToString() + "-" + Math.Round(Math.Sqrt(-d) / 2 / a, 2).ToString()+"i";
            }

            else if (d == 0)
            {
                textBox5.Text = Math.Round(-b / 2 / a, 2).ToString();
                textBox6.Text = "同根";
            }

            else
            {
                textBox5.Text = Math.Round(-b + Math.Sqrt(d), 2).ToString();
                textBox6.Text = Math.Round(-b - Math.Sqrt(d), 2).ToString();
            }
        }
    }
}

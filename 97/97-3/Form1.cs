using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _97_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            List<string> list = new List<string>();
            string[] bit16 = new string[16] {
                "0", "0", "0", "0", "0", "0", "0", "0", 
                "0", "0", "0", "0", "0", "0", "0", "0", 
            }, bit8 = new string[8] {
                 "0", "0", "0", "0", "0", "0", "0", "0" 
            };

            if (num < 0) bit16[0] = "1";
            num = Math.Abs(num);
            int num1 = (int)Math.Floor(num);
            double num2 = num - num1;
            int stx = 15;
            while (num1 > 0)
            {
                if (stx < 1)
                {
                    textBox2.Text = "overflow";
                    return;
                }
                bit16[stx--] = $"{num1 % 2}";
                // list.Add($"{num % 2}");
                num1 /= 2;
            }

            stx = 0;
            
            while (num2 > 0)
            {
                Console.WriteLine(num2);
                if (stx > 7)
                {
                    textBox2.Text = "overflow";
                    return;
                }
                num2 *= 2;
                bit8[stx++] = num2 > 0 ? "1" : "0";
                num2 -= num2 >= 1 ? 1 : 0;
            }

            textBox2.Text = string.Join("", bit16) + "." + string.Join("", bit8) ;
            // foreach (string str in list) { Console.WriteLine(str); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

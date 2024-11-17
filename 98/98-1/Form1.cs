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

namespace _98_1
{
    public partial class Form1 : Form
    {
        string[] statu = { "Ih", "Ld", "En" };
        // string[] txt = new string[4] { "Ih", "Ih", "Ih", "Ih", };
        int[] stx = new int[4] { 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
            button1.Text = button2.Text = button3.Text = button4.Text = "Ih";
            button1.Click += change;
            button2.Click += change;
            button3.Click += change;
            button4.Click += change;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox1.Text = Convert.ToString(rnd.Next(0, (int)Pow(2, 8)), 2).PadLeft(8, '0');
            textBox2.Text = Convert.ToString(rnd.Next(0, (int)Pow(2, 8)), 2).PadLeft(8, '0');
            textBox3.Text = Convert.ToString(rnd.Next(0, (int)Pow(2, 8)), 2).PadLeft(8, '0');
            textBox4.Text = Convert.ToString(rnd.Next(0, (int)Pow(2, 8)), 2).PadLeft(8, '0');
        }

        private void change(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Text = statu[(Array.IndexOf(statu, button.Text) + 1) % 3];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[4] { button1, button2, button3, button4 };
            TextBox[] txts = new TextBox[4] { textBox1, textBox2, textBox3, textBox4 };
            for (int i = 0; i < 4; i++)
            {
                if (btns[i].Text == "En")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == i) continue;
                        if (btns[j].Text == "Ld")
                        {
                            txts[j].Text = txts[i].Text;
                        }
                    }
                    break;
                }
            }
        }
    }
}

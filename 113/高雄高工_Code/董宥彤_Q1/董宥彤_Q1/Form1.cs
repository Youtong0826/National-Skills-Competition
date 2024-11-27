using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace 董宥彤_Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = Array.ConvertAll(textBox1.Text.Split(','), ToInt32);

            int add = 1, front = data[data.Length - 2], back = data[data.Length - 1];
            for (int i = data.Length-3; i >= 0; i--) {
                int sum = back * front + add;
                add = back;
                front = data[i];
                back = sum;
                WriteLine($"{front} {add} {back}");
            }

            textBox2.Text = $"{back * front + add} / {back}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}

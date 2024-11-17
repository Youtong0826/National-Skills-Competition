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

namespace _97_6
{
    public partial class Form1 : Form
    {
        bool chk = false;
        string op;
        double last, now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += Click;
            button2.Click += Click;
            button3.Click += Click;
            button4.Click += Click;
            button5.Click += Click;
            button6.Click += Click;
            button7.Click += Click;
            button8.Click += Click;
            button9.Click += Click;
            button10.Click += Click;
            button11.Click += Click;
            button12.Click += Click;
            button13.Click += Click;
            button14.Click += Click;
            button15.Click += Click;
            button16.Click += Click;
            button17.Click += Click;
            button18.Click += Click;
            button19.Click += Click;
        }

        private void Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var key = button.Text;
            // Console.WriteLine(key);
            if (new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }.Contains(key)) 
            {
                textBox1.Text += key;
                return;
            }
            if (key == "=")
            {
                DataTable tb = new DataTable();
                now = ToDouble(textBox1.Text);
                Console.WriteLine($"{last}{op}{now}");
                textBox1.Text = $"{ToDouble(tb.Compute($"{last}{op}{now}", string.Empty))}";
                return;
            }
            if (key == "AC")
            {
                textBox1.Text = "";
                return;
            }
            if (key == "+/-")
            {
                if (textBox1.Text.StartsWith("-"))
                    textBox1.Text = textBox1.Text.Substring(1);
                else 
                    textBox1.Text = "-" + textBox1.Text;
                return;
            }
            if (key == ".")
            {
                textBox1.Text += ".";
                return;
            }
            if (key == "log")
            {
                var val = ToDouble(textBox1.Text);
                textBox1.Text = $"{Log10(val)}";
                return;
            }

            last = ToDouble(textBox1.Text);
            textBox1.Text = "";
            op = key;
        }
    }
}

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

namespace _99_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = File.ReadAllText(textBox1.Text);
            textBox4.Text = s;

            string target = textBox2.Text;
            for (int i = 0; i < s.Length; i++)
            {
                bool f = true;
                for (int j = 0; j < target.Length; j++)
                {
                    Write(s[i]);
                    if (s[i] == target[j]) { i++;  continue; }
                    else
                    {
                        f = false;
                        break;
                    }
                }
                WriteLine(f);
                if (f)
                {
                    textBox3.Text = $"{i-target.Length+1}";
                    return;
                }
            }

            textBox3.Text = "No solution.";
        }
    }
}

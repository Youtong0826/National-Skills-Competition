using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _94_5
{
    public partial class Form1 : Form
    {
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            label2.Visible = false;
            if (textBox1.Text == "***")
            {
                textBox1.Text = "";
                return;
            }
            int n = Convert.ToInt32(textBox1.Text);
            if (n < 1 || n > 10)
            {
                label2.Visible = true;
                count++;
                if (count > 3)
                {
                    textBox1.ForeColor = Color.Red;
                    textBox1.Text = "???";
                    button1.Enabled = false;
                }
                return;
            }
            var lines = new string[n];
            lines[0] = n.ToString();
            for (int i = 1; i < n; i++)
            {
                lines[i] = $"{n - i} {string.Join(" ", Enumerable.Repeat("1", i).ToArray())}";
            }

            textBox2.Lines = lines;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (count > 3 && textBox1.Text != "***")
            {
                return;
            }
            else
            {
                button1.Enabled = true;
                label2.Visible = false;
                textBox1.ForeColor = Color.Black;
            }
        }
    }
}

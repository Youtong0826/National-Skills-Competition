using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _94_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text;

            List<string>[] d = {
                new List<string>{"09", "12", "33", "47", "53", "67", "78", "92"},
                new List<string>{"48", "81"},
                new List<string>{"13", "41", "62"},
                new List<string>{"01", "03", "45", "79"},
                new List<string>{"14", "16", "24", "44", "46", "57", "64", "74", "82", "87", "98"},
                new List<string>{"10", "31"},
                new List<string>{"06", "25"},
                new List<string>{"23", "39", "50", "56", "65", "68"},
                new List<string>{"32", "70", "73", "83", "88", "93"},
                new List<string>{"15"}
            };

            var idx = Enumerable.Repeat(0, 10).ToArray();
            var output = new List<string>();

            foreach (char c in s)
            {
                int i = c - 'a';
                output.Add(d[i][idx[i]]);
                idx[i] = (idx[i] + 1) % d[i].Count;
            }

            textBox2.Text = string.Join(" ", output);
        }
    }
}

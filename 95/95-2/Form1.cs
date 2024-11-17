using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _95_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = new string(textBox1.Text.Reverse().ToArray());
            var kp = new List<int>(); 
            int k = 0;
            for (; Math.Pow(2, k) < s.Length + k + 1; k++)
            {
                kp.Add((int)Math.Pow(2, k));
            };

            string s2 = "";
            int code = 0;

            int j = 0;
            for (int i = 0; i < s.Length+k && j < s.Length; i++)
            {
                if (kp.Contains(i + 1))
                    continue;

                if (s[j++] == '1')
                {
                    code = (code == 0) ? i + 1 : code ^ (i + 1);

                }
            }

            Console.WriteLine(code);

            string bin_code = new string(Convert.ToString(code, 2).PadLeft(k, '0').Reverse().ToArray());
            int bin_idx = 0, sidx = 0, idx = 0;

            Console.WriteLine(bin_code);
            while (idx < s.Length + k)
            {
                if (kp.Contains(idx + 1)) {
                    s2 += bin_code[bin_idx++];
                }
                else { 
                    s2 += s[sidx++];
                }

                idx++;
                Console.WriteLine(new string(s2.Reverse().ToArray()));
            }
            textBox2.Text = new string(s2.Reverse().ToArray());
        }
    }
}

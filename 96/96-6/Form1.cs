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

namespace _96_6
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

        private long powerMod(long A, long B, long C)
        {
            string bin = Convert.ToString(B, 2);
            long S = A;
            for (int i = 1; i < bin.Length; i++)
            {
                S = S * S % C;
                if (bin[i] == '1')
                {

                    S = S * A % C;
                }
            }

            return S;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            var E = ToInt32(textBox1.Text);
            var N = ToInt32(textBox2.Text);
            Console.WriteLine($"{E} {N}");
            Console.WriteLine(powerMod(42148, 8315, 68269));
            var M =  textBox3.Text;
            foreach (char c in M)
            {
                byte[] intbits = new byte[8];
                Encoding.GetEncoding(950).GetBytes(c.ToString(), 0, 1, intbits, 0);
                long code = ToInt32(c);
                if (code > 127)
                    code = BitConverter.ToInt32(new byte[] { intbits[1], intbits[0], 0, 0 }, 0);

                textBox4.Text += $"{powerMod(code, E, N)}".PadLeft(textBox2.Text.Length, '0');
                Console.WriteLine($"{powerMod(code, E, N)} {textBox4.Text}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            var E = ToInt64(textBox7.Text);
            var N = ToInt64(textBox6.Text);
            Console.WriteLine($"{E} {N}");
            Console.WriteLine(powerMod(42148, 8315, 68269));
            // var M = ToInt64(textBox5.Text);
            // textBox8.Text = $"{powerMod(M, E, N)}";
        }
    }
}

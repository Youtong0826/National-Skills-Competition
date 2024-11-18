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
using static System.Convert;
using static System.Console;
using static System.Math;

namespace _98_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double getAvarage(int start, int len, double[] data)
        {
            double sum = 0;
            for (int i = start; i > start-len; i--)
            {
                sum += data[i];
            }

            return sum / len;
        }

        private double getPredict(int start, double[] data)
        {
            return (4 * data[start-4] - data[start-19]) / 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = Array.ConvertAll(File.ReadAllText(textBox1.Text).Split(), ToDouble);
            var v = data.Skip(19).ToList();
            while (v.Count < 15) v.Add(0d);
            textBox3.Text = string.Join(" ", v.ConvertAll((x) => $"{x:f2}"));
            // start : 19;
            v.Clear();
            for (int i = 19; i < data.Length; i++)
            {
                v.Add(getAvarage(i, 5, data));
            }
            while (v.Count < data.Length - 16) v.Add(0d);
            textBox4.Text = string.Join(" ", v.ConvertAll((x) => $"{x:f2}"));

            List<double> v2 = new List<double>();
            for (int i = 19; i < data.Length; i++)
            {
                v2.Add(getAvarage(i, 20, data));
            }
            while (v2.Count < data.Length - 16) v2.Add(0d);
            textBox5.Text = string.Join(" ", v2.ConvertAll((x) => $"{x:f2}"));

            List<double> v3 = new List<double>();
            for (int i = 0; i < v.Count; i++)
            {
                textBox6.Text += $"{(v[i] - v2[i]):f2} "; 
            }

            for (int i = 19; i < data.Length + 4; i++)
            {
                textBox7.Text += $"{getPredict(i, data):f2} ";
            }

            var sw = new StreamWriter(textBox2.Text);
            sw.WriteLine(textBox3.Text);
            sw.WriteLine(textBox4.Text);
            sw.WriteLine(textBox5.Text);
            sw.WriteLine(textBox6.Text);
            sw.WriteLine(textBox7.Text);
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

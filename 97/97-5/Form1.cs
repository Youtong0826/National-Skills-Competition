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
using static System.Math;

namespace _97_5
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

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var input = File.ReadAllText(textBox1.Text).Split('\n');

            for (int i = 0; i < 3; i++)
            {
                input[i] = input[i].Remove(input[i].Length - 1);
                Console.WriteLine(input[i]);
            }

            double minC = double.MaxValue, maxC = double.MinValue;
            var highC = Array.ConvertAll(input[0].Split(), ToDouble);
            var lowC = Array.ConvertAll(input[1].Split(), ToDouble);

            for (int i = 0; i < 8; i++ )
            {
                maxC = Max(maxC, highC[i]);
            }

            for (int i = 0; i < 8; i++)
            {
                minC = Max(minC, lowC[i]);
            }

            var endC = Array.ConvertAll(input[2].Split(), ToDouble);

            double lastK = ToDouble(textBox3.Text), lastD = ToDouble(textBox4.Text);
            StreamWriter sw = new StreamWriter(textBox2.Text);
            List<double> K = new List<double>();
            List<double> D = new List<double>();
            for (int i = 8; i < 12; i++)
            {
                var RSV = (endC[i] - minC) / (maxC - minC);
                K.Add(2 * lastK / 3 + RSV / 3);
                D.Add(2 * lastD / 3 + K[K.Count-1] / 3);
                minC = Min(minC, lowC[i]);
                maxC = Max(maxC, highC[i]);
                lastK = K[K.Count - 1];
                lastD = D[K.Count - 1];
            }

            foreach (var item in K)
            {
                sw.Write($"{item:f2} ");
            }
            sw.Write('\n');
            foreach (var item in D)
            {
                sw.Write($"{item:f2} ");
            }
            sw.Close();

        }
    }
}

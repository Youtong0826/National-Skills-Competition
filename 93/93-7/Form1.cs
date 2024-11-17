using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// 這題的細節 omg = 2pi*f
// 輸入給的是 f 所以要乘上 2pi


namespace _93_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double t = Convert.ToDouble(textBox1.Text);
            double omg1 = Convert.ToInt32(textBox2.Text) * 2d * Math.PI;
            double omg0 = Convert.ToInt32(textBox3.Text) * 2d * Math.PI;
            int A = Convert.ToInt32(textBox4.Text);

            chart1.Series[0].Points.Clear();

            for (double x = 0; x <= 2; x += t) { 
                double y = A / 2d * Math.Cos((omg0 + omg1) * x) + A / 2d * Math.Cos((omg0 - omg1) * x );
                
                chart1.Series[0].Points.AddXY(x, y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Time(秒)";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 2;
            chart1.ChartAreas[0].AxisX.Interval = 0.2;

            chart1.ChartAreas[0].AxisY.Title = "y(t)";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Convert;
using static System.Math;

namespace _97_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double sinc(double x)
        {
            if (x == 0)
                return 1d;

            return Sin(x) / x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            int minX = ToInt32(textBox1.Text), maxX = ToInt32(textBox2.Text);
            chart1.ChartAreas[0].AxisX.Minimum = minX;
            chart1.ChartAreas[0].AxisX.Maximum = maxX;

            for (double i = minX; i <= maxX; i += 0.01)
            {
                chart1.Series[0].Points.AddXY(i, sinc(i));
            }
        }
    }
}

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
using static System.Math;

namespace _97_4
{
    public partial class Form1 : Form
    {
        int N;
        List<double> X, Y;
        public Form1(int N, List<double> X, List<double> Y)
        {
            InitializeComponent();
            this.N = N;
            this.X = X;
            this.Y = Y;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int N = this.N;
            var X = this.X;
            var Y = this.Y;

            label3.Text = $"請輸入資料總點數: {N}";

            chart1.Series.Add(new Series("Data Point")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle, // 設置標記樣式
                MarkerSize = 5, // 設置標記大小
                MarkerColor = Color.Red // 設置標記顏色
            });

            double INF = Pow(2, 32);
            double sumX = 0d, sumX2 = 0d, sumXY = 0d, sumY = 0d, AvrX, AvrY, mX = -INF, nX = INF, mY = -INF, nY = INF;
            label4.Text = "";
            for (int i = 0; i < N; i++)
            {
                label4.Text += $"請輸入每個點的 x, y 座標 [x, y]: [{X[i]} {Y[i]}]\n";
                chart1.Series[1].Points.AddXY(X[i], Y[i]);
                sumX += X[i];
                sumY += Y[i];
                sumX2 += X[i] * X[i];
                sumXY += X[i] * Y[i];
                mX = Max(mX, X[i]);
                nX = Min(nX, X[i]);
                mY = Max(mY, Y[i]);
                nY = Min(nY, Y[i]);
            }
            
            chart1.ChartAreas[0].AxisX.Maximum = mX+1;
            chart1.ChartAreas[0].AxisX.Minimum = nX-1;
            // chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Maximum = mY+1;
            chart1.ChartAreas[0].AxisY.Minimum = nY-1;
            // chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Crossing = 0;

            AvrX = sumX / N;
            AvrY = sumY / N;
            double m = (sumXY - sumX * AvrY) / (sumX2 - sumX * AvrX);
            double b = AvrY - m * AvrX;
            for (double i = 0; i < chart1.ChartAreas[0].AxisX.Maximum; i += 0.1)
            {
                chart1.Series[0].Points.AddXY(i, m * i + b);
            }

            label6.Text = $"斜率 (m) = {m:f2}\n截距 (b) = {b:f2}\n總資料點數 = {N}";
        }
    }
}

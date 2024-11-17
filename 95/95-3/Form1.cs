using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _95_3
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.TranslateTransform(0, panel1.Height / 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.DrawLine(new Pen(Color.Black), new Point(), new Point(panel1.Width));
            var lastPoint = new PointF(-0.1F, -0.1F);
            int sp = 80;
            for (float i = 0; i < Math.PI * 2.5; i += 0.01f)
            {
                Console.WriteLine($"{i} {Math.Sin(i)}");
                var point = new PointF(i * sp, (radioButton1.Checked)? (float)Math.Sin(i) * sp : (float)Math.Cos(i) * sp);

                if (lastPoint.X != -0.1F)
                {
                    g.DrawLine(new Pen(Color.Black), lastPoint, point);
                }

                lastPoint = point;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

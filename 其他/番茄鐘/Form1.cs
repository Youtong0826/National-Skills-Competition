using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace 番茄鐘
{
    public partial class Form1 : Form
    {
        float count = 0;
        int m, s, total;
        public Form1()
        {
            InitializeComponent();
            panel1.Paint += panel1_Paint;
            label3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void draw()
        {
            int x = 160, y = 160, r = 150;
            var g = panel1.CreateGraphics();
            // g.Clear(Color.White);
            g.DrawEllipse(new Pen(Brushes.Black, 2), 10, 10, 300, 300);
            for (float i = 0.5f; i < 61; i++)
            {
                g.DrawLine(
                    new Pen(Brushes.Black),
                    (r - 10) * (float)Math.Cos(2 * Math.PI * i / 59) + x,
                    (r - 10) * (float)Math.Sin(2 * Math.PI * i / 59) + y,
                    r * (float)Math.Cos(2 * Math.PI * i / 59) + x,
                    r * (float)Math.Sin(2 * Math.PI * i / 59) + y
                );
            }
        }

        private void panel1_Paint(object sender, EventArgs e)
        {
            draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var g = panel1.CreateGraphics();
            Console.WriteLine(count);
            count++;
            for (float i = (count - 1); i < count; i += 0.01f)
            {
                g.DrawLine(new Pen(Brushes.LimeGreen), 160, 160,
                    160 + 150 * (float)Math.Cos(2 * Math.PI * i / 59),
                    160 + 150 * (float)Math.Sin(2 * Math.PI * i / 59)
                );
            }
            
            draw();
            if (count == 104.5)
            {
                timer1.Stop();
                timer2.Stop();
                label3.Visible = true;
                label3.Text = "時間到 !";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = panel1.CreateGraphics();
            g.Clear(Color.White);
            draw();
            label3.Visible = false;
            m = Convert.ToInt32(textBox1.Text); 
            s = Convert.ToInt32(textBox2.Text);
            total = m * 60 + s;
            int tick = total * 1000 / 60;
            Console.WriteLine(tick);
            label4.Text = $"{m:d2}:{s:d2}";
            count = 44.5f;
            timer1.Interval = tick;
            timer2.Interval = 1000;
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            total--;
            if (total < 0) return;
            int nm = total / 60, ns = total % 60;
            label4.Text = $"{nm:d2}:{ns:d2}";
            
        }
    }
}

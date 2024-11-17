using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _95_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var n = Convert.ToInt32(textBox1.Text);
            List<int> prims = new List<int> {2};
            for (int i = 3; i <= n; i++) {
                bool f = true;
                for (int j = 2; j <= (int)Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        f = false;
                        break;
                    } 
                }

                if (f)
                    prims.Add(i);
            }
            prims.Sort((l, r) => r.CompareTo(l));
            label2.Text = $"質數個數有      {prims.Count}      個";
            label3.Text = $"最大的 3 個質數是      {string.Join("      ", Enumerable.Reverse(prims.GetRange(0, Math.Min(3, prims.Count))))}";

        }
    }
}

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
using System.Data;
using static System.Convert;
using static System.Math;

namespace _98_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            // ofd.Filter = "文字檔(*.txt)";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";
                textBox1.Text += "Net: " 
                    + comboBox2.Text.Substring(0, comboBox2.Text.Length-1) 
                    + "0" + Environment.NewLine;

                string mask = "";
                for (int i = 0; i < ToInt32(comboBox1.Text); i++)
                    mask += "1";
                for (int i = 0; i < 32 - ToInt32(comboBox1.Text); i++)
                    mask += "0";

                List<byte> msk = new List<byte>();
                for (int i = 0; i < 32; i += 8)
                {
                    string b = "";
                    for (int j = i; j < i + 8; j++)
                    {
                        b += mask[j];
                    }

                    msk.Add(ToByte(b, 2));
                }

                textBox1.Text += "Mask: " + string.Join(".", msk) + Environment.NewLine;
                var f = File.ReadAllText(ofd.FileName).Split('\n');
                string bIp = comboBox2.Text.Substring(0, comboBox2.Text.Length - 1) + "0";
                string temp = "";
                foreach (string s in bIp.Split('.'))
                {
                    temp += Convert.ToString(ToByte(s), 2).PadLeft(8, '0');
                }

                var ipNum = ToInt32(temp, 2);

                for (int i = 0; i < f.Length; i++)
                {
                    var data = f[i].Split(',');
                    var type = ToChar(data[0]);
                    var ip = data[1].Split('.');
                    var byte1 = ToByte(ip[0]);
                    if (type == 'A')
                    {
                        byte1 &= 0b011111111;
                    }
                    else if (type == 'B')
                    {
                        byte1 |= 0b10000000;
                        byte1 &= 0b10111111;
                    }
                    else if (type == 'C')
                    {
                        byte1 |= 0b11000000;
                        byte1 &= 0b11011111;
                    }
                    ip[0] = Convert.ToString(byte1);
                    Console.WriteLine(string.Join(".", ip));
                    string binIp = string.Join("", ip.ToList().ConvertAll(
                        (x) => Convert.ToString(ToByte(x), 2).PadLeft(8, '0')));
                    // Console.WriteLine(binIp);
                    Console.WriteLine(ToInt32(binIp, 2) & ToInt32(mask, 2));
                    Console.WriteLine((ToInt32(mask, 2) & ipNum));
                    if ((ToInt32(binIp, 2) & ToInt32(mask, 2)) == (ToInt32(mask, 2) & ipNum))
                    {
                        textBox1.Text += "IP: " + data[1] + " Message: " + data[2]
                            + Environment.NewLine;
                    }
                }       
            }
        }
    }
}

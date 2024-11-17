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

namespace _97_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string raw = textBox1.Text;
            List<string>[] match = new List<string>[3] {
                new List<string> { "957", "986" },
                new List<string> { "157", "204", "421", "442", "7198", "7323", "8573" },
                new List<string> { "277", "08", "58", "355" },
            };

            bool f = false;
            List<string> data = new List<string>{ };
            if (raw.Contains('-')) 
            { 
                data = raw.Split('-').ToList();
                string temp = "";
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(data[i]);
                    if (match[i].Contains(data[i]))
                        temp += data[i];
                    else
                    {
                        f = true;
                        break;
                    }
                }

                raw = temp;
                // num = ToInt64(raw);
            }

            else
            {
                string area = raw.Substring(0, 3);
                int end2 = -1;
                Console.WriteLine(area);
                if (!match[0].Contains(area))
                {
                    f = true;
                }

                if (!f)
                {
                    data.Add(area);
                    area = raw.Substring(3, 3);
                    bool ok = false;
                    if (match[1].Contains(area)) { 
                        ok = true;
                        end2 = 6;
                    }
                    area = raw.Substring(3, 4);
                    if (match[1].Contains(area)) { 
                        ok = true;
                        end2 = 7;
                    }

                    if (!ok) { 
                        f = true;
                    }
                    data.Add(area);
                }

                if (!f)
                {
                    Console.WriteLine(area);
                    area = raw.Substring(end2, raw.Length-end2);
                    Console.WriteLine(area);
                    if (!match[2].Contains(area)) { f = true; }
                    data.Add(area);
                }

            }
            
            if ( f ) {
                MessageBox.Show(
                    "您的 9 位數字不正確，請重試一次。",                          
                    "錯誤",                              
                    MessageBoxButtons.OK,                
                    MessageBoxIcon.Error                 
                );

                return;
            }
            // data.Append("test");
            // foreach (string s in data) { Console.WriteLine(s); }

            int sum = 0, code;
            for (int i = 0; i < raw.Length; i++)
            {
                // Console.Write($"{(9 - i) * (raw[i] - '0')} ");
                sum += (i + 1) * (raw[i] - '0');
            }
            // Console.WriteLine(sum);
            code = (sum % 11);
            if (code == 10)
            {
                code = 'X';
            }

            else if (code == 11)
            {
                code = '0';
            }

            else code += '0';

            data.Add($"{(char)code}");

            raw = "978" + raw;
            textBox2.Text = string.Join("-", data);

            sum = 0;
            for (int i = 0; i < raw.Length; i++)
            {
                if ((i & 1) == 1)
                {
                    sum += (raw[i] - '0') * 3;
                }
                else
                {
                    sum += (raw[i] - '0');
                }
            }

            code = sum % 10;
            if (code != 0) code = 10 - code;
            code += '0';
            data.RemoveAt(data.Count - 1);
            data.Add($"{(char)code}");
            textBox3.Text = $"978-{string.Join("-", data)}";
        }
    }
}

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

namespace _96_7
{
    public partial class Form1 : Form
    {
        Label[] lb = new Label[40];
        TextBox[] txt = new TextBox[40];
        NumericUpDown[] NUD = new NumericUpDown[40];
        public Form1()
        {
            InitializeComponent();
            lb[1] = label4;
            lb[2] = label5;
            lb[3] = label7;
            lb[4] = label6;
            lb[5] = label9;
            lb[6] = label8;
            lb[7] = label5;
            lb[8] = label4;
            lb[9] = label3;
            lb[10] = label12;
            lb[11] = label11;
            lb[12] = label10;
            
            lb[14] = label21;
            lb[15] = label23;
            lb[16] = label22;
            lb[17] = label24;
            lb[18] = label20;

            //21 19 20 13  22
            lb[21] = label31; 
            lb[19] = label30;
            lb[20] = label29;
            lb[13] = label28;
            lb[22] = label19;

            // 26 24 25 23 27
            lb[26] = label39;
            lb[24] = label38;
            lb[25] = label37;
            lb[23] = label36;
            lb[27] = label35;

            // 38 36 37 35 39
            lb[35] = label54;
            lb[36] = label56;
            lb[37] = label55;
            lb[38] = label57;
            lb[39] = label53;

            // 29 30 31 32 28
            lb[29] = label48;
            lb[30] = label47;
            lb[31] = label46;
            lb[32] = label45;
            lb[28] = label44;

            txt[1] = textBox1;
            txt[2] = textBox2;
            txt[3] = textBox3;
            txt[4] = textBox4;
            txt[5] = textBox5;
            txt[6] = textBox6;
            txt[7] = textBox7;
            txt[8] = textBox8;
            txt[9] = textBox9;
            txt[10] = textBox10;
            txt[11] = textBox11;
            txt[12] = textBox12;
            txt[13] = textBox13;
            txt[14] = textBox14;
            txt[15] = textBox15;
            txt[16] = textBox16;
            txt[17] = textBox17;
            txt[18] = textBox18;
            txt[19] = textBox19;
            txt[20] = textBox20;
            txt[21] = textBox21;
            txt[22] = textBox22;
            txt[23] = textBox23;
            txt[24] = textBox24;
            txt[25] = textBox25;
            txt[26] = textBox26;
            txt[27] = textBox27;
            txt[28] = textBox28;
            txt[29] = textBox29;
            txt[30] = textBox30;
            txt[31] = textBox31;
            txt[32] = textBox32;
            txt[33] = textBox33;
            // txt[34] = textBox34;
            txt[35] = textBox35;
            txt[36] = textBox36;
            txt[37] = textBox37;
            txt[38] = textBox38;
            txt[39] = textBox39;
            NUD[1] = numericUpDown1;
            NUD[2] = numericUpDown2;
            NUD[3] = numericUpDown3;
            NUD[4] = numericUpDown4;
            NUD[5] = numericUpDown5;
            NUD[6] = numericUpDown6;
            NUD[7] = numericUpDown7;
            NUD[8] = numericUpDown8;
            NUD[9] = numericUpDown9;
            NUD[10] = numericUpDown10;
            NUD[11] = numericUpDown11;
            NUD[12] = numericUpDown12;
            NUD[13] = numericUpDown13;
            NUD[14] = numericUpDown14;
            NUD[15] = numericUpDown15;
            NUD[16] = numericUpDown16;
            NUD[17] = numericUpDown17;
            NUD[18] = numericUpDown18;
            NUD[19] = numericUpDown19;
            NUD[20] = numericUpDown20;
            NUD[21] = numericUpDown21;
            NUD[22] = numericUpDown22;
            NUD[23] = numericUpDown23;
            NUD[24] = numericUpDown24;
            NUD[25] = numericUpDown25;
            NUD[26] = numericUpDown26;
            NUD[27] = numericUpDown27;
            NUD[28] = numericUpDown28;
            NUD[29] = numericUpDown29;
            NUD[30] = numericUpDown30;
            NUD[31] = numericUpDown31;
            NUD[32] = numericUpDown32;
            // NUD[33] = numericUpDown33;
            // NUD[34] = numericUpDown34;
            NUD[35] = numericUpDown35;
            NUD[36] = numericUpDown36;
            NUD[37] = numericUpDown37;
            NUD[38] = numericUpDown38;
            NUD[39] = numericUpDown39;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 39; i++)
            {
                if (i == 33 || i == 34) continue;
                NUD[i].Value = 0;
            }
            textBox33.Text = "等待客人點餐中...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            string result = "點了";
            List<string>[] lis = new List<string>[7];
            GroupBox[] gb = { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7 };
            for (int i = 1; i <= 39; i++)
            {
                if (i == 33 || i == 34) continue;
                Console.WriteLine($"{i} {txt[i].Text} {NUD[i].Value}");
                try { sum += ToInt32(txt[i].Text) * ToInt32(NUD[i].Value); } catch { }
                if (NUD[i].Value > 0)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (gb[j].Controls.Contains(txt[i]))
                        {
                            if (lis[j] == null) lis[j] = new List<string>();
                            lis[j].Add($"{lb[i].Text} {NUD[i].Value} 份，");
                        }
                    }
                }
            }
            string[] tit = { "主菜", "沙拉", "前菜", "湯品", "甜點", "冷飲", "熱飲" };
            for (int i = 0; i < 7; i++)
            {
                if (lis[i] == null) continue;
                if (lis[i].Count > 0 )
                {
                    result += $"{tit[i]} （{string.Join("，", lis[i])}），";
                }
            }
            if (sum == 0) return;
            result += $"加稅後總額為 {Round(sum * 1.05)}";
            textBox33.Text = $"{Round(sum * 1.05)}";
            
        }
    }
}

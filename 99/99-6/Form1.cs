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
using static System.Console;
using static System.Convert;
using static System.Environment;
using static System.Math;
using static System.Linq.Enumerable;

namespace _99_6
{
    public partial class Form1 : Form
    {
        string statu, user = "A";
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";

            toolStripMenuItem2.Click += toolStripMenuItem1_Click;
            toolStripMenuItem3.Click += toolStripMenuItem1_Click;
            toolStripMenuItem4.Click += toolStripMenuItem1_Click;

            toolStripMenuItem6.Click += toolStripMenuItem5_Click;
            toolStripMenuItem7.Click += toolStripMenuItem5_Click;
            toolStripMenuItem8.Click += toolStripMenuItem5_Click;
            toolStripMenuItem9.Click += toolStripMenuItem5_Click;
            toolStripMenuItem10.Click += toolStripMenuItem5_Click;
            toolStripMenuItem11.Click += toolStripMenuItem5_Click;
            toolStripMenuItem12.Click += toolStripMenuItem5_Click;
            toolStripMenuItem13.Click += toolStripMenuItem5_Click;
            toolStripMenuItem14.Click += toolStripMenuItem5_Click;
            toolStripMenuItem15.Click += toolStripMenuItem5_Click;
            toolStripMenuItem16.Click += toolStripMenuItem5_Click;
            toolStripMenuItem17.Click += toolStripMenuItem5_Click;
            toolStripMenuItem18.Click += toolStripMenuItem5_Click;
            toolStripMenuItem19.Click += toolStripMenuItem5_Click;
            toolStripMenuItem20.Click += toolStripMenuItem5_Click;
            // toolStripMenuItem.Click += toolStripMenuItem5_Click;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            switch (statu)
            {
                case "主菜":  
                    if (user == "A")
                    {
                        label1.Text = sender.ToString();
                    }
                    else
                    {
                        label5.Text = sender.ToString();
                    }
                    break;

                case "沙拉":
                    if (user == "A")
                    {
                        label2.Text = sender.ToString();
                    }
                    else
                    {
                        label6.Text = sender.ToString();
                    }
                    break;
                case "濃湯":
                    if (user == "A")
                    {
                        label3.Text = sender.ToString();
                    }
                    else
                    {
                        label7.Text = sender.ToString();
                    }
                    break;
                case "甜品":
                    if (user == "A")
                    {
                        label4.Text = sender.ToString();
                    }
                    else
                    {
                        label8.Text = sender.ToString();
                    }
                    break;
                default: break;
            }
            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(toolStripComboBox1.Text);
            user = $"{toolStripComboBox1.Text[0]}";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            statu = sender.ToString();
        }
    }
}

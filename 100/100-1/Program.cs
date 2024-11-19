using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using static System.Math;
using static System.Console;
using static System.Convert;
using static System.Environment;

namespace _100_1
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Write("輸入邊數 N: ");
            // var N = ToInt32(ReadLine());
            // Write("輸入顏色: ");
            // var C = ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

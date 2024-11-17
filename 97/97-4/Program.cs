using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using static System.Convert;

namespace _97_4
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        /// 
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();


        [STAThread]
        static void Main(string[] args)
        {
            // AllocConsole();
            while (true)
            {
                Write("輸入資料點數: ");
                int N = ToInt32(ReadLine());
                if (N <= 1)
                {
                    WriteLine("資料點數必須大於 1。");
                    continue;
                }
                List<double> X = new List<double>();
                List<double> Y = new List<double>();
                for (int i = 1; i <= N; i++)
                {
                    Write($"輸入資料點 {i} [x, y]:");
                    var data = Array.ConvertAll(ReadLine().Split(), ToDouble);
                    X.Add(data[0]); Y.Add(data[1]);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(N, X, Y));
                // WriteLine("test");
                // FreeConsole();

            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace 董宥彤_Q5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("***模擬今彩539***");
                var rnd = new Random();
                var list = new List<int>();
                for (int i = 0; i < 5; i++)
                {
                    var num = rnd.Next(1, 40);
                    while (list.Contains(num)) num = rnd.Next(1, 40);
                    list.Add(num);
                }
                WriteLine($"今彩539之間5個1~39號碼: {string.Join(" ", list)}");
                Write("請輸入要存今彩539之5個號碼的檔名: ");
                string file = ReadLine();
                var fs = File.Open(file, FileMode.CreateNew);
                foreach (var c in string.Join(" ", list))
                {
                    fs.WriteByte(ToByte(c));
                }
                fs.Close();
                WriteLine();
                Write("請輸入要讀今彩539之5個號碼的檔名: ");
                file = ReadLine();
                var text = File.ReadAllText(file);
                // text = text.Substring(0, text.Length - 1);
                var data = Array.ConvertAll(text.Split(), ToInt32);
                double n = data.Length, sum = 0, mul = 1, divsum = 0;
                foreach (var c in data)
                {
                    sum += c;
                    mul *= c;
                    divsum += 1 / (double)c;
                }
                WriteLine($"今彩539之5個號碼的算術平均數 {(sum / n):f6}");
                WriteLine($"今彩539之5個號碼的調和平均數 {(n / divsum):f6}");
                WriteLine($"今彩539之5個號碼的算術平均數 {(Pow(mul, 1 / n)):f6}");
                WriteLine();
                // bool[] down = new bool[data.Length];
                WriteLine($"排序前的資料 {string.Join(" ", data)}");
                WriteLine();
                string s = "--";
                for (int i = 0; i < data.Length; i++)
                {
                    int ns = int.MaxValue, choose = -1;
                    for (int j = i; j < data.Length; j++)
                    {
                        if (data[j] < ns)
                        {
                            ns = data[j];
                            choose = j;
                        }
                    }

                    var temp = data[i];
                    data[i] = ns;
                    data[choose] = temp;
                    Write($"第 {i + 1} 次選擇:  ");
                    for (int j = 0; j < data.Length; j++)
                    {
                        Write((j != choose) ? $"{data[j]}".PadRight(4) : $"{data[j]}*".PadRight(4));
                    }
                    WriteLine();
                    WriteLine($"              {s}");
                    s += "  --";
                }
                WriteLine($"排序後的資料 {string.Join(" ", data)}");
                List<int> ls = new List<int>();
                foreach (int i in data)
                {
                    if (!ls.Contains(i))
                        ls.Add(i);
                }

                WriteLine($"今彩539之5個號碼的中位數: {ls[ls.Count / 2]}");
                WriteLine();
            }
        }
    }
}

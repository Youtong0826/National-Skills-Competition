using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace _98_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("請輸入 N: ");
                var data = ToInt32(ReadLine());
                if (data < 1) return;
                List<int> list = new List<int>() { 1 };
                WriteLine(1);
                string last = "1";
                for (int i = 1; i <= data; i++)
                {
                    int len = 1;
                    char number = last[0];
                    List<int> lens = new List<int>();
                    List<char> numbers = new List<char>() { number };
                    //1211
                    for (int j = 1; j < last.Length; j++)
                    {
                        if (last[j] == number)
                        {
                            len++;
                            continue;
                        }
                        else
                        {
                            lens.Add(len);
                            len = 1;
                            number = last[j];
                            numbers.Add(number);
                        }
                    }
                    lens.Add(len);

                    last = "";

                    for (int j = 0; j < lens.Count; j++)
                    {
                        last += lens[j];
                        last += numbers[j];
                    }

                    WriteLine(last);
                }
            }
            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> mp = new Dictionary<char, int>
            {
                {'A', 10 },
                {'B', 11 },
                {'C', 12 },
                {'D', 13 },
                {'E', 14 },
                {'F', 15 },
            };

            while (true)
            {
                Console.Write("1.基底:");
                int r = Convert.ToInt32(Console.ReadLine());

                if (r > 16 || r < 2) { 
                    Console.WriteLine("輸入格式錯誤(需介於 2 ~ 16 之間)");
                    continue;
                }

                Console.Write("2.數字:");
                string[] s = Console.ReadLine().Split('.');
                string s1 = new string(s[0].Reverse().ToArray()); ;
                string s2 = s.Length >= 2? s[1]: "";
                double num = 0;
                bool f = false;

                for (int i = 0; i < s1.Length; i++)
                {
                    int n = mp.ContainsKey(s1[i])? mp[s1[i]]: s1[i]-'0';
                    if (n > r) 
                    {
                        Console.WriteLine($"輸入不符合基數 {r}");
                        f = true;
                        break;
                    }
                    num += n * Math.Pow(r, i);
                    // Console.WriteLine($"{n} {Math.Pow(r, i)} {n * Math.Pow(r, i)}");
                }

                for (int i = 0; i < s2.Length; i++)
                {
                    int n = mp.ContainsKey(s2[i]) ? mp[s2[i]] : s2[i] - '0';
                    if (n > r)
                    {
                        Console.WriteLine($"輸入不符合基數 {r}");
                        f = true;
                        break;
                    }
                    num += n * Math.Pow(r, -(i+1));
                    // Console.WriteLine($"{n} {Math.Pow(r, i)} {n * Math.Pow(r, i)}");
                }

                if (f)
                {
                    continue;
                }

                Console.WriteLine(num);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using static System.Console;
using static System.Convert;
using static System.Environment;
using static System.Math;
using static System.Linq.Enumerable;

namespace _99_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("輸入 N:");
                var N = ToInt32(ReadLine());
                bool f = false;
                SortedSet<int> temp = new SortedSet<int>(Range(1, N));
                for (int i = 1; i <= N; i++)
                {
                    int last = -1, idx = 1;
                    SortedSet<int> s = temp;
                    while (s.Count > 0)
                    {

                        if (!s.Contains(idx))
                            break;

                        s.Remove(idx);
                        last = idx;
                        if (s.Count == 0) break;
                        
                        idx = s.ElementAt((s.TakeWhile(x => x <= idx).Count() + i - 1) % s.Count);
                    }

                    if (last == 13)
                    {
                        f = true;
                        WriteLine($"M = {i}");
                        break;
                    }
                }
                if (!f)
                {
                    WriteLine("No Solution");
                }
            }
        }
    }
}

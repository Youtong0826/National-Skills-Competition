using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using static System.Console;
using static System.Math;

namespace _111_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var data = Array.ConvertAll(ReadLine().Split(), ToInt32);
                int a = data[0], b = data[1];
                List<Tuple<int, int>> 
                    nA = new List<Tuple<int, int>>(), 
                    nB = new List<Tuple<int, int>>();
                List<int> prime = new List<int>();
                bool[] is_prime = new bool[46342];
                for (int i = 2; i <= 46341; i++) 
                {
                    if (!is_prime[i]) {
                        // is_prime.Add(i, true);
                        prime.Add(i);
                    }

                    foreach (int j in prime)
                    {
                        if (i * j >= 46341) break;
                        is_prime[i * j] = true ;
                        if (i % j == 0) break;
                    }
                }

                foreach (var i in prime)
                {
                    int cnt = 0;
                    while (a % i == 0)
                    {
                        a /= i;
                        cnt++;
                    }

                    if (cnt != 0)
                    {
                        nA.Add(new Tuple<int, int>(i, cnt));
                    }

                    cnt = 0;
                    while (b % i == 0)
                    {
                        b /= i;
                        cnt++;
                    }

                    if (cnt != 0)
                    {
                        nB.Add(new Tuple<int, int>(i, cnt));
                    }
                }

                int ans = 1;
                foreach (var i in nA) 
                {
                    Write($"{i.Item1}");
                    if (i.Item2 > 1)
                        Write($"^{i.Item2}");
                    if (i != nA[nA.Count-1]) 
                        Write("*");
                    a *= (int)Pow(i.Item1, i.Item2);
                    var item = nB.BinarySearch(i);
                    // Write($"{item} \n");
                    if (item < 0) item = ~item;
                    if (item >= nB.Count) continue;
                    
                    int cnt;
                    for (int j = -1; j < 2 && item + j < nB.Count && item + j >= 0; j++)
                    {
                        if (nB[item + j].Item1 == i.Item1)
                        {
                            cnt = Min(nB[item + j].Item2, i.Item2);
                            ans *= (int)Pow(i.Item1, cnt);
                        }
                    }

                }
                Write($", ");
                foreach (var i in nB)
                {
                    Write($"{i.Item1}");
                    if (i.Item2 > 1)
                        Write($"^{i.Item2}");
                    if (i != nB[nB.Count - 1])
                        Write("*");
                    b *= (int)Pow(i.Item1, i.Item2);
                }
                Write($", "); 
                Write($"{ans}, ");
                WriteLine(prime.Contains(ans) ? "Y" : "N");
            }
        }
    }
}

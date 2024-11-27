using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace 董宥彤_Q2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("輸入物品的總數量: ");
                int n = ToInt32(ReadLine());
                Write("輸入背包的最大承載量 (10 的倍數): ");
                int w = ToInt32(ReadLine());
                List<int> H = new List<int>(), C = new List<int>();
                for (int i = 1; i <= n; i++)
                {
                    Write($"物品 {i} - 重量: ");
                    int h = ToInt32(ReadLine());
                    Write($"物品 {i} - 價值: ");
                    int c = ToInt32(ReadLine());
                    H.Add(h); C.Add(c);
                }

                int[,] dp = new int[n + 1, w + 11];
                for (int i = 0; i <= n; i++)
                {
                    dp[i, 0] = 0;
                }

                for (int i = 0; i <= w + 10; i++)
                {
                    dp[0, i] = 0;
                }

                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= w; j++)
                    {
                        if (j >= H[i-1])
                        {
                            dp[i, j] = Max(C[i - 1] + dp[i - 1, j - H[i - 1]], dp[i - 1, j]);
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }

                for (int i = 0; i <= n; ++i) { 
                    for (int j = 0; j <= w; j += 10)
                    {
                        Write($"{dp[i, j]} ");
                    }
                    WriteLine();
                }
            }
        }
    }
}

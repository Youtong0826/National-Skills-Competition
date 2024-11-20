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
namespace _112_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] data = new char[3, 3]
            {
                {'口', '口', '口' },
                {'口', '口', '口' },
                {'口', '口', '口' }
            };

            Random rnd = new Random();
            bool f = false;
            int round = 1;
            while (true)
            {
                if ((round++ & 1) == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Write(data[i, j]);
                        WriteLine();
                    }

                    Write("請輸入 1~9 (0 結束): ");
                    var N = ToInt32(ReadLine());

                    data[(N - 1) / 3, (N - 1) % 3] = 'Ｏ';
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (data[i, j] != 'Ｏ') continue;
                            f = false;
                            // check row
                            int k = j + 1, cnt = 1;
                            while (k < 3 && data[i, k++] == 'Ｏ') cnt++;
                            k = j - 1;
                            while (k >= 0 && data[i, k--] == 'Ｏ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｏ 方獲勝！");
                                f = true; 
                                break;
                            }

                            // check column
                            cnt = 1;
                            int c = i + 1;
                            while (c < 3 && data[c++, j] == 'Ｏ') cnt++;
                            c = i - 1;
                            while (c >= 0 && data[c--, j] == 'Ｏ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｏ 方獲勝！");
                                f = true; break;
                            }

                            cnt = 1;
                            c = i + 1; k = j + 1;
                            while (c < 3 && k < 3 && data[c++, k++] == 'Ｏ') cnt++;
                            c = i - 1; k = j - 1;
                            while (c >= 0 && k >= 0 && data[c--, k--] == 'Ｏ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｏ 方獲勝！");
                                f = true; break;
                            }

                            cnt = 1;
                            c = i - 1; k = j + 1;
                            while (c >= 0 && k < 3 && data[c--, k++] == 'Ｏ') cnt++;
                            c = i + 1; k = j - 1;
                            while (c < 3 && k >= 0 && data[c++, k--] == 'Ｏ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｏ 方獲勝！");
                                f = true; break;
                            }
                        }

                        if (f) 
                            break;
                    }
                }

                else
                {
                    int R;
                    R = rnd.Next(0, 8);
                    while (data[R / 3, R % 3] != '口') R = rnd.Next(0, 8);
                    data[R / 3, R % 3] = 'Ｘ';

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (data[i, j] != 'Ｘ') continue;
                            f = false;
                            // check row
                            int k = j + 1, cnt = 1;
                            while (k < 3 && data[i, k++] == 'Ｘ') cnt++;
                            k = j - 1;
                            while (k >= 0 && data[i, k--] == 'Ｘ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｘ 方獲勝！");
                                f = true; break;
                            }

                            // check column
                            cnt = 1;
                            int c = i + 1;
                            while (c < 3 && data[c++, j] == 'Ｘ') cnt++;
                            c = i - 1;
                            while (c >= 0 && data[c--, j] == 'Ｘ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｘ 方獲勝！");
                                f = true; break;
                            }

                            cnt = 1;
                            c = i + 1; k = j + 1;
                            while (c < 3 && k < 3 && data[c++, k++] == 'Ｘ') cnt++;
                            c = i - 1; k = j - 1;
                            while (c >= 0 && k >= 0 && data[c--, k--] == 'Ｘ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｘ 方獲勝！");
                                f = true; break;
                            }

                            cnt = 1;
                            c = i - 1; k = j + 1;
                            while (c >= 0 && k < 3 && data[c--, k++] == 'Ｘ') cnt++;
                            c = i + 1; k = j - 1;
                            while (c < 3 && k >= 0 && data[c++, k--] == 'Ｘ') cnt++;
                            if (cnt == 3)
                            {
                                WriteLine($"Ｘ 方獲勝！");
                                f = true; break;
                            }
                        }

                        if (f) break;
                    }
                }
                if (f)
                {
                    round++;
                    Write((round & 1) == 1 ? 'Ｏ' : 'Ｘ');
                    round &= 1;
                    WriteLine($" 方獲勝開始下一盤");
                    for (int i = 0; i < 3; i++) 
                        for (int j = 0; j < 3; j++)
                            data[i, j] = '口';
                    f = false;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _94_3
{
    internal class Program
    {
        static bool inl(int x, int y)
        {
            return x >= 1 && y >= 1 && x <= 8 && y <= 8;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("馬目前位置與一些障礙物:");
                var d = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt32);

                int x = d[0], y = d[1];

                bool[,] mp = new bool[9, 9];

                for (int i = 2; i < d.Length; i += 2)
                {
                    mp[d[i], d[i + 1]] = true;
                }

                Console.Write("輸入移動數字鍵: ");
                var t = Convert.ToInt32(Console.ReadLine());
                while (t >= 0 && t <= 7)
                {
                    int dx = x, dy = y;
                    bool f1 = false, f2 = false;
                    switch (t)
                    {
                        case 0:
                            if (!mp[x, y + 1])
                            {
                                if (!inl(x + 1, y + 2))
                                    f1 = true;
                                else
                                {
                                    x++; y += 2;
                                }
                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 1:
                            if (!mp[x, y + 1])
                            {
                                if (!inl(x - 1, y + 2))
                                    f1 = true;
                                else
                                {
                                    x--; y += 2;
                                }
                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 2:
                            if (!mp[x - 1, y])
                            {
                                if (!inl(x - 2, y + 1))
                                    f1 = true;
                                else
                                {
                                    x -= 2; y++;
                                }
                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 3:
                            if (!mp[x - 1, y])
                            {
                                if (!inl(x - 2, y - 1))
                                    f1 = true;

                                else
                                {
                                    x -= 2; y--;
                                }

                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 4:
                            if (!mp[x, y - 1])
                            {
                                if (!inl(x - 1, y - 2))
                                    f1 = true;
                                else
                                {
                                    x--; y -= 2;
                                }


                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 5:
                            if (!mp[x, y - 1])
                            {
                                if (!inl(x + 1, y - 2))
                                    f1 = true;
                                else
                                {
                                    x++; y -= 2;
                                }


                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 6:
                            if (!mp[x + 1, y])
                            {
                                if (!inl(x + 2, y - 1))
                                    f1 = true;
                                else
                                {
                                    x += 2; y--;
                                }
                            }
                            else
                            {
                                f2 = true;

                            }
                            break;

                        case 7:
                            if (!mp[x + 1, y])
                            {
                                if (!inl(x + 2, y + 1))
                                    f1 = true;
                                else
                                {
                                    x += 2; y++;
                                }
                            }
                            else
                            {
                                f2 = true;

                            }
                            break;
                    }

                    if (f1)
                        Console.WriteLine($"馬移動至新位置: {x} {y} (因出界而保持原座標)");

                    else if (f2)
                        Console.WriteLine($"馬移動至新位置: {x} {y} (因馬捆住而保持原座標)");

                    else
                        Console.WriteLine($"馬移動至新位置: {x} {y}");

                    Console.Write("輸入移動數字鍵: ");
                    t = Convert.ToInt32(Console.ReadLine());
                };

                Console.WriteLine("(結束此程式)");
            }
        }
    }
}

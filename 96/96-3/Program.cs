using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Array;
using static System.Console;
using static System.Convert;

namespace _96_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double R, G, B, r, g, b, H, S, I, h, s, i;
            while (true)
            {
                WriteLine("RGB 轉換 HSI 請輸入 1，HSI 轉換 RGB 請輸入 2");
                var checking = ReadLine();
                if (checking == "1")
                {
                    WriteLine("輸入 R G B: ");
                    var data = ConvertAll(ReadLine().Split(), ToDouble);
                    R = data[0];
                    G = data[1];
                    B = data[2];
                    // Console.WriteLine($"{R} {G} {B}");
                    r = R / (R + G + B);
                    g = G / (R + G + B);
                    b = B / (R + G + B);
                    h = Acos(0.5 * ((r - g) + (r - b)) / Pow((r - g) * (r - g) + (r - b) * (g - b), 1 / 2));
                    if (b > g) h = 2 * PI - h;
                    s = 1 - 3 * Min(r, Min(g, b));
                    i = (R + G + B) / (3 * 255);
                    H = h * 180 / PI;
                    S = s * 255;
                    I = i * 255;
                    WriteLine($"{H:F2} {S:F2} {I:F2}");
                }
                else
                {
                    WriteLine("輸入 H S I: ");
                    var data = ConvertAll(ReadLine().Split(), ToDouble);
                    H = data[0];
                    S = data[1];
                    I = data[2];

                    h = H * PI / 180;
                    s = S / 255;
                    i = I / 255;
                    var x = i * (1 - s);
                    var y = i * (1 + (s * Cos(h)) / Cos(PI / 3 - h));
                    var z = 3 * i - (x + y);
                    x = Abs(x) < 1e-10 ? 0 : x;
                    y = Abs(y) < 1e-10 ? 0 : y;
                    z = Abs(z) < 1e-10 ? 0 : z;

                    if (h < 2 * PI / 3)
                    {
                        WriteLine($"{y * 255} {z * 255} {x * 255}");
                    }

                    else if (2 * PI / 3 <= h && h < 4 * PI / 3)
                    {
                        h = h - 2 * PI / 3;
                        x = i * (1 - s);
                        y = i * (1 + (s * Cos(h)) / Cos(PI / 3 - h));
                        z = 3 * i - (x + y);
                        x = Abs(x) < 1e-10 ? 0 : x;
                        y = Abs(y) < 1e-10 ? 0 : y;
                        z = Abs(z) < 1e-10 ? 0 : z;
                        WriteLine($"{x*255} {y*255} {z * 255}");
                    }
                    else
                    {
                        h = h - 4 * PI / 3;
                        x = i * (1 - s);
                        y = i * (1 + (s * Cos(h)) / Cos(PI / 3 - h));
                        z = 3 * i - (x + y);
                        x = Abs(x) < 1e-10 ? 0 : x;
                        y = Abs(y) < 1e-10 ? 0 : y;
                        z = Abs(z) < 1e-10 ? 0 : z;
                        WriteLine($"{z * 255} {x * 255} {y * 255}");
                    }
                }
            }
        }
    }
}

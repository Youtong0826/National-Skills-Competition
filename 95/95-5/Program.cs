using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _95_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
                var data = Array.ConvertAll(Console.ReadLine().Split(), Convert.ToInt32);
                var a = data[0];
                var b = data[1];

                if (a < 50 && b < 100)
                {
                    Console.WriteLine($"{(a + b) / 2 * 6 / 10 * 5}");
                }

                else if ((a < 50 && b <= 200) || (a <= 100 && b < 100))
                {
                    Console.WriteLine($"{(a + b) / 2 * 8 / 10 * 5}");
                }

                else if ((a <= 100 && b > 200) || (a > 100 && b <= 200))
                {
                    Console.WriteLine($"{(a + b) / 2 * 12 / 10 * 5}");
                }

                else if (a > 100 && b > 200)
                {
                    Console.WriteLine($"{(a + b) / 2 * 14 / 10 * 5}");
                }
                else
                {
                    Console.WriteLine($"{(a + b) / 2 * 5}");
                }
            }
        }
    }
}

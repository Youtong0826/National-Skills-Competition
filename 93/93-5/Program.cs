using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var data = Console.ReadLine().Split();
                var R = Convert.ToInt32(data[1]);
                switch (data[0])
                {
                    case "1":
                        Console.WriteLine(600 + R * 5);
                        break;

                    case "2":
                        Console.WriteLine(Math.Max(200, Math.Abs(200 - R * 60 * 0.15)));
                        break;

                    case "3":
                        Console.WriteLine(Math.Max(66, Math.Abs(66 - Math.Max(0, R * 60 - 300) * 0.2)));
                        break;
                }
            }
        }
    }
}

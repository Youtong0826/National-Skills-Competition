using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _94_4
{
    internal class Program
    {
        static int calc(int x, double y, double z)
        {
            return (int)Math.Round(x * y / z);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                List<int> o = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    var d = Console.ReadLine().Split();
                    var x = Array.ConvertAll(d[1].Split('/'), Convert.ToDouble);
                    var y = x[0] / x[1];
                    o.Add(calc(Convert.ToInt32(d[0]), y, Convert.ToDouble(d[2])));
                }

                foreach(var t in o)
                {
                    Console.WriteLine(t);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var d = Console.ReadLine().Split();
                int H = Convert.ToInt32(d[0]), D = Convert.ToInt32(d[1]), count = 0;
                List<int> list = new List<int>();
                while (H > 0)
                {
                    list.Add(H);
                    H = H / 2 - D / 5;
                    count++;
                }

                list.Add(0);
                list.Add(count - 1);
                Console.WriteLine(string.Join(" ", Array.ConvertAll(list.ToArray(), Convert.ToString)));
            }
        }
    }
}

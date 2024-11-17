using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
                int R = Convert.ToInt32(Console.ReadLine());
                List<int> x = new List<int>(), y = new List<int>();

                for (int i = 1; i < R; i++)
                { 
                    double a = Math.Sqrt(i), b = Math.Sqrt(R - i);
                    if (Math.Floor(a) == a && Math.Floor(b) == b)
                    {
                        x.Add((int)a); 
                        y.Add((int)b);
                    }
                }
                Console.WriteLine("Count  X  Y");

                for (int i = 0; i < x.Count; i++)
                {
                    Console.WriteLine($"  {i+1}  {x[i]}  {y[i]}");
                }

                if (x.Count > 0)
                {
                    Console.WriteLine($"There have {x.Count} possible answer.");
                }
                else
                {
                    Console.WriteLine("\nSorry. No answer found.");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int Ro = 350, TB = 350, RB = 350;
                double Cl = 0.2, CB = 0.04;

                var da = Console.ReadLine().Split();
                double W = Convert.ToDouble(da[0]),
                       R = Convert.ToDouble(da[1]),
                       C = Convert.ToDouble(da[2].Contains("p") ? da[2].Substring(0, da[2].Length - 1): da[2]);

                if (W == 0)
                {
                    Console.WriteLine($"{(Ro + R) * (C + Cl)}ps");
                }
                else
                {
                    Console.WriteLine($"{(Ro + R / 2) * (C / 2 + W * CB) + TB + (RB / W + R / 2) * (C / 2 + Cl)}ps");
                }
            }
        }
    }
}

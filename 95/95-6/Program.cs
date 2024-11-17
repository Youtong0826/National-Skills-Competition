using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _95_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var s = Console.ReadLine();
                Dictionary<char, int> mp = new Dictionary<char, int>();
                List<char> list = new List<char>();
                foreach (var c in s){
                    if (mp.ContainsKey(c))
                        mp[c]++;
                    else
                    {
                        mp[c] = 1;
                        list.Add(c);
                    }
                }

                list.Sort((a, b) => mp[b] - mp[a]);
                foreach (var c in list)
                {
                    Console.Write($"\"{c}\"={mp[c]}; ");
                }
            }
        }
    }
}

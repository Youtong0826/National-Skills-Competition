using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static System.Console;
using static System.Convert;


namespace _111_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Write("輸入 10 位 key:");
                string key = ReadLine();
                Random rnd = new Random();
                char temp;
                char[] ckey = key.ToCharArray();
                WriteLine($"輸入 key: {string.Join(" ", ckey)} = 0x{Convert.ToString(ToInt32(key, 2), 16)}");
                for (int i = 0; i < ckey.Length; i++)
                {
                    var j = rnd.Next(i, 10);
                    temp = ckey[i];
                    ckey[i] = ckey[j];
                    ckey[j] = temp;   
                }
                string s = string.Join("", ckey);
                WriteLine($"重排列10: {string.Join(" ", ckey)} = 0x{Convert.ToString(ToInt32(s, 2), 16)}");

                char[] L = new char[6], R = new char[6];
                for (int i = 1; i < 5; i++)
                {
                    L[i-1] = ckey[i];
                }
                L[4] = ckey[0];

                for (int i = 6; i < 10; i++)
                {
                    R[i - 6] = ckey[i];
                }
                R[4] = ckey[5];

                for (int i = 0; i < 10; i++)
                {
                    ckey[i] = i >= 5 ? R[i-5]: L[i];
                }
                // WriteLine(string.Join(" ", key1));
                // WriteLine(string.Join(" ", key2));
                // WriteLine(string.Join(" ", ckey));
                s = string.Join("", ckey).Replace("\0", "");
                WriteLine($"左旋轉 1: {string.Join(" ", ckey)} = 0x{Convert.ToString(ToInt32(Convert.ToString(s), 2), 16)}");
                
                var key1 = new char[8];
                for (int i = 0; i < 8; i++)
                {
                    var j = rnd.Next(i, 10);
                    temp = ckey[i];
                    ckey[i] = ckey[j];
                    ckey[j] = temp;
                    key1[i] = ckey[j];
                }
                WriteLine($"key1輸出: {string.Join(" ", key1)} = 0x{Convert.ToString(ToInt32(string.Join("", key1), 2), 16)}");
                for (int i = 2; i < 5; i++)
                {
                    L[i - 2] = s[i];
                }
                L[3] = s[0]; L[4] = s[1];

                for (int i = 7; i < 10; i++)
                {
                    R[i - 7] = s[i];
                }
                R[3] = s[5]; R[4] = s[6];
                for (int i = 0; i < 10; i++)
                {
                    ckey[i] = i >= 5 ? R[i - 5] : L[i];
                }
                
                s = (string.Join("", L) + string.Join("", R)).Replace("\0", "");
                WriteLine($"左旋轉 2: {string.Join(" ", ckey)} = 0x{Convert.ToString(ToInt32(s, 2), 16)}");
                for (int i = 0; i < 8; i++)
                {
                    var j = rnd.Next(i, 10);
                    temp = ckey[i];
                    ckey[i] = ckey[j];
                    ckey[j] = temp;
                    key1[i] = ckey[j];
                }
                WriteLine($"key2輸出: {string.Join(" ", key1)} = 0x{Convert.ToString(ToInt32(string.Join("", key1), 2), 16)}");
            }
        }
    }
}

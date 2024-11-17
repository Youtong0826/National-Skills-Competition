using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _96_4
{
    internal class Program
    {
        static bool isNum(char c)
        {
            return c >= '0' && c <= '9';
        }

        static bool isAddOrSub(char c)
        {
            return c == '+' || c == '-';
        }

        static bool isMulOrDiv(char c)
        {
            return c == '*' || c == '/';
        }

        static bool isOps(char c)
        {
            return isAddOrSub(c) || isMulOrDiv(c);
        }

        static string infixToPostfix(string s)
        {
            List<string> result = new List<string>();
            Stack<char> stk = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ') continue;
                char c = s[i];
                if (isNum(c))
                {
                    result.Add(c.ToString());
                }
                else if (isAddOrSub(c))
                {

                    while (stk.Count > 0 && isOps(stk.Peek()))
                    {
                        result.Add(stk.Pop().ToString()); 
                    }
                    stk.Push(c);
                }
                else if (isMulOrDiv(c))
                {
                    while (stk.Count > 0 && isMulOrDiv(stk.Peek()))
                    {
                        result.Add(stk.Pop().ToString());
                    }
                    stk.Push(c);
                }
                else
                {
                    int st = i + 1;
                    while (++i < s.Length && s[i] != ')') ;
                    result.Add(infixToPostfix(s.Substring(st, i - st)));
                }

            }

            while (stk.Count > 0)
            {
                result.Add(stk.Pop().ToString());
            }

            return string.Join(" ", result);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                string s = ReadLine();
                WriteLine(infixToPostfix(s));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

// 本題我是參考資訊之芽的計算幾何講義，建議大家可以去讀讀看

namespace _93_3
{
    class Point
    {
        public double x;
        public double y;
        public Point (double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator + (Point left, Point right)
        {
            return new Point(left.x + right.x, left.y + right.y);
        }
        public static Point operator - (Point left, Point right)
        {
            return new Point(left.x - right.x, left.y - right.y);
        }

        public static double operator * (Point left, Point right)
        {
            return left.x * right.x + left.y * right.y;
        }
        public static double operator ^ (Point left, Point right)
        {
            return left.x * right.y - left.y * right.x;
        }
    }
    class Program
    {
        static int sign(double x)
        {
            if (x < 1e-7)
                return 0;

            return x > 0 ? 1 : -1;
        }

        static int ori(Point O, Point A, Point B)
        {
            return sign((A-O)^(B-O));
        }

        static bool btw(Point O, Point A, Point B)
        {
            if (ori(O, A, B) != 0)
                return false;

            return sign((A - O) ^ (B - O)) <= 0;
        }

        static bool banana(Point A, Point B, Point C, Point D)
        {
            double a = ori(A, B, C);
            double b = ori(A, B, D);
            double c = ori(C, D, A);
            double d = ori(C, D, B);

            if (a == 0 && b == 0)
                return btw(A, B, C)
                    || btw(A, B, D)
                    || btw(C, D, A)
                    || btw(C, D, B);

            return a * b <= 0 && c * d <= 0;
        }

        static double[] read()
        {
            return Array.ConvertAll(Console.ReadLine().Split(), Convert.ToDouble);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("A(X1, X2)=");
                double[] Ad = read();
                Console.Write("B(X1, X2)=");
                double[] Bd = read();
                Console.Write("C(X1, X2)=");
                double[] Cd = read();
                Console.Write("D(X1, X2)=");
                double[] Dd = read();
                
                if (banana(
                    new Point(Ad[0], Ad[1]), 
                    new Point(Bd[0], Bd[1]), 
                    new Point(Cd[0], Cd[1]), 
                    new Point(Dd[0], Dd[1])
                ))
                {
                    Console.WriteLine("線有交叉");
                }
                else
                {
                    Console.WriteLine("線無交叉");
                }
            }
        }
    }
}

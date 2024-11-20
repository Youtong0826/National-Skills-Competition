using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace _111_1
{
    internal class Program
    {
        static long[,] matMul(long[,] A, long[,] B)
        {
            long[,] temp = new long[2, 2];
            for (int i = 0; i < 2; i++) for (int j = 0; j < 2; j++)
            {
               temp[i, j] = 0;
               for (int k = 0; k < 2; k++)
               {
                   temp[i, j] += A[i, k] * B[k, j];
               }
            }
            return temp;
        }

        static long[,] matPow(long[,] A, int N)
        {
            if (N == 0 || N == 1)
            {
                return new long[2,2] { { 1, 1}, { 1, 0} };
            }
            if ((N & 1) == 1)
            {
                return matMul(A, matPow(A, N - 1));
            }

            var temp = matPow(A, N / 2);
            return matMul(temp, temp);
        }

        static void Main(string[] args)
        {
            while (true) {
                var N = ToInt32(ReadLine());

                long[,] mat = new long[2, 2]
                {
                    { 1, 1 },
                    { 1, 0 }
                };

                matPow(mat, N);
            }
            
        }
    }
}

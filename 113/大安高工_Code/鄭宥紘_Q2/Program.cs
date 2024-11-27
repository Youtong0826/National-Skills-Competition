namespace 鄭宥紘_Q2
{
    static class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("輸入物品的總數量: ");
                int n = int.Parse(Console.ReadLine()!);
                Console.Write("輸入背包的最大承載量(10的倍數): ");
                int maxW = int.Parse(Console.ReadLine()!);
                while (maxW % 10 != 0)
                {
                    Console.Write("不是10的倍數，請重新輸入: ");
                    maxW = int.Parse(Console.ReadLine()!);
                }
                Console.WriteLine("輸入各物品的重量與價值:");
                int[] wArray = new int[n + 1];
                int[] vArray = new int[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"物品 {i} - 重量: ");
                    wArray[i] = int.Parse(Console.ReadLine()!);
                    Console.Write($"物品 {i} - 價值: ");
                    vArray[i] = int.Parse(Console.ReadLine()!);
                }
                Console.WriteLine();
                int[][] cArrayArray = new object[n + 1].Select(_ => new int[maxW / 10 + 1]).ToArray();
                for (int i = 0; i <= n; i++)
                {
                    for (int w = 0; w <= maxW; w += 10)
                    {
                        if (i == 0 || w == 0)
                        {
                            cArrayArray[i][w / 10] = 0;
                        }
                        else if (wArray[i] > w)
                        {
                            cArrayArray[i][w / 10] = cArrayArray[i - 1][w / 10];
                        }
                        else if (i > 0 && w >= wArray[i])
                        {
                            cArrayArray[i][w / 10] = int.Max(vArray[i] + cArrayArray[i - 1][(w - wArray[i]) / 10], cArrayArray[i - 1][w / 10]);
                        }
                    }
                }
                int maxLength = cArrayArray.SelectMany(cArray => cArray).Select(c => $"{c}".Length).Max();
                foreach (int[] cArray in cArrayArray)
                {
                    Console.WriteLine(string.Join(' ', cArray.Select(c => $"{c}".PadLeft(maxLength))));
                }
                Console.WriteLine();
            }
        }
    }
}
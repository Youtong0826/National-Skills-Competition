namespace 鄭宥紘_Q5
{
    static class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("***模擬今彩539***");
                List<int> writeNumbers = [];
                while (writeNumbers.Count < 5)
                {
                    int writeNumber = Random.Shared.Next(1, 40);
                    if (!writeNumbers.Contains(writeNumber))
                    {
                        writeNumbers.Add(writeNumber);
                    }
                }
                Console.WriteLine($"今彩539之5個1~39號碼:  {string.Join(' ', writeNumbers.Select(writeNumber => $"{writeNumber,2}"))}");
                Console.Write("請輸入存今彩539之5個號碼的檔名: ");
                string writeFilename = Console.ReadLine()!;
                Console.WriteLine();
                File.WriteAllText(writeFilename, string.Join(' ', writeNumbers));
                Console.Write("請輸入要讀今彩539之5個號碼的檔名: ");
                string readFilename = Console.ReadLine()!;
                int[] readNumbers = File.ReadAllText(readFilename).Split(' ').Select(int.Parse).ToArray();
                double readAverage = readNumbers.Average();
                Console.WriteLine($"今彩539之5個號碼的算數平均數: {readAverage:F6}");
                double readH = 5 / readNumbers.Select(readNumber => 1.0 / readNumber).Sum();
                Console.WriteLine($"今彩539之5個號碼的調和平均數: {readH:F6}");
                double readG = double.Pow(readNumbers.Aggregate((a, b) => a * b), 1.0 / 5);
                Console.WriteLine($"今彩539之5個號碼的幾何平均數: {readG:F6}");
                Console.WriteLine();
                Console.WriteLine($"排序前的資料: {string.Join(' ', readNumbers.Select(numberToSort => $"{numberToSort,2}"))}");
                Console.WriteLine();
                for (int i = 1; i <= 4; i++)
                {
                    (int minNumber, int minIndex) = readNumbers[(i - 1)..].Select((readNumber, index) => (readNumber, index + i - 1)).MinBy(item => item.readNumber);
                    int tempNumber = readNumbers[i - 1];
                    readNumbers[i - 1] = minNumber;
                    readNumbers[minIndex] = tempNumber;
                    Console.WriteLine($"第  {i} 次選擇: {string.Join(' ', readNumbers.Select((readNumber, index) => $"{readNumber,2}{(index == minIndex ? "*" : "")}"))}");
                    Console.WriteLine($"              {string.Join(' ', Enumerable.Repeat("--", i).Select((s, index) => index == minIndex ? $"{s} " : s))}");
                }
                Console.WriteLine($"排序後的資料: {string.Join(' ', readNumbers.Select(readNumber => $"{readNumber,2}"))}");
                Console.WriteLine();
                Console.WriteLine($"今彩539之5個號碼的中位數: {readNumbers[2]}");
                Console.WriteLine();
            }
        }
    }
}
using System.Text.Json.Nodes;

namespace 鄭宥紘_Q4
{
    static class Program
    {
        static void Main()
        {
            JsonNode jsonNode = JsonNode.Parse(File.ReadAllText("huffman.json"))!;
            while (true)
            {
                Console.Write("請輸入內文為英文的檔名(.txt): ");
                string filename = Console.ReadLine()!.Trim();
                Console.WriteLine($"{filename} 的檔案內容");
                string content = File.ReadAllText(filename);
                Console.WriteLine(content);
                Console.WriteLine();
                string after = "";
                foreach (char c in content)
                {
                    after += $"{jsonNode[$"{c}"]}";
                }
                Console.WriteLine("壓縮後的編碼:");
                foreach (string[] chunk in after.Chunk(8).Select(chunk => string.Join("", chunk)).Chunk(5))
                {
                    Console.WriteLine($"{string.Join(' ', chunk)}");
                }
                after += (after.Length % 8) switch
                {
                    1 => "1111010",
                    2 => "111101",
                    3 => "11110",
                    4 => "1110",
                    5 => "000",
                    6 => "00",
                    7 => "0",
                    _ => ""
                };
                double ratio = (double)after.Length / 8 / content.Length;
                Console.WriteLine($"壓縮比:  {ratio:F2}");
                string saveFilename = $"{filename[..^4]}.bin";
                Console.WriteLine($"壓縮後檔案名稱:  {saveFilename}");
                byte[] bytes = after.Chunk(8).Select(chunk => string.Join("", chunk)).Select(s => byte.Parse(s, System.Globalization.NumberStyles.BinaryNumber)).ToArray();
                File.WriteAllBytes(saveFilename, bytes);
                Console.WriteLine("存入壓縮檔的編碼:");
                foreach (string[] chunk in after.Chunk(8).Select(chunk => string.Join("", chunk)).Chunk(5))
                {
                    Console.WriteLine($"{string.Join(' ', chunk)}");
                }
                Console.WriteLine();
            }
        }
    }
}
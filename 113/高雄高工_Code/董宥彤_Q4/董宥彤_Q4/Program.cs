using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using static System.Convert;
using static System.Math;
using System.Linq.Expressions;

namespace 董宥彤_Q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>() {
                {"e", "001"},
                {" ", "110"},
                {"s", "0000"},
                {"h", "0001"},
                {"i", "0100"},
                {"n", "0101"},
                {"o", "0111"},
                {"a", "1000"},
                {"t", "1010"},
                {"l", "10010"},
                {"d", "10011"},
                {"r", "11111"},
{"p", "011000"},
{",", "011001"},
{"g", "011010"},
{"w", "101100"},
{"f", "101110"},
{"y", "101111"},
{"m", "111000"},
{"c", "111001"},
{"\n", "111011"},
{"u", "111100"},
{"v", "1011010"},
{".", "1110100"},
{"b", "1111011"},
{"I", "01101111"},
{"k", "10110111"},
{"\"", "11101011"},
{"B", "011011000"},
{";", "101101100"},
{"-", "111010100"},
{"M", "111101000"},
{"S", "0110110010"},
{"A", "0110110011"},
{"D", "0110110100"},
{"j", "0110110101"},
{"q", "0110110110"},
{"W", "0110111000"},
{"C", "0110111001"},
{"'", "0110111011"},
{"H", "1011011010"},
{"L", "1011011011"},
{"x", "1110101011"},
{"_", "1111010010"},
{"E", "1111010100"},
{"z", "1111010101"},
{"T", "1111010110"},
{"N", "01101101110"},
{"J", "01101110100"},
{"P", "01101110101"},
{"Y", "11101010100"},
{"?", "11110100110"},
{"!", "11110100111"},
{"F", "111010101010"},
{"O", "111101011100"},
{"R", "111101011101"},
{"G", "111101011111"},
{"1", "0110110111101"},
{"K", "1110101010110"},
{"/", "01101101111000"},
{"(", "01101101111100"},
{")", "01101101111101"},
{"X", "01101101111111"},
{"*", "11101010101111"},
{"V", "11110101111000"},
// {",", "11110101111010"},
{"U", "11110101111011"},
{"7", "011011011110010"},
{"4", "011011011110011"},
{"6", "011011011111100"},
{"2", "111010101011100"},
{"5", "1110101010111010"},
{"3", "1110101010111011"},
{"8", "1111010111100100"},
{"&", "1111010111100101"},
{"0", "1111010111100111"},
{"[", "01101101111110100"},
{"]", "01101101111110101"},
{"9", "11110101111001101"},
{"^", "011011011111101100"},
{"{", "011011011111101101"},
{"}", "011011011111101110"},
{"Z", "011011011111101111"},
{"@", "1111010111100110000"},
{"#", "1111010111100110001"},
{"$", "1111010111100110010"},
        {"%", "11110101111001100110"},
        {"Q", "11110101111001100111"}
            };

            while (true) {
                Write("請輸入內文為英文的檔名(.txt): ");
                var file = ReadLine();
                var data = File.ReadAllText(file);
                WriteLine($"{file} 的檔案內容: ");
                Write(data);
                WriteLine();
                string encode = "";
                foreach (var c in data)
                {
                    encode += dic[$"{c}"];
                }
                int i = 0;
                List<string> list = new List<string>();
                string[] ns = new string[7] { "0", "00", "000", "1110", "11110", "111101", "1111010" };
                for (; i < encode.Length - 7; i += 8) { 
                    list.Add(encode.Substring(i, 8));
                }
                if (encode.Length - i != 0) 
                    list.Add(encode.Substring(i, encode.Length - i));
                WriteLine("壓縮後的編碼: ");
                foreach (var c in list)
                {
                    Write($"{c} ");
                }
                // WriteLine($"{encode.Length} {i} {list[list.Count - 1].Length}");

                if (list[list.Count - 1].Length < 8) 
                    list[list.Count - 1] += ns[8 - (encode.Length - i) - 1];
                WriteLine();
                WriteLine($"壓縮比 {((double)list.Count / (double)data.Length):f2}");
                file = file.Replace("txt", "bin");
                WriteLine($"壓縮後的檔案名稱 {file}");
                FileStream fs = File.Open(file, FileMode.OpenOrCreate);
                WriteLine("存入壓縮檔的編碼: ");
                foreach (var c in list)
                {
                    Write($"{c} ");
                    fs.WriteByte(ToByte(c, 2));
                }
                fs.Close();
                WriteLine();
            }

        }
    }
}

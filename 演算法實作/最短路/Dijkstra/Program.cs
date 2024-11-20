using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using static System.Console;
using static System.Convert;
using static System.Environment;
using static System.Math;

namespace Dijkstra
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            while (true)
            {
                Write("輸入總點數 N 及總邊數 M: ");
                var data = Array.ConvertAll(ReadLine().Split(), ToInt32);
                int N = data[0], M = data[1];
                WriteLine("請輸入 M 條邊:");
                
                List<Tuple<int, int>>[] graph = new List<Tuple<int, int>>[N + 1];
                for (int i = 0; i < M; i++)
                {
                    data = Array.ConvertAll(ReadLine().Split(), ToInt32);
                    if (graph[data[0]] == null)
                        graph[data[0]] = new List<Tuple<int, int>>();
                    graph[data[0]].Add(new Tuple<int, int>(data[1], data[2]));

                }

                int[] dis = new int[N + 1];
                bool[] vis = new bool[N + 1]; // 可加 vis 也可不加，加了速度快了一點。

                for (int i = 1; i <= N; i++)
                {
                    dis[i] = int.MaxValue;
                    vis[i] = false;
                }

                dis[1] = 0;
                SortedSet<Tuple<int, int>> edges = new SortedSet<Tuple<int, int>>();
                edges.Add(new Tuple<int, int>(dis[1], 1));
                while (edges.Count > 0)
                {
                    var edge = edges.Min;
                    edges.Remove(edges.ElementAt(0));
                    if (vis[edge.Item2] || graph[edge.Item2] == null) continue;
                    vis[edge.Item2] = true;
                    foreach (var v in graph[edge.Item2])
                    {
                        if (dis[v.Item1] > dis[edge.Item2] + v.Item2)
                        {
                            dis[v.Item1] = dis[edge.Item2] + v.Item2;
                            edges.Add(new Tuple<int, int>(dis[v.Item1], v.Item1));
                        }
                    }
                }

                for (int i = 2; i <= N; i++)
                {
                    WriteLine($"1 to {i} min cost: {dis[i]}");
                }
            }
        }
    }
}

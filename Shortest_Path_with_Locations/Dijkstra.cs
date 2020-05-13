using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akinn
{
    class Dijkstra
    {
        static int V = 7;
        int minDistance(double[] dist, bool[] sptSet)
        {

            double min = int.MaxValue;
            int min_index = -1;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

        public void dijkstra(double[,] graph, int src, int arrival)
        {
            double[] dist = new double[V];

            int[,] paths = new int[10, 2];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    paths[i, j] = 0;
                }
            }

            bool[] sptSet = new bool[V];


            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            int a = 0; int b = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = minDistance(dist, sptSet);
                sptSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                        paths[a, b] = v + 1;
                        b++;
                        paths[a, b] = u + 1;
                        a++;
                        b = 0;
                    }

                }
            }
            int hold = 0;
            int[] print = { 0, 0, 0, 0, 0, 0 };
            int t = 5;
            for (int i = 9; i >= 0; i--)
            {
                if (paths[i, 0] != 0)
                {
                    if (paths[i, 0] == hold)
                    {
                        //Console.Write(paths[i, 1] + " ");
                        print[t] = paths[i, 1];
                        t--;
                        hold = paths[i, 1];
                        if (hold == src) break;
                    }
                    if (paths[i, 0] == arrival + 1)
                    {
                        print[t] = paths[i, 1];
                        t--;
                        //Console.Write(paths[i, 1] + " ");
                        hold = paths[i, 1];
                        if (hold == src) break;
                    }
                }
            }
            Console.Write("The visited locations are: ");
            for (int i = 0; i < 6; i++)
            {
                if (print[i] != 0)
                {
                    Console.Write(print[i] + " - ");
                }

            }
            Console.WriteLine(arrival + 1);
            Console.WriteLine("Shortest distance between {0} - {1} is: {2} units", src + 1, arrival + 1, dist[arrival]);
            Console.WriteLine("Complexity of the algorithm is: O(V^2) where V is the vertex which is equal to 7.");

        }
    }
}

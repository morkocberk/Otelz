using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akinn
{
    class Program
    {
        static void Main(string[] args)
        {            
            double[,] Aquaria = new double[,] { { 350, 165.5 } };
            double[,] Fish = new double[,] { { 256.6, 92.3 } };
            double[,] Hall = new double[,] { { 92.5, 86.4 } }; //City Hall
            double[,] Theater = new double[,] { { 40.8, 72.35 } };
            double[,] Park = new double[,] { { 90.5, 302.1 } };
            double[,] Mall = new double[,] { { 102.3, 10.26 } };
            double[,] Concert = new double[,] { { 120.5, 5.5 } };


            double path_AF = Math.Sqrt(Math.Pow((Aquaria[0, 0] - Fish[0, 0]), 2) + Math.Pow((Aquaria[0, 1] - Fish[0, 1]), 2));
            double path_FC = Math.Sqrt(Math.Pow((Fish[0, 0] - Concert[0, 0]), 2) + Math.Pow((Fish[0, 1] - Concert[0, 1]), 2));
            double path_FM = Math.Sqrt(Math.Pow((Fish[0, 0] - Mall[0, 0]), 2) + Math.Pow((Fish[0, 1] - Mall[0, 1]), 2));
            double path_CM = Math.Sqrt(Math.Pow((Concert[0, 0] - Mall[0, 0]), 2) + Math.Pow((Concert[0, 1] - Mall[0, 1]), 2));
            double path_MP = Math.Sqrt(Math.Pow((Mall[0, 0] - Park[0, 0]), 2) + Math.Pow((Mall[0, 1] - Park[0, 1]), 2));
            double path_MH = Math.Sqrt(Math.Pow((Mall[0, 0] - Hall[0, 0]), 2) + Math.Pow((Mall[0, 1] - Hall[0, 1]), 2));
            double path_MT = Math.Sqrt(Math.Pow((Mall[0, 0] - Theater[0, 0]), 2) + Math.Pow((Mall[0, 1] - Theater[0, 1]), 2));
            double path_HP = Math.Sqrt(Math.Pow((Hall[0, 0] - Park[0, 0]), 2) + Math.Pow((Hall[0, 1] - Park[0, 1]), 2));
            double path_HT = Math.Sqrt(Math.Pow((Hall[0, 0] - Theater[0, 0]), 2) + Math.Pow((Hall[0, 1] - Theater[0, 1]), 2));
            double path_TP = Math.Sqrt(Math.Pow((Theater[0, 0] - Park[0, 0]), 2) + Math.Pow((Theater[0, 1] - Park[0, 1]), 2));

            double[,] Graph = new double[,] { { 0, path_AF, 0, 0, 0, 0, 0 },
                                      { path_AF, 0, 0, 0, 0, 0, path_FC },
                                      { 0, 0, 0, path_HT, path_HP, path_MH, 0 },
                                      { 0, 0, path_HT, 0, path_TP, path_MT, 0 },
                                      { 0, 0, path_HP, 0, 0, path_MP, 0 },
                                      { 0, path_FM, path_MH, path_MT, path_MP, 0, path_CM },
                                      { 0, path_FC, 0, 0, 0, path_CM, 0 }};

            int starting, arrival;

            Console.WriteLine("1 - Aquaria Aquarium");
            Console.WriteLine("2 - Big Fish Natural Museum");
            Console.WriteLine("3 - City Hall");
            Console.WriteLine("4 - Deep Ones Movie Theater");
            Console.WriteLine("5 - Elder Park");
            Console.WriteLine("6 - Fhtagn Mall");
            Console.WriteLine("7 - Great Old Ones Concert Hall");
            Console.Write("Please enter the starting location: ");
            starting = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter the arrival location: ");
            arrival = Convert.ToInt32(Console.ReadLine());

            Dijkstra d = new Dijkstra();
            d.dijkstra(Graph, (starting - 1), (arrival - 1));
            Console.ReadLine();

            //Q1
            //Complexity of the algorithm is O(V^2) where V is the vertex which is equal to 7 in our case.
            //Q2
            //Dijkstra's algorithm was used to calculate the shortest path in the graph given. It is much more efficient in comparision with Floyd's algorithm
            //when the graph does not contain any negative numbers. In other words, since the graph we have has no negative number, it is more suitable to use 
            //Dijkstra's algorithm in terms of efficiency and performance. The algorithm basically starts working with marking all the vertexes unvisited and it
            //takes the selected location as a source which is current. Then, the cost of the adjacent vertexes are written. The cost is determined 0 for the vertexes
            //that does not have adjacency and this is applied to all the vertexes of the graph. All the visited vertexes are marked as visited and if there is a path
            //that has a lower cost than the previous one, the cost is re-written as the lowest cost for the specific vertex. When all the vertexes are visited and
            //there is no such a vertex that has a lower cost, the algorithm is over.
            //Q3
            //Adjacency matrix is a square matrix used to represent a finite graph. The elements of the matrix indicate whether pairs of vertices are adjacent
            //or not in the graph. It is exactly used as we've initialized in the variable of "graph".
        }
    }
}

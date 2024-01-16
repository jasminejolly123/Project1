using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace Project1
{
    

        public class Dijkstra
        {
            static int num = 9;
            int minDistance(int[] dist,
                            bool[] sptSet)
            {
                int min = int.MaxValue, min_index = -1;

                for (int i = 0; i < num; i++)
                    if (sptSet[i] == false && dist[i] <= min)
                    {
                        min = dist[i];
                        min_index = i;
                    }

                return min_index;
            }

            void printSolution(int[] dist, int n)
            {
                Console.Write("Vertex     Distance "
                              + "from Source\n");
                for (int i = 0; i < num; i++)
                    Console.Write(i + " \t\t " + dist[i] + "\n");
            }
            void dijkstra(int[,] graph, int src)
            {
                int[] dist = new int[num]; 
                bool[] sptSet = new bool[num];

                for (int i = 0; i < num; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                }

                dist[src] = 0;

                for (int count = 0; count < num - 1; count++)
                {
                    int u = minDistance(dist, sptSet);
                    sptSet[u] = true;
                    for (int v = 0; v < num; v++)
                    {
                        if (!sptSet[v] && graph[u, v] != 0 &&
                            dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                            dist[v] = dist[u] + graph[u, v];
                    }
                }

                printSolution(dist, num);
            }

            public static void Main()
            {
                int[,] graph = new int[,] { { 0, 5, 0, 0, 0, 2, 0, 0, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 7, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 4, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 3, 0, 0, 0, 7 },
                                      { 0, 0, 0, 0, 5, 0, 6, 7, 0 } };
                Dijkstra t = new Dijkstra();
                t.dijkstra(graph, 0);
            }
        }
    }


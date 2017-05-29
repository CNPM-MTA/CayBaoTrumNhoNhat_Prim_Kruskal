using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalSpanningTree
{
    class Kruskal
    {
        /* T(Vt, Et) thuộc G
         - Sắp xếp độ dài các cạnh của đt theo thứ tự tăng dần
         - Thêm lần lượt các cạnh đó theo thứ tự tăng dần vào Vt sao cho: ko tạo thành chu trình
         - Thoát khi số cạnh là n-1
             */
        public struct Edge
        {
            public int x;
            public int y;
            public int Weight;
        }
        public struct Graph
        {
            public int VerticesCount; //dem so dinh
            public int EdgesCount;//dem so canh
            public Edge[] Edge;
        }
        public void Print(Edge[] edge, int e)
        {
            int i;
            for(i = 0; i< e; i++)
            {
                Console.WriteLine(edge[i].x + " - " + edge[i].y + " : " + edge[i].Weight);
            }
        }
        //dem so canh 
        public int EdgesCount(int number, int [,] tree)
        {
            int i, j, count = 0;
            for (i = 0; i < number; i++)
            {
                for (j = i + 1; j < number; j++)
                {
                    if (tree[i, j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public Graph Sort(int number, int[,] tree)
        {
            int i, j, count = 0;
            Graph graph = new Graph();
            graph.EdgesCount = EdgesCount(number, tree);
            graph.Edge = new Edge[graph.EdgesCount];
            graph.VerticesCount = number;
            
            for (i = 0; i < number; i++)
            {
                for (j = i + 1; j < number; j++)
                {
                    if (tree[i, j] > 0)
                    {
                        graph.Edge[count].x = i;
                        graph.Edge[count].y = j;
                        graph.Edge[count].Weight = tree[i, j];
                        count++;
                    }
                    
                }
            }
            Edge temp;
            for (i = 0; i < graph.EdgesCount; i++)
            {
                for (j = graph.EdgesCount - 1; j > i; j--)
                {
                    if (graph.Edge[i].Weight >= graph.Edge[j].Weight)
                    {
                        temp = graph.Edge[i];
                        graph.Edge[i] = graph.Edge[j];
                        graph.Edge[j] = temp;
                    }
                }
            }
            return graph;
        }
        public void func_Kruskal(int number, int[,] tree)
        {
            Graph graph = Sort(number, tree);
            int i, v, e = 0, T = 0, temp, count = 0;
            int[] rank = new int[graph.VerticesCount];
            for (v = 0; v < graph.VerticesCount; v++)
                rank[v] = 0;
            Edge[] resultEdge = new Edge[graph.VerticesCount];
            e = 0; count = 0;
            while (count < graph.VerticesCount - 1)
            {
                if (rank[graph.Edge[e].x] == rank[graph.Edge[e].y] && rank[graph.Edge[e].x] == 0)
                {
                    T++;
                    rank[graph.Edge[e].x] = T;
                    rank[graph.Edge[e].y] = T;
                    resultEdge[count] = graph.Edge[e]; count++;
                }
                else if (rank[graph.Edge[e].x] != 0 && rank[graph.Edge[e].y] == 0)
                {
                    rank[graph.Edge[e].y] = rank[graph.Edge[e].x];
                    resultEdge[count] = graph.Edge[e]; count++;
                }
                else if (rank[graph.Edge[e].x] == 0 && rank[graph.Edge[e].y] != 0)
                {
                    rank[graph.Edge[e].x] = rank[graph.Edge[e].y];
                    resultEdge[count] = graph.Edge[e]; count++;
                }
                else if (rank[graph.Edge[e].x] != 0 && rank[graph.Edge[e].y] != rank[graph.Edge[e].x])
                {
                    temp = rank[graph.Edge[e].x];
                    for (i = 0; i < graph.VerticesCount; i++)
                        if (rank[i] == temp)
                            rank[i] = rank[graph.Edge[e].y];
                    resultEdge[count] = graph.Edge[e]; count++;
                }
                e++;

            } 
            Print(resultEdge, graph.VerticesCount-1);
        } 

    }
}

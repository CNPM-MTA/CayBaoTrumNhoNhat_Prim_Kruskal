using MiniSpanningTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Prim prim = new Prim();
            int[,] a = new int[7, 7] {
                { 0, 3, -1, 1, -1, 3, -1},
                { 3,0, 4, -1, -1, 6, -1},
                {-1, 4,0, 3, 7, -1, 5 },
                { 1, -1, 3,0, 6, 2, -1},
                { -1, -1, 7, 6,0, 5, -1},
                { 3, 6, -1, 2, 5, 0, 1},
                { -1, -1, 5, -1, -1, 1, 0} };
            prim.func_Prim(7, a);

            Kruskal kruskal = new Kruskal();
            kruskal.func_Kruskal(7, a);

            Console.ReadKey();

        }
    }

}

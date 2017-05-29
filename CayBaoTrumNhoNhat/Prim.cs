using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSpanningTree
{
    class Prim
    {
        /*Ý tường: 
            - T = G(Vt, Et)
            - Chọn 1 đỉnh tùy ý vào Vt
            - Khi mà số cạnh < (n-1)
            Chọn trong các cạnh còn lại nối với Vt có trọng số nhỏ nhất thì thêm vào Vt
            Thêm đỉnh đó vào Et
         */
        public void func_Prim(int number, int[,] arr)
        {
            int[] Lowcost = new int[number];//Lowcost[i] - khoảng cách nhỏ nhất trong các kc từ đỉnh i đến các đỉnh trong Vt
            int[] Closest = new int[number];//Closest[i] - giá trị của đỉnh gần kề i, có trọng số nhỏ nhất tới các đỉnh thuộc Vt
            bool[] Checked = new bool[number];
            int i, j, k, Min;
            Checked[0] = true;
            for (i = 1; i < number; i++)
            {
                Lowcost[i] = arr[0, i];
                Closest[i] = 0;
                Checked[i] = false;
            }
            for (i = 1; i < number; i++)
            {
                k = MinKey(number, Lowcost, Checked);
                Min = Lowcost[2];
                for (j = 1; j < number; j++)
                    if (Lowcost[j] < Min && Lowcost[j] >= 0 && !Checked[j])
                    {
                        Min = Lowcost[j];
                        k = j;
                    }
                Console.WriteLine((k + 1) + " " + (Closest[k] + 1));
                //Lowcost[k] = -1;
                Checked[k] = true;
                //Khởi động lại Closest[] và Lowcost[]
                for (j = 1; j < number; j++)
                {
                    if (((arr[k, j] < Lowcost[j] && arr[k, j] > 0) || (Lowcost[j] == -1 && arr[k, j] > 0)) && !Checked[j])
                    {
                        Lowcost[j] = arr[k, j];
                        Closest[j] = k;
                    }
                }
            }
        }
        public int MinKey(int number, int[] Lowcost, bool[] Checked)
        {
            int i;
            int min = int.MaxValue;
            int minIndex = -1;
            for(i= 0; i< number; i++)
            {
                if (Lowcost[i] < min && !Checked[i] && Lowcost[i] > 0)
                {
                    min = Lowcost[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}

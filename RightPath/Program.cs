using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[15][];

            arr[0] = new int[1] { 215 };
            arr[1] = new int[2] { 192, 124 };
            arr[2] = new int[3] { 117, 269, 442 };
            arr[3] = new int[4] { 218, 836, 347, 235 };
            arr[4] = new int[5] { 320, 805, 522, 417, 345 };
            arr[5] = new int[6] { 229, 601, 728, 835, 133, 124 };
            arr[6] = new int[7] { 248, 202, 277, 433, 207, 263, 257 };
            arr[7] = new int[8] { 359, 464, 504, 528, 516, 716, 871, 182 };
            arr[8] = new int[9] { 461, 441, 426, 656, 863, 560, 380, 171, 923 };
            arr[9] = new int[10] { 381, 348, 573, 533, 448, 632, 387, 176, 975, 449 };
            arr[10] = new int[11] { 223, 711, 445, 645, 245, 543, 931, 532, 937, 541, 444 };
            arr[11] = new int[12] { 330, 131, 333, 928, 376, 733, 017, 778, 839, 168, 197, 197 };
            arr[12] = new int[13] { 131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928 };
            arr[13] = new int[14] { 223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121 };
            arr[14] = new int[15] { 924, 622, 911, 233, 325, 139, 721, 218, 253, 223, 107, 233, 230, 124, 233 };

            int max = GetMaxSumPath(arr, 0, 0);

            Console.WriteLine("Max sum: " + max);
        }

        private static int GetMaxSumPath(int[][] arr, int x, int y)
        {
            int current = arr[x][y];
            Console.WriteLine(current);

            bool isEven = IsEven(current);

            ///Next round indexes 
            int nextX = 0;
            int nextY = 0;

            ///For-each row in the array
            if (arr.Length > x + 1)
            {
                ///children of an item in the array
                int left = arr[x + 1][y];
                int right = arr[x + 1][y + 1];

                bool lIsEven = IsEven(left);
                bool rIsEven = IsEven(right);

                ///as we go down all the time never goes back
                nextX = x + 1;
                if (isEven)
                {
                    if (!lIsEven)
                    {
                        nextY = y;
                    }
                    if (!rIsEven && right >= left) ///override if more that left
                    {
                        nextY = y + 1;
                    }
                }
                else
                {
                    if (lIsEven)
                    {
                        nextY = y;
                    }
                    if (rIsEven && right >= left) ///override if more that left
                    {
                        nextY = y + 1;
                    }
                }
            }
            else
                return current;

            ///Return sum
            return GetMaxSumPath(arr, nextX, nextY) + current;
        }

        private static bool IsEven(int current)
        {
            return current % 2 == 0;
        }
    }
}

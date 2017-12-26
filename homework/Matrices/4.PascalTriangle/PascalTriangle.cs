using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());
            int[][] triangle = new int[height][];
            int currentWidth = 1;
            for (int h = 0; h < height; h++)
            {
                triangle[h] = new int[currentWidth];
                int[] currentRow = triangle[h];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                currentWidth++;

                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length - 1; i++)
                    {
                        int[] previousRow = triangle[h - 1];
                        int previousRowSum = previousRow[i] + previousRow[i - 1];
                        currentRow[i] = previousRowSum;
                    }
                }
            }
            for (int i = 0; i < triangle.Length; i++)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    Console.Write(triangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

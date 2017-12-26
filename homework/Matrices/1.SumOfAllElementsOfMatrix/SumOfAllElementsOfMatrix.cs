using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SumOfAllElementsOfMatrix
{
    class SumOfAllElementsOfMatrix
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                string[] nums = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = int.Parse(nums[j]);
                }
            }

            int sum = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    sum += matrix[row][col];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}

//3, 6
//7, 1, 3, 3, 2, 1
//1, 3, 9, 8, 5, 6
//4, 6, 7, 9, 1, 0

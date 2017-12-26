using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[][] matrix = new int[rows][];
            int sum = Int32.MinValue;
            int[][] target = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                target[i] = new int[2];
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                string[] nums = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = int.Parse(nums[j]);
                }
            }

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    var newSquareSum = matrix[rowIndex][colIndex] +
                    matrix[rowIndex + 1][colIndex] +
                    matrix[rowIndex][colIndex + 1] +
                    matrix[rowIndex + 1][colIndex + 1];
                    if (sum < newSquareSum)
                    {
                        sum = newSquareSum;
                        target[0][0] = matrix[rowIndex][colIndex];
                        target[1][0] = matrix[rowIndex + 1][colIndex];
                        target[0][1] = matrix[rowIndex][colIndex + 1];
                        target[1][1] = matrix[rowIndex + 1][colIndex + 1];
                    }
                }
            }

            for (int i = 0; i < target.Length; i++)
            {
                Console.WriteLine(string.Join(" ", target[i]));
            }
            Console.WriteLine(sum);
        }
    }
}

//3, 6
//7, 1, 3, 3, 2, 1
//1, 3, 9, 8, 5, 6
//4, 6, 7, 9, 1, 0
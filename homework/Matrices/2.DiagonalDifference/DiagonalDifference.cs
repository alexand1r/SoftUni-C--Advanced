using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var firstLineTokens = Console.ReadLine()
                    .Split(' ');

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(firstLineTokens[j]);
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, (matrix.GetLength(0) - i) - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}

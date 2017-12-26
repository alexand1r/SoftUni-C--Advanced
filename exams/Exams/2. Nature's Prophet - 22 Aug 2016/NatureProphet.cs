using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Nature_s_Prophet___22_Aug_2016
{
    class NatureProphet
    {
        private const string End = "Bloom";

        private static int[][] garden;

        public static void Main()
        {
            var matrixDimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];

            garden = new int[matrixDimensions.First()][];
            for (int row = 0; row < rows; row++)
            {
                garden[row] = new int[cols];
            }

            var input = Console.ReadLine().Split();
            while (input[0] != End)
            {
                var row = int.Parse(input[0]);
                var col = int.Parse(input[1]);

                for (int colIndex = 0; colIndex < rows; colIndex++)
                {
                    garden[row][colIndex]++;
                }

                for (int rowIndex = 0; rowIndex < cols; rowIndex++)
                {
                    if (rowIndex == row)
                    {
                        continue;
                    }

                    garden[rowIndex][col]++;
                }

                input = Console.ReadLine().Split();
            }

            ShowGarden();
        }

        private static void ShowGarden()
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }
        }

        //static void Main(string[] args)
        //{
        //HashSet<int[]> plantedFlowers = new HashSet<int[]>();
        //int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

        //int[,] matrix = new int[dimensions[0], dimensions[1]];
        //for (int row = 0; row < matrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < matrix.GetLength(1); col++)
        //    {
        //        matrix[row, col] = 0;
        //    }
        //}

        //string cmd = Console.ReadLine();
        //while (!cmd.Equals("Bloom Bloom Plow"))
        //{
        //    int[] coords = cmd.Split().Select(int.Parse).ToArray();
        //    plantedFlowers.Add(coords);

        //    cmd = Console.ReadLine();
        //}

        //foreach (int[] coords in plantedFlowers)
        //{
        //    int plantRow = coords[0];
        //    int plantCol = coords[1];

        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        matrix[row, plantCol]++;
        //    }

        //    for (int col = 0; col < matrix.GetLength(1); col++)
        //    {
        //        matrix[plantRow, col]++;
        //    }
        //    matrix[plantRow, plantCol]--;
        //}

        //for (int row = 0; row < matrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < matrix.GetLength(1); col++)
        //    {
        //        Console.Write(matrix[row, col] + " ");
        //    }
        //    Console.WriteLine();
        //}
        //}
    }
}

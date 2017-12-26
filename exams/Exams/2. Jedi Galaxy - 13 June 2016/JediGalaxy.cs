using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Jedi_Galaxy___13_June_2016
{
    class JediGalaxy
    {
        static void Main(string[] args)
        {
            int[] dimensions = ReadInput();

            int matrixRows = dimensions[0];
            int matrixCols = dimensions[1];
            int[][] matrix = FillMatrix(matrixRows, matrixCols);

            string exception = string.Empty;
            int sumStars = 0;
            string cmd = Console.ReadLine();
            while (!cmd.Equals("Let the Force be with you"))
            {
                int[] player = cmd
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int[] evil = ReadInput();

                int evilRow = evil[0];
                int evilCol = evil[1];
                while (evilRow >= 0)
                {
                    if (evilRow < matrixRows && evilCol >= 0 && evilCol < matrixCols)
                    { 
                        matrix[evilRow][evilCol] = 0;
                    }
                    
                    evilRow--;
                    evilCol--;
                }

                int playerRow = player[0];
                int playerCol = player[1];
                while (playerRow >= 0)
                {
                    if (playerRow < matrixRows && playerCol >= 0 && playerCol < matrixCols)
                    {
                        sumStars += matrix[playerRow][playerCol];
                    }
                    playerRow--;
                    playerCol++;
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(sumStars);
        }

        private static int[] ReadInput()
        {
            return Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();
        }

        private static int[][] FillMatrix(int matrixRows, int matrixCols)
        {
            int[][] matrix = new int[matrixRows][];

            int counter = 0;
            for (int row = 0; row < matrixRows; row++)
            {
                matrix[row] = new int[matrixCols];
                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row][col] = counter++;
                }
            }

            return matrix;
        }
    }
}

//5 5
//5 -1
//5 5
//Let the Force be with you


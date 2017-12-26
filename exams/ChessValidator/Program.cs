using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] matrix = new string[8][];
            FillMatrix(matrix);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] toknes = input.Split('-');
                string figure = toknes[0][0].ToString();
                int startingRow = int.Parse(toknes[0][1].ToString());
                int startingCol = int.Parse(toknes[0][2].ToString());

                int destinationRow = int.Parse(toknes[1][0].ToString());
                int destinationCol = int.Parse(toknes[1][1].ToString());

                if (matrix[startingRow][startingCol] != figure)
                {
                    Console.WriteLine("There is no such a piece!");
                    input = Console.ReadLine();
                    continue;
                }

                if (IsOutside(matrix, destinationRow, destinationCol))
                {
                    Console.WriteLine("Move go out of board!");
                    input = Console.ReadLine();
                    continue;
                }
                else if (!IsMovePossible(matrix, figure, startingRow, startingCol, destinationRow, destinationCol))
                {
                    Console.WriteLine("Invalid Move!");
                    input = Console.ReadLine();
                    continue;
                }
                

                matrix[destinationRow][destinationCol] = figure;
                matrix[startingRow][startingCol] = "x";

                input = Console.ReadLine();
            }
        }

        private static bool IsOutside(string[][] matrix, int destinationRow, int destinationCol)
        {
            bool isOutside = false;
            if (destinationRow > matrix.Length -1  || destinationRow < 0)
            {
                isOutside = true;
            }
            if (destinationCol > matrix[destinationRow].Length -1 || destinationCol < 0)
            {
                isOutside = true;
            }
            return isOutside;
        }

        private static bool IsMovePossible(string[][] matrix, string figure, int startingRow, int startingCol, int destinationRow, int destinationCol)
        {
            int currentRow = startingRow;
            int currentCol = startingCol;
            bool isPossible = false;
            switch (figure)
            {
                case "K":
                    isPossible = destinationRow == startingRow
                        || destinationRow == startingRow + 1
                        || destinationRow == startingRow - 1
                        && destinationCol == startingCol
                        || destinationCol == startingCol + 1
                        || destinationCol == startingCol - 1;
                    break;
                case "R":
                    isPossible = destinationRow == startingRow
                        || destinationCol == startingCol;
                    break;
                case "B":
                    if (destinationRow < startingRow && destinationCol < startingCol)
                    {
                        while (currentRow != 0 || currentCol != 0)
                        {
                            currentRow--;
                            currentCol--;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow < startingRow && destinationCol > startingCol)
                    {
                        while (currentRow != 0 || currentCol != 0)
                        {
                            currentRow--;
                            currentCol++;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow > startingRow && destinationCol < startingCol)
                    {
                        while (currentRow != matrix.Length - 1 || currentCol != 0)
                        {
                            currentRow++;
                            currentCol--;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow > startingRow && destinationCol < startingCol)
                    {
                        while (currentRow != matrix.Length - 1 || currentCol != matrix[currentRow].Length - 1)
                        {
                            currentRow++;
                            currentCol++;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    break;
                case "Q":
                    if (destinationRow < startingRow && destinationCol < startingCol)
                    {
                        while (currentRow != 0 || currentCol != 0)
                        {
                            currentRow--;
                            currentCol--;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow < startingRow && destinationCol > startingCol)
                    {
                        while (currentRow != 0 || currentCol != matrix[currentRow].Length - 1)
                        {
                            currentRow--;
                            currentCol++;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow > startingRow && destinationCol < startingCol)
                    {
                        while (currentRow != matrix.Length - 1 || currentCol != 0)
                        {
                            currentRow++;
                            currentCol--;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow > startingRow && destinationCol < startingCol)
                    {
                        while (currentRow != matrix.Length - 1 || currentCol != matrix[currentRow].Length - 1)
                        {
                            currentRow++;
                            currentCol++;
                            if (currentRow == destinationRow && currentCol == destinationCol)
                            {
                                isPossible = true;
                                break;
                            }
                        }
                    }
                    else if (destinationRow == startingRow)
                    {
                        isPossible = true;
                    }
                    else if (destinationCol == startingCol)
                    {
                        isPossible = true;
                    }
                    break;
                case "N":
                    isPossible = destinationRow == startingRow - 1 && destinationCol == startingCol - 2
                        || destinationRow == startingRow - 2 && destinationCol == startingCol - 1
                        || destinationRow == startingRow - 1 && destinationCol == startingCol + 2
                        || destinationRow == startingRow - 2 && destinationCol == startingCol + 1
                        || destinationRow == startingRow + 1 && destinationCol == startingCol - 2
                        || destinationRow == startingRow + 2 && destinationCol == startingCol - 1
                        || destinationRow == startingRow + 1 && destinationCol == startingCol + 2
                        || destinationRow == startingRow + 2 && destinationCol == startingCol + 1;
                    break;
                case "P":
                    isPossible = destinationRow == startingRow - 1 && destinationCol == startingCol;
                    break;
            }
            return isPossible;
        }

        private static void FillMatrix(string[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                string[] chessFigures = Console.ReadLine().Split(',');
                matrix[row] = new string[8];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = chessFigures[col];
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess_Validator
{
    class ChessValidator
    {
        public static int ROWS = 8, COLS = 8;
        static void Main(string[] args)
        {
            char[][] board = new char[8][];
            for (int row = 0; row < ROWS; row++)
            {
                board[row] = Console.ReadLine().Replace(",", "").ToCharArray();
            }

            string regex = @"^([A-Z])(\-?(0|\d+))(\-?(0|\d+))-(\-?(0|\d+))(\-?(0|\d+))$";

            string cmd = Console.ReadLine();
            while (!cmd.Equals("END"))
            {
                Match curMatch = Regex.Match(cmd, regex);
                char symbol = curMatch.Groups[1].Value[0];
                int startRow = int.Parse(curMatch.Groups[2].Value);
                int startCol = int.Parse(curMatch.Groups[4].Value);
                int endRow= int.Parse(curMatch.Groups[6].Value);
                int endCol = int.Parse(curMatch.Groups[8].Value);

                if (startRow < 0 || startCol < 0 || startRow > ROWS - 1 || startCol > COLS - 1 || !board[startRow][startCol].Equals(symbol))
                {
                    Console.WriteLine("There is no such a piece!");
                    cmd = Console.ReadLine();
                    continue;
                }

                bool isInvalidMove = false;
                switch (symbol)
                {
                    case 'K':
                        if (Math.Abs(endRow - startRow) > 1 &&
                            Math.Abs(endCol - startCol) > 1)
                            isInvalidMove = true;
                        break;
                    case 'R':
                        if (startRow != endRow && startCol != endCol)
                            isInvalidMove = true;
                        break;
                    case 'B':
                        if (Math.Abs(startRow - endRow) 
                            != Math.Abs(startCol - endCol))
                            isInvalidMove = true;
                        break;
                    case 'Q':
                        if ((startRow != endRow && startCol != endCol) &&
                            Math.Abs(startRow - endRow) != Math.Abs(startCol - endCol))
                            isInvalidMove = true;
                        break;
                    case 'N':
                        if (Math.Abs(startRow - endRow) == 2)
                        {
                            if (Math.Abs(startCol - endCol) != 1)
                                isInvalidMove = true;
                        }
                        else if (Math.Abs(startRow - endRow) == 1)
                        {
                            if (Math.Abs(startCol - endCol) != 2)
                                isInvalidMove = true;
                        }
                        else isInvalidMove = true;
                        //if ((Math.Abs(startRow - endRow) != 2 || Math.Abs(startCol - endCol) != 1) &&
                        //    (Math.Abs(startCol - endCol) != 2 && Math.Abs(startRow - endRow) != 1))
                        //    isInvalidMove = true;
                        break;
                    case 'P':
                        if (startCol != endCol || startRow - endRow != 1)
                            isInvalidMove = true;
                        break;
                }

                if (isInvalidMove)
                {
                    Console.WriteLine("Invalid Move!");
                    cmd = Console.ReadLine();
                    continue;
                }

                if (endRow < 0 || endRow > ROWS - 1 || endCol < 0 || endCol > COLS - 1)
                {
                    Console.WriteLine("Move go out of board!");
                    cmd = Console.ReadLine();
                    continue;
                }

                board[startRow][startCol] = 'x';
                board[endRow][endCol] = symbol;

                cmd = Console.ReadLine();
            }
            
            //PrintBoard(board);
        }

        private static void PrintBoard(char[][] board)
        {
            for (int i = 0; i < ROWS; i++)
            {
                Console.WriteLine(string.Join(" ", board[i]));
            }
        }
    }
}

//P,x,x,x,x,x,x,R
//x,x,x,x,Q,x,x,x
//x,x,x,K,x,x,x,x
//x,N,x,x,x,x,N,x
//x,x,x,x,x,x,x,x
//x,x,Q,x,x,x,x,x
//x,x,x,x,x,P,x,x
//R,x,x,x,x,x,x,x

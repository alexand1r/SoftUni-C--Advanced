    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace KnightGame
    {
        class Program
        {
            private static char[][] board;
            static void Main(string[] args)
            {

                var knightsRemoved = 0;

                int n = int.Parse(Console.ReadLine());
                board = new char[n][];

                for (int row = 0; row < n; row++)
                {
                    board[row] = Console.ReadLine().ToCharArray();
                }

                while (true)
                {
                    var knights = new List<KeyValuePair<int, int[]>>();
                    int maxCount = int.MinValue;
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (board[row][col] == 'K')
                            {
                                int count = 0;

                                if (row - 2 >= 0 && col - 1 >= 0
                                    && board[row - 2][col - 1].Equals('K'))
                                    count++;
                                if (row - 2 >= 0 && col + 1 <= n - 1
                                    && board[row - 2][col + 1].Equals('K'))
                                    count++;
                                if (row + 2 <= n - 1 && col - 1 >= 0
                                    && board[row + 2][col - 1].Equals('K'))
                                    count++;
                                if (row + 2 <= n - 1 && col + 1 <= n - 1
                                    && board[row + 2][col + 1].Equals('K'))
                                    count++;
                                if (row - 1 >= 0 && col - 2 >= 0
                                    && board[row - 1][col - 2].Equals('K'))
                                    count++;
                                if (row - 1 >= 0 && col + 2 <= n - 1
                                    && board[row - 1][col + 2].Equals('K'))
                                    count++;
                                if (row + 1 <= n - 1 && col - 2 >= 0
                                    && board[row + 1][col - 2].Equals('K'))
                                    count++;
                                if (row + 1 <= n - 1 && col + 2 <= n - 1
                                    && board[row + 1][col + 2].Equals('K'))
                                    count++;
                                if (count > maxCount) maxCount = count;
                                knights.Add(new KeyValuePair<int, int[]>(count, new int[] { row, col }));
                            }
                        }
                    }

                    if (maxCount <= 0) break;

                    int[] knightToRemove = new int[2];

                    foreach (var knight in knights)
                    {
                        if (knight.Key == maxCount)
                        {
                            knightToRemove = knight.Value;
                            board[knightToRemove[0]][knightToRemove[1]] = '0';
                            knightsRemoved++;
                        }
                    }
                }

                Console.WriteLine(knightsRemoved);
            }

       
        }
    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int turns = 0;
            string winner = string.Empty;
            string[] alphabet =
            {
                "a", "b", "c", "d", "e", "f", "g", "h",
                "i", "j", "k", "l", "m", "n", "o", "p", "q", "r",
                "s", "t", "u", "v", "w", "x", "y", "z"
            };

            string[] firstPlayerCards = Console.ReadLine().Split(' ');
            string[] secondPlayerCards = Console.ReadLine().Split(' ');
            var firstPlayerDeck = new Queue<string>();
            var secondPlayerDeck = new Queue<string>();

            foreach (var card in firstPlayerCards)
            {
                firstPlayerDeck.Enqueue(card);
            }
            foreach (var card in secondPlayerCards)
            {
                secondPlayerDeck.Enqueue(card);
            }

            while (true)
            {
                if (turns >= 1000000)
                {
                    winner = (firstPlayerDeck.Count > secondPlayerDeck.Count) ? "First" : "Second";
                    break;
                }
                turns++;

                if (firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0)
                {
                    List<string> cardsInOrder = new List<string>();
                    string card1 = firstPlayerDeck.Dequeue();
                    string card2 = secondPlayerDeck.Dequeue();

                    int card1Value = int.Parse(card1.Substring(0, card1.Length - 1));
                    int card2Value = int.Parse(card2.Substring(0, card1.Length - 1));
                    cardsInOrder.Add(card1);
                    cardsInOrder.Add(card2);

                    if (card1Value > card2Value)
                    {
                        foreach (var card in cardsInOrder.OrderByDescending(x => x))
                        {
                            firstPlayerDeck.Enqueue(card);
                        }
                    }
                    else if (card2Value < card1Value)
                    {
                        foreach (var card in cardsInOrder.OrderByDescending(x => x))
                        {
                            secondPlayerDeck.Enqueue(card);
                        }
                    }
                    else
                    {
                        int sum1 = 0;
                        int sum2 = 0;

                        CheckDiff(alphabet, firstPlayerDeck, secondPlayerDeck, sum1, sum2, cardsInOrder, winner);

                        if (sum1 > sum2)
                        {
                            foreach (var card in cardsInOrder.OrderByDescending(x => x))
                            {
                                firstPlayerDeck.Enqueue(card);
                            }
                        }
                        else if (sum2 > sum1)
                        {
                            foreach (var card in cardsInOrder.OrderByDescending(x => x))
                            {
                                secondPlayerDeck.Enqueue(card);
                            }
                        }
                        //else if (sum1 == sum2)
                        //{
                        //    winner = "Draw";
                        //    break;
                        //}
                    }
                }
                else
                {
                    winner = (firstPlayerDeck.Count > secondPlayerDeck.Count) ? "First" : "Second";
                    break;
                }
                
                //if (winner != string.Empty) break;
                //else
                //{
                //    if (firstPlayerDeck.Count == 0 && secondPlayerDeck.Count == 0)
                //        winner = "Draw";
                //    else
                //        winner = (firstPlayerDeck.Count > secondPlayerDeck.Count) ? "First" : "Second";
                //}

            }

            if (winner.Equals("First"))
                Console.WriteLine($"First player wins after {turns} turns");
            else if (winner.Equals("Second"))
                Console.WriteLine($"Second player wins after {turns} turns");
            else if (winner.Equals("Draw"))
                Console.WriteLine($"Draw after {turns} turns");
        }

        private static void CheckDiff(string[] alphabet, Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck, int sum1, int sum2, List<string> cardsInOrder,string winner)
        {
            if (firstPlayerDeck.Count >= 3 && secondPlayerDeck.Count >= 3)
            {
                string card3 = firstPlayerDeck.Dequeue();
                cardsInOrder.Add(card3);
                string card4 = firstPlayerDeck.Dequeue();
                cardsInOrder.Add(card4);
                string card5 = firstPlayerDeck.Dequeue();
                cardsInOrder.Add(card5);
                string card6 = secondPlayerDeck.Dequeue();
                cardsInOrder.Add(card6);
                string card7 = secondPlayerDeck.Dequeue();
                cardsInOrder.Add(card7);
                string card8 = secondPlayerDeck.Dequeue();
                cardsInOrder.Add(card8);

                string ch1 = card3.Substring(card3.Length - 1);
                string ch2 = card4.Substring(card4.Length - 1);
                string ch3 = card5.Substring(card5.Length - 1);
                string ch4 = card6.Substring(card6.Length - 1);
                string ch5 = card7.Substring(card7.Length - 1);
                string ch6 = card8.Substring(card8.Length - 1);

                sum1 = Array.IndexOf(alphabet, ch1) - 1 +
                       Array.IndexOf(alphabet, ch2) - 1 +
                       Array.IndexOf(alphabet, ch3) - 1;

                sum2 = Array.IndexOf(alphabet, ch4) - 1 +
                       Array.IndexOf(alphabet, ch5) - 1 +
                       Array.IndexOf(alphabet, ch6) - 1;

                if (sum1 == sum2)
                    CheckDiff(alphabet, firstPlayerDeck, secondPlayerDeck, sum1, sum2, cardsInOrder, winner);
            }
            else
            {
                if (firstPlayerDeck.Count == 0 && secondPlayerDeck.Count == 0)
                    winner = "Draw";
                else 
                    winner = (firstPlayerDeck.Count > secondPlayerDeck.Count) ? "First" : "Second";
            }
        }
    }
}

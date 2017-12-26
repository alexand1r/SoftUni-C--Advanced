using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectiveMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> larryNumbers = new List<int>();
            List<int> robinNumbers = new List<int>();

            Queue<int> robinMemory = new Queue<int>();
            Queue<int> larryMemory = new Queue<int>();

            int larryPoints = 0;
            int robinPoints = 0;
            string input = Console.ReadLine();
            while (input != "END")
            {
                int number = int.Parse(input);

                larryMemory.Enqueue(number);
                robinMemory.Enqueue(number);
                if (larryNumbers.Contains(number)) larryMemory.Dequeue();

                if (larryNumbers.Contains(number))
                {
                    larryPoints++;
                }
                else if (larryNumbers.Count == 5)
                {
                    larryNumbers.Remove(larryMemory.Dequeue());
                    larryNumbers.Add(number);
                }
                else larryNumbers.Add(number);

                if (robinNumbers.Contains(number))
                {
                    robinPoints++;
                }
                else if (robinNumbers.Count == 5)
                {
                    robinNumbers.Remove(robinMemory.Dequeue());
                    robinNumbers.Add(number);
                }
                else
                {
                    robinNumbers.Add(number);
                }

                input = Console.ReadLine();
            }

            if (larryPoints > robinPoints)
            {
                Console.WriteLine($"Larry {larryPoints} Wins");
            }
            else if (robinPoints > larryPoints)
            {
                Console.WriteLine($"Robin {robinPoints} Wins");
            }
            else
            {
                Console.WriteLine($"Draw {larryPoints}");
            }
        }
    }
}

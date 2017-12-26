using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selective_Amnesia
{
    class SelectiveAmnesia
    {
        static void Main(string[] args)
        {
            int larry = 0, robin = 0;
            List<int> larryNums = new List<int>();
            Queue<int> robinNums = new Queue<int>();

            string cmd = Console.ReadLine();
            while (!cmd.Equals("END"))
            {
                int num = int.Parse(cmd);
                larry = CheckLarry(larry, larryNums, num);
                robin = CheckRobin(robin, robinNums, num);

                cmd = Console.ReadLine();
            }

            PrintResult(larry, robin);
        }

        private static void PrintResult(int larry, int robin)
        {
            if (robin > larry)
                Console.WriteLine($"Robin {robin} Wins");
            else if (robin < larry)
                Console.WriteLine($"Larry {larry} Wins");
            else
                Console.WriteLine($"Draw {larry}");
        }

        private static int CheckRobin(int robin, Queue<int> robinNums, int num)
        {
            if (robinNums.Contains(num))
            {
                robin++;
            }
            else
            {
                robinNums.Enqueue(num);
                if (robinNums.Count > 5)
                    robinNums.Dequeue();
            }

            return robin;
        }

        private static int CheckLarry(int larry, List<int> larryNums, int num)
        {
            if (larryNums.Contains(num))
            {
                larryNums.RemoveAt(larryNums.IndexOf(num));
                larryNums.Add(num);
                larry++;
            }
            else
            {
                larryNums.Add(num);
                if (larryNums.Count > 5)
                    larryNums.RemoveAt(0);
            }

            return larry;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var N = int.Parse(input[0]);
            var S = int.Parse(input[1]);
            var X = int.Parse(input[2]);
            var queue = new Queue<int>();
            var nums = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
                queue.Enqueue(int.Parse(nums[i]));
            for (int i = 0; i < S; i++)
                queue.Dequeue();
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (queue.Contains(X))
                Console.WriteLine("true");
            else
                Console.WriteLine(queue.Min());
        }
    }
}

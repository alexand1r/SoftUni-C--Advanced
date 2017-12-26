using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.SequenceWithQueue
{
    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            int count = 1;
            queue.Enqueue(n);
            Console.Write(n);
            while (true)
            {
                long num = queue.Dequeue();
                Console.Write(" " + (num + 1));
                count++;
                if (count == 50) break;
                queue.Enqueue(num + 1);
                Console.Write(" " + (2 * num + 1));
                queue.Enqueue(2 * num + 1);
                count++;
                if (count == 50) break;
                Console.Write(" " + (num + 2));
                queue.Enqueue(num + 2);
                count++;
                if (count == 50) break;
            }
        }
    }
}

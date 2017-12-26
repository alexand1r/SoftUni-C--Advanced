using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var N = int.Parse(input[0]);
            var S = int.Parse(input[1]);
            var X = int.Parse(input[2]);
            var stack = new Stack<int>();
            var nums = Console.ReadLine().Split(' ');
            for (int i = 0; i < N; i++)
                stack.Push(int.Parse(nums[i]));
            for (int i = 0; i < S; i++)
                stack.Pop();
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (stack.Contains(X))
                Console.WriteLine("true");
            else
                Console.WriteLine(stack.Min());
        }
    }
}

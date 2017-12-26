using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReverseNumbersWithAStack
{
    class ReverseNumbersWithAStack
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int[] nums = {};
            var stack = new Stack<int>();
            if (input == string.Empty) return;
            else nums = input.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            foreach (var i in nums)
            {
                stack.Push(int.Parse(i));
            }
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}

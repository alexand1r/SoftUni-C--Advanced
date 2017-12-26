using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var nth = byte.Parse(Console.ReadLine());

            var stack = new Stack<ulong>();

            stack.Push(1);
            stack.Push(1);

            while (--nth > 0)
            {
                var top = stack.Pop();
                var bottom = stack.Pop();
                stack.Push(top);
                stack.Push(top + bottom);
            }

            stack.Pop();
            Console.WriteLine(stack.Pop());
        }
    }
}

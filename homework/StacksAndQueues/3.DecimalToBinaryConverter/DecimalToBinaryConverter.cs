using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var decimalNumber = int.Parse(str);
            if (decimalNumber == 0) Console.WriteLine(0);
            var stack = new Stack<int>();
            while (decimalNumber != 0)
            {
                stack.Push(decimalNumber % 2);
                decimalNumber /= 2;
            }
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}

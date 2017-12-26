using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Stack<int>();
            var maxNumbers = new Stack<int>();
            int maxValue = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine()
                    .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int num = data[0];
                if (num == 1)
                {
                    numbers.Push(data[1]);
                    if (maxValue < data[1])
                    {
                        maxValue = data[1];
                        maxNumbers.Push(maxValue);
                    }
                }
                else if (num == 2)
                {
                    if (numbers.Pop() == maxValue)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }
                else if (num == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Find_and_Sum_Integers
{
    class FindAndSumIntegers
    {
        static void Main(string[] args)
        {
            long temp = 0;
            var numbers = Console.ReadLine()
                .Split(' ')
                .Where(x => long.TryParse(x, out temp))
                .Select(long.Parse)
                .ToList();
            Console.WriteLine(numbers.Count == 0 ? "No match" : numbers.Sum().ToString());
        }
    }
}

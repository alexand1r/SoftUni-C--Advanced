using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Take_Two
{
    class TakeTwo
    {
        static void Main(string[] args)
        {
            var result = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(number => number >= 10 && number <= 20)
                .Take(2)
                .ToList();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

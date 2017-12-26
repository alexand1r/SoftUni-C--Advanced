using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Bounded_Numbers
{
    class BoundedNumbers
    {
        static void Main(string[] args)
        {
            var bounders = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();
            var left = bounders.Min();
            var right = bounders.Max();
            var resultNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(x => x >= left && x <= right);
            Console.WriteLine(string.Join(" ", resultNumbers));
        }
    }
}

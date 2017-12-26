using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sort_Even_Numbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {

            var list = Console.ReadLine()
                .Split(new string[] {", "},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}

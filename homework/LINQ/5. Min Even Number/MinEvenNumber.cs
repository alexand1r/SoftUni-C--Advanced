using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Min_Even_Number
{
    class MinEvenNumber
    {
        static void Main(string[] args)
        {
            var evenNumbers = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .Where(number => number % 2 == 0)
            .ToList();
            Console.WriteLine(evenNumbers.Count == 0 ? "No match" : $"{evenNumbers.Min():F2}");
        }
    }
}

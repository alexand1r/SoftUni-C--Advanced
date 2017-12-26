using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var numbers = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            var dictionary = new SortedDictionary<double, int>();
            foreach (var number in numbers)
            {
                if (!dictionary.ContainsKey(number))
                    dictionary.Add(number, 1);
                else
                    dictionary[number]++;
            }
            foreach (var num in dictionary.Keys)
            {
                Console.WriteLine($"{num} - {dictionary[num]} times");
            }
        }
    }
}

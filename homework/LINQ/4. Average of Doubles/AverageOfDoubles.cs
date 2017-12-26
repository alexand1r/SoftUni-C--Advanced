using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Average_of_Doubles
{
    class AverageOfDoubles
    {
        static void Main(string[] args)
        {
            var result = Console.ReadLine()
            .Split(' ')
            .Select(double.Parse)
            .Average();
            Console.WriteLine($"{result:F2}");
        }
    }
}

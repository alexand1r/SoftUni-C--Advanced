using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _4.ConvertFromBase_10ToBase_N
{
    class ConvertFromBase10ToBaseN
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var toBase = int.Parse(input[0]);
            var number = BigInteger.Parse(input[1]);

            var converted = string.Empty;

            while (number > 0)
            {
                // prepend
                converted = number % (ulong)toBase + converted;
                number /= (ulong)toBase;
            }

            Console.WriteLine(converted);
        }
    }
}

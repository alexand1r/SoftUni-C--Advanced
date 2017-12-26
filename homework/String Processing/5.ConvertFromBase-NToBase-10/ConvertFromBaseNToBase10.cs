using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _5.ConvertFromBase_NToBase_10
{
    class ConvertFromBaseNToBase10
    {
        static void Main(string[] args)
        {
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var input = Console.ReadLine().Split();

            var fromBase = int.Parse(input[0]);
            var number = input[1];

            BigInteger result = 0;

            // Make sure the arbitrary numeral system number is in upper case
            number = number.ToUpperInvariant();

            BigInteger multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    result = -result;
                    break;
                }

                int digit = Digits.IndexOf(c);

                result += digit * multiplier;
                multiplier *= fromBase;
            }
            Console.WriteLine(result);
        }
    }
}

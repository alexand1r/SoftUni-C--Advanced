using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.SumBigNumbers
{
    class SumBigNumbers
    {
        static void Main(string[] args)
        {
            var nFirst = Console.ReadLine();
            var nSecond = Console.ReadLine();

            if (nFirst.Length < nSecond.Length)
                nFirst = nFirst.PadLeft(nSecond.Length, '0');

            if (nFirst.Length > nSecond.Length)
                nSecond = nSecond.PadLeft(nFirst.Length, '0');

            var carry = false;
            var result = String.Empty;

            for (int i = nFirst.Length - 1; i >= 0; i--)
            {
                var augend = Convert.ToInt32(nFirst.Substring(i, 1));
                var addend = Convert.ToInt32(nSecond.Substring(i, 1));

                var sum = augend + addend;

                sum += (carry ? 1 : 0);
                carry = false;

                if (sum > 9)
                {
                    carry = true;
                    sum -= 10;
                }

                result = sum.ToString() + result;
            }

            if (carry)
                result = '1' + result;

            // remove leading zeros
            result = result.TrimStart('0');

            Console.WriteLine(result);
        }
    }
}

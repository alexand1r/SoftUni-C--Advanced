using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            var number = Console.ReadLine().TrimStart('0');
            var multiplier = byte.Parse(Console.ReadLine());

            if (multiplier == 0 || number == "0" || string.IsNullOrEmpty(number))
            {
                Console.WriteLine(0);
                return;
            }
            byte carry = 0;
            var result = string.Empty;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                var product = (byte)(byte.Parse(number[i].ToString()) * multiplier + carry);
                var remainder = (byte)(product % 10);

                carry = (byte)(product / 10);

                result = remainder + result;

                if (i == 0 && carry != 0)
                    result = carry + result;
            }
            Console.WriteLine(result);
        }
    }
}

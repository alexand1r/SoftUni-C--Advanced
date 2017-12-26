using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _3.Softuni_Numerals___28_Feb_2016
{
    class SoftUniNumerals
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            line = line
                .Replace("aba", "1")
                .Replace("bcc", "2")
                .Replace("cdc", "4")
                .Replace("cc", "3")
                .Replace("aa", "0");

            line = FromBase(BigInteger.Parse(line), 5).ToString();

            Console.WriteLine(line);
        }

        public static BigInteger FromBase(BigInteger value, int @base)
        {
            string number = value.ToString();
            BigInteger n = 1;
            BigInteger r = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                r += n * (number[i] - '0');
                n *= @base;
            }

            return r;
        }
    }
}

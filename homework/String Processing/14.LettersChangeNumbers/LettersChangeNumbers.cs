using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0d;
            var digits = "0123456789".ToCharArray();

            foreach (var word in words)
            {
                var startNumberIndex = word.IndexOfAny(digits);
                var lastNumberIndex = word.LastIndexOfAny(digits);
                var preLetterIndex = startNumberIndex - 1;
                var appLetterIndex = lastNumberIndex + 1;
                
                lastNumberIndex++;

                var preLetter = word[preLetterIndex];
                var appLetter = word[appLetterIndex];

                var number = double.Parse(
                    word.Substring(startNumberIndex, lastNumberIndex - startNumberIndex));

                if (char.IsUpper(preLetter))
                    number /= (double)(preLetter) - 64.0;
                else if (char.IsLower(preLetter))
                    number *= (double)preLetter - 96.0;

                if (char.IsUpper(appLetter))
                    number -= (double)appLetter - 64.0;
                else if (char.IsLower(appLetter))
                    number += (double)appLetter - 96.0;

                sum += number;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}

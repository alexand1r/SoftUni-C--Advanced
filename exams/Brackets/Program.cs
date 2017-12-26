using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\((.*?)\)|\[(.*?)\]|\{(.*?)\}";

            string input = Console.ReadLine();

            int sum = 0;
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                int multiplier = 1;
                if (match.Groups[1].Success)
                {
                    multiplier = 2;
                    sum = CalcTotalSum(match.Groups[1].Value, multiplier, sum);
                }
                else if (match.Groups[2].Success)
                {
                    multiplier = 3;
                    sum = CalcTotalSum(match.Groups[2].Value, multiplier, sum);
                }
                else if (match.Groups[3].Success)
                {
                    multiplier = 5;
                    sum = CalcTotalSum(match.Groups[3].Value, multiplier, sum);
                }
            }
            Console.WriteLine(sum);
        }

        private static int CalcTotalSum(string match, int multiplier, int sum)
        {
            int commas = match.Count(c => c == ',');
            string group = match.Replace(",", "");
            int symbols = group.Length;

            return sum += commas * symbols * multiplier;
        }
    }
}

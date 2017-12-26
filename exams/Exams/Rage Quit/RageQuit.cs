using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rage_Quit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            int finalCount = 0;
            Regex firstBrackets = new Regex(@"\((.*?)\)");
            Regex secondBrackets = new Regex(@"\[(.*?)\]");
            Regex thirdBrackets = new Regex(@"\{(.*?)\}");

            string input = Console.ReadLine();

            MatchCollection firstMatches = firstBrackets.Matches(input);
            MatchCollection secondMatches = secondBrackets.Matches(input);
            MatchCollection thirdMatches = thirdBrackets.Matches(input);

            finalCount = AddCurrentBracketsCount(finalCount, firstMatches, 2);
            finalCount = AddCurrentBracketsCount(finalCount, secondMatches, 3);
            finalCount = AddCurrentBracketsCount(finalCount, thirdMatches, 5);

            Console.WriteLine(finalCount);
        }

        private static int AddCurrentBracketsCount(int finalCount, MatchCollection matches, int multiplier)
        {
            foreach (Match match in matches)
            {
                int count = 0;
                string str = match.Groups[1].Value;
                count = str.Count(x => x == ',');
                str = str.Replace(',', ' ');
                int charactesCount = str.Count(x => x != ' ');
                count *= multiplier * charactesCount;
                finalCount += count;
            }

            return finalCount;
        }
    }
}

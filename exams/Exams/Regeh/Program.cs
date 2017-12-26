using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\[?[a-zA-Z]+\<+?(.*?)\>+?[a-zA-Z]+\]?");
            Regex numReg = new Regex(@"(\d+)(.+?)(\d+)");

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            int sum = 0;
            Queue<int> numbers = new Queue<int>();
            foreach (Match match in matches)
            {
                string needed = match.Groups[1].Value;
                if (needed.Contains(' ')) continue;

                MatchCollection nums = numReg.Matches(needed);

                if (nums.Count > 0)
                {
                    foreach (Match num in nums)
                    {
                        numbers.Enqueue(int.Parse(num.Groups[1].Value));
                        numbers.Enqueue(int.Parse(num.Groups[3].Value));
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var num in numbers)
            {
                sum += num;
                while (sum > input.Length - 1)
                {
                    sum = sum % input.Length - 1;
                }

                sb.Append(input[sum]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

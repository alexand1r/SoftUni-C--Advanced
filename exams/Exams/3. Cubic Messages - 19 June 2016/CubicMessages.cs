using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Cubic_Messages___19_June_2016
{
    class CubicMessages
    {
        private const string End = "Over!";

        public static void Main()
        {
            var input = Console.ReadLine();
            while (input != End)
            {
                var messageLength = int.Parse(Console.ReadLine());

                var match = Regex.Match(input, @"^\d+(?<msg>[a-zA-Z]+)[^a-zA-Z]*$");
                if (match.Success)
                {
                    var message = match.Groups["msg"].Value;
                    if (message.Length == messageLength)
                    {
                        var indices = Regex.Matches(input, @"\d")
                            .Cast<Match>()
                            .Select(m => int.Parse(m.Value))
                            .ToArray();

                        var code = BuildVerificationCode(indices, message);

                        Console.WriteLine($"{message} == {code}");
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static string BuildVerificationCode(int[] indices, string message)
        {
            var res = new StringBuilder();
            foreach (var index in indices)
            {
                if (index >= 0 && index < message.Length)
                {
                    res.Append(message[index]);
                }
                else
                {
                    res.Append(' ');
                }
            }

            return res.ToString();
        }
    }
}

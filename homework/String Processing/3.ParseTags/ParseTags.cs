using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ParseTags
{
    class ParseTags
    {
        static void Main(string[] args)
        {
            var openCase = "<upcase>";
            var closeCase = "</upcase>";
            var input = Console.ReadLine();
            var openIndex = input.IndexOf(openCase);

            while (openIndex != -1)
            {
                var closeIndex = input.IndexOf(closeCase);
                if (closeIndex == -1)
                    break;

                var changeCase = input.Substring(openIndex, closeIndex - openIndex + closeCase.Length);
                var upperCase = changeCase
                    .Replace(openCase, "")
                    .Replace(closeCase, "")
                    .ToUpper();

                input = input.Replace(changeCase, upperCase);
                openIndex = input.IndexOf(openCase);
            }

            Console.WriteLine(input);
        }
    }
}

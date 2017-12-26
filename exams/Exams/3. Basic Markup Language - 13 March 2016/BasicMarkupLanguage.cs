using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Basic_Markup_Language___13_March_2016
{
    class BasicMarkupLanguage
    {
        static void Main(string[] args)
        {
            string reverseOrInversePatt = @"^\s*<\s*(inverse|reverse).*content\s*=\s*""([^""]+)"".*\/\s*>\s*$";
            string repeatPatt = @"^\s*<\s*repeat.*value\s*=\s*""([0-9]+)"".*content\s*=\s*""([^""]+)"".*\/\s*>\s*$";

            Queue<string> results = new Queue<string>();
            while (true)
            {
                string tag = Console.ReadLine();
                if (tag.Equals("<stop/>"))
                    break;

                if (Regex.IsMatch(tag, reverseOrInversePatt))
                {
                    Match currMatch = Regex.Match(tag, reverseOrInversePatt);
                    string tagName = currMatch.Groups[1].Value;
                    string content = currMatch.Groups[2].Value;

                    string currResult = string.Empty;
                    if (tagName.Equals("inverse"))
                    {
                        char[] invertedWord = content.Select(ch => char.IsLower(ch) ?
                                                                   char.ToUpper(ch) :
                                                                   char.ToLower(ch)).ToArray();
                        currResult = string.Join("", invertedWord);
                    }
                    else
                    {
                        currResult = string.Join("", content.Reverse());
                    }
                    results.Enqueue(currResult);
                }
                else if (Regex.IsMatch(tag, repeatPatt))
                {
                    Match currMatch = Regex.Match(tag, repeatPatt);
                    string content = currMatch.Groups[2].Value;
                    int repeatCount = int.Parse(currMatch.Groups[1].Value);

                    for (int i = 0; i < repeatCount; i++)
                    {
                        results.Enqueue(content);
                    }
                }
            }

            int row = 1;
            while (results.Count > 0)
            {
                Console.WriteLine("{0}. {1}", row++, results.Dequeue());
            }
        }
    }
}

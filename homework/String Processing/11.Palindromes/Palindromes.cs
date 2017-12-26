using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    class Palindromes
    {
        public static void Main()
        {
            char[] separators = " ,.?!".ToCharArray();

            var input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string[] result = input.Where(IsPalindrome)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }
        private static bool IsPalindrome(string str)
        {
            int i = 0;
            int j = str.Length - 1;

            while (i < j)
            {
                if (str[i] != str[j])
                    return false;

                i++;
                j--;
            }

            return true;
        }
    }
}

//string[] text = Console.ReadLine().Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '\\' }, StringSplitOptions.RemoveEmptyEntries);
//List<string> palindromes = new List<string>();

//foreach (var word in text)
//{
//    if (word.Equals(string.Join("", word.Reverse())))
//        palindromes.Add(word);
//}
//palindromes.Sort();
//Console.WriteLine("[" + string.Join(", ", palindromes) + "]");
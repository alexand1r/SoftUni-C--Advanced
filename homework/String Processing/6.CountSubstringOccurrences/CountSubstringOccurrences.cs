using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string subString = Console.ReadLine();

            int count = text.Select((c, i) => text.Substring(i)).Count(x => x.StartsWith(subString, StringComparison.CurrentCultureIgnoreCase));
            Console.WriteLine(count);
        }
    }
}

////////
/// var stack = Console.ReadLine();
//string hay = Console.ReadLine();
//var count = 0;
//for (int i = 0; i<stack.Length - hay.Length + 1; i++)
//{
//    if (String.Equals(stack.Substring(i, hay.Length),
//            hay,
//            StringComparison.InvariantCultureIgnoreCase))
//        ++count;
//}

//Console.WriteLine(count);

////////
/// string text = Console.ReadLine().ToLower();
//string pattern = Console.ReadLine().ToLower();
//int numOfOccs = 0;

//int indexOfOcc = text.IndexOf(pattern);
//while (indexOfOcc!= -1)
//{
//    numOfOccs++;
//    indexOfOcc = text.IndexOf(pattern, indexOfOcc + 1);
//}
//Console.WriteLine(numOfOccs);
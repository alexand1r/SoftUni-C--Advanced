using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in words)
            {
                string filter = new string('*', word.Length);
                text = text.Replace(word, filter);
            }
            Console.WriteLine(text);
        }
    }
}

////
//var filter = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
//var text = Console.ReadLine();
//text = filter.Aggregate(text, (current, word) => current.Replace(word, new string('*', word.Length)));
//Console.WriteLine(text);
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Upper_Strings
{
    class UpperStrings
    {
        static void Main(string[] args)
        {
            var result = Console.ReadLine()
               .Split(' ')
               .Select(character => character.ToUpper());
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

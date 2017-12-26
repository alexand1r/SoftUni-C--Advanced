using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                    string.Join("",
                        Console.ReadLine()
                        .Select(a => "\\u" + ((int)a).ToString("X4").ToLower())));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.StringLength
{
    class StringLength
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var output = input.Length <= 20 ? input.PadRight(20, '*') : input.Substring(0, 20);

            Console.WriteLine(output);
        }
    }
}

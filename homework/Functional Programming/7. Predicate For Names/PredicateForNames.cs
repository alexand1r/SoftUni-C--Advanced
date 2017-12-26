using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Predicate_For_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int max_length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');
            Predicate<string> nameLength = name => name.Length <= max_length;

            foreach (string name in names)
            {
                if (nameLength(name))
                    Console.WriteLine(name);
            }
        }
    }
}

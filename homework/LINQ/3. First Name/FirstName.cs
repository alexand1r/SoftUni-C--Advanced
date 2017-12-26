using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.First_Name
{
    class FirstName
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
               .Split(' ')
               .ToList();
            var letters = Console.ReadLine()
                .Split(' ')
                .Select(x => char.ToUpper(char.Parse(x)))
                .ToArray();
            var result = names
                .Where(name => Array.IndexOf(letters, Char.ToUpper(name[0])) >= 0)
                .OrderBy(x => x)
                .FirstOrDefault();

            Console.WriteLine(result == null ? "No match" : result);
        }
    }
}

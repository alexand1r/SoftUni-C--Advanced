using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int e = 0; e < t; e++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

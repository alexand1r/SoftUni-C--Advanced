using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var vip = new HashSet<string>();
            var regular = new SortedSet<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "PARTY")
                    break;
                if (IsVIP(input))
                    vip.Add(input);
                else
                    regular.Add(input);
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                    break;
                if (IsVIP(input))
                    vip.Remove(input);
                else
                    regular.Remove(input);
            }
            regular.UnionWith(vip);

            Console.WriteLine(regular.Count);
            foreach (var i in regular)
            {
                Console.WriteLine(i);
            }
        }

        static bool IsVIP(string input)
        {
            return !string.IsNullOrEmpty(input) && char.IsDigit(input[0]);
        }
    }
}

//7IK9Yo0h
//9NoBUajQ
//Ce8vwPmE
//SVQXQCbc
//tSzE5t0p
//PARTY
//9NoBUajQ
//Ce8vwPmE
//SVQXQCbc
//END
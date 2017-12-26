using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Action_Print
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> print = name => Console.WriteLine(name);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}

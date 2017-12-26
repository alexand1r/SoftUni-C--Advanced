using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string comm = Console.ReadLine().ToLower();

            while (comm != "end")
            {
                switch (comm)
                {
                    case "add": nums = nums.Select(n => n + 1).ToList(); break;
                    case "multiply": nums = nums.Select(n => n * 2).ToList(); break;
                    case "subtract": nums = nums.Select(n => n - 1).ToList(); break;
                    case "print": Console.WriteLine(string.Join(" ", nums)); break;
                    default:
                        break;
                }

                comm = Console.ReadLine();
            }
        }
    }
}

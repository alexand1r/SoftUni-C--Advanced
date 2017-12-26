using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Reverse_And_Exclude
{
    class ReverseAndExlude
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            int div = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", nums.Where(n => n % div != 0).ToList()));
        }
    }
}

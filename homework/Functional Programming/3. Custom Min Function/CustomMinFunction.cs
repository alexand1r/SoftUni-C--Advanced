using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, int> smallestNum = n => n.Min();

            Console.WriteLine(smallestNum(nums));
        }
    }
}

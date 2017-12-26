using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] lengInts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> set1 = new HashSet<int>();

            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < lengInts[0]; i++)
                set1.Add(int.Parse(Console.ReadLine()));

            for (int i = 0; i < lengInts[1]; i++)
                set2.Add(int.Parse(Console.ReadLine()));

            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ", set1));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Collect_Resources___28_Feb_2016
{
    class CollectResources
    {
        static void Main(string[] args)
        {
            int maxCount = 0;
        
            string[] validItems = {"stone", "gold", "wood", "food"};

            string[] input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            int lines = int.Parse(Console.ReadLine());

            for (int line = 0; line < lines; line++)
            {
                bool[] usedMaterials = new bool[input.Length];

                string[] data = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                int start = int.Parse(data[0]);
                int step = int.Parse(data[1]);
                int curPos = start;
                int totalCount = 0;

                while (true)
                {
                    if (usedMaterials[curPos]) break;

                    string[] item = input[curPos].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    string material = item[0];

                    if (!validItems.Contains(material))
                    {
                        curPos = (curPos + step) % input.Length;
                        continue;
                    }

                    int count = item.Length == 1 ? 1 : int.Parse(item[1]);

                    totalCount += count;
                    usedMaterials[curPos] = true;
                    curPos = (curPos + step) % input.Length;
                }

                if (totalCount > maxCount) maxCount = totalCount;

            }

            Console.WriteLine(maxCount);
        }
    }
}
//stone_5 gold_2 wood_7 metal_17
//2
//0 3
//0 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            int t = Int32.Parse(Console.ReadLine());

            // Dictionary {string TYPE, SortedDictionary {string NAME, Dictionary {string STAT, int VALUE} } }
            Dictionary<string, SortedDictionary<string, Dictionary<string, int>>> dragonInfo =
                new Dictionary<string, SortedDictionary<string, Dictionary<string, int>>>();

            while (t-- > 0)
            {

                string[] input = Console.ReadLine().Split();

                string type = input[0];
                string name = input[1];
                int damage = input[2] != "null" ? Int32.Parse(input[2]) : 45;
                int health = input[3] != "null" ? Int32.Parse(input[3]) : 250;
                int armor = input[4] != "null" ? Int32.Parse(input[4]) : 10;

                if (!dragonInfo.ContainsKey(type))
                    dragonInfo.Add(type, new SortedDictionary<string, Dictionary<string, int>>()
                    {
                        {
                            name, new Dictionary<string , int>()
                            {
                                {"damage", damage},
                                {"health", health},
                                {"armor", armor}
                            }
                        }
                    });

                else if (!dragonInfo[type].ContainsKey(name))
                    dragonInfo[type].Add(name, new Dictionary<string, int>()
                    {
                        {"damage", damage},
                        {"health", health},
                        {"armor", armor}
                    });
                else
                    dragonInfo[type][name] = new Dictionary<string, int>()
                    {
                        {"damage", damage},
                        {"health", health},
                        {"armor", armor}
                    };
            }

            foreach (var dragonType in dragonInfo)
            {
                // magic
                var avgDmg = dragonType.Value.Select(
                    x => x.Value.Where(y => y.Key == "damage"))
                    .Select(x => x.Select(y => y.Value)
                    .Average()).Average();

                var avgHealth = dragonType.Value.Select(
                    x => x.Value.Where(y => y.Key == "health"))
                    .Select(x => x.Select(y => y.Value)
                    .Average()).Average();

                var avgArmor = dragonType.Value.Select(
                    x => x.Value.Where(y => y.Key == "armor"))
                    .Select(x => x.Select(y => y.Value)
                    .Average()).Average();

                Console.WriteLine($"{dragonType.Key}::({avgDmg:F2}/{avgHealth:F2}/{avgArmor:F2})");

                foreach (var dragonName in dragonType.Value)
                {
                    Console.Write($"-{dragonName.Key} -> ");
                    int i = 0;
                    foreach (var dragonStat in dragonName.Value)
                    {
                        Console.Write($"{dragonStat.Key}: {dragonStat.Value}");
                        if (i < dragonName.Value.Count - 1)
                            Console.Write(", ");
                        i++;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

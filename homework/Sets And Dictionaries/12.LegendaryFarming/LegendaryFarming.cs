using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            // Dictionary {string TYPE, {SortedDictionary { string MATERIAL, int AMOUNT }}}
            Dictionary<string, SortedDictionary<string, int>> inventory =
                new Dictionary<string, SortedDictionary<string, int>>();

            Dictionary<string, string> specialItems =
                new Dictionary<string, string>()
                {
                    {"Shadowmourne", "shards"},
                    {"Valanyr", "fragments"},
                    {"Dragonwrath","motes"}
                };
            string legendaryItemCreated = "";
            // important! the order of creation is a dependency for order of output
            inventory.Add("legendary", new SortedDictionary<string, int>());
            inventory.Add("junk", new SortedDictionary<string, int>());


            while (true)
            {

                string[] input = Console.ReadLine().Split();

                string[] items = input.Where((x, i) => i % 2 == 1).Select(x => x.ToLower()).ToArray();
                int[] amounts = input.Where((x, i) => i % 2 == 0).Select(int.Parse).ToArray();

                for (int i = 0; i < items.Length; i++)
                {
                    // addition for legendary materials
                    if (specialItems.ContainsValue(items[i]))
                    {
                        if (!inventory["legendary"].ContainsKey(items[i]))
                            inventory["legendary"].Add(items[i], amounts[i]);
                        else
                            inventory["legendary"][items[i]] += amounts[i];


                        if (inventory["legendary"][items[i]] < 250) continue;
                        // enough items legendary material collected; break from loops
                        inventory["legendary"][items[i]] -= 250;
                        legendaryItemCreated = specialItems.First(x => x.Value == items[i]).Key;
                        break;
                    }
                    // addition for junk items

                    if (!inventory["junk"].ContainsKey(items[i]))
                        inventory["junk"].Add(items[i], amounts[i]);
                    else
                        inventory["junk"][items[i]] += amounts[i];
                }
                if (legendaryItemCreated != "")
                    break;
            }
            // if inventory lacks a key material creates an entry with value 0 for it
            foreach (var specialItem in specialItems)
                if (!inventory["legendary"].ContainsKey(specialItem.Value))
                    inventory["legendary"].Add(specialItem.Value, 0);

            Console.WriteLine($"{legendaryItemCreated} obtained!");

            foreach (var kvp in inventory)
                foreach (
                        var innerKvp in kvp.Key == "legendary" ?
                        kvp.Value.OrderByDescending(x => x.Value) :
                        kvp.Value.OrderBy(x => x.Key)
                    )
                    Console.WriteLine($"{innerKvp.Key}: {innerKvp.Value}");
        }
    }
}

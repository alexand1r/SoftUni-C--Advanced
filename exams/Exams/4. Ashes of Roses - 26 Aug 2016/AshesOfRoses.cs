using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Ashes_of_Roses___26_Aug_2016
{
    class AshesOfRoses
    {
        private const string End = "Icarus, Ignite!";

        private static readonly SortedDictionary<string, SortedDictionary<string, long>> Roses =
            new SortedDictionary<string, SortedDictionary<string, long>>();

        public static void Main()
        {
            var input = Console.ReadLine();
            while (input != End)
            {
                var match = Regex.Match(input, @"^Grow\s\<(?<region>[A-Z][a-z]+)\>\s\<(?<rose>[a-zA-Z0-9]+)\>\s(?<amount>\d+)$");
                if (match.Success)
                {
                    var regionName = match.Groups["region"].ToString();
                    var roseType = match.Groups["rose"].ToString();
                    var roseAmount = int.Parse(match.Groups["amount"].ToString());

                    if (!Roses.ContainsKey(regionName))
                    {
                        Roses[regionName] = new SortedDictionary<string, long>();
                    }

                    if (!Roses[regionName].ContainsKey(roseType))
                    {
                        Roses[regionName][roseType] = 0;
                    }

                    Roses[regionName][roseType] += roseAmount;
                }

                input = Console.ReadLine();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            var orderedRegions = Roses.OrderByDescending(reg => reg.Value.Sum(ros => ros.Value));
            foreach (var orderedRegion in orderedRegions)
            {
                Console.WriteLine(orderedRegion.Key);
                var orderedRoseTypes = orderedRegion.Value.OrderBy(type => type.Value);
                foreach (var orderedRoseType in orderedRoseTypes)
                {
                    Console.WriteLine($"*--{orderedRoseType.Key} | {orderedRoseType.Value}");
                }
            }
        }
    }
}

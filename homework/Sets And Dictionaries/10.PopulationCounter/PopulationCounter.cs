using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> populationReport =
                new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {

                string[] input = Console.ReadLine().Split('|');
                if (input[0].ToLower() == "report")
                    break;

                string city = input[0];
                string country = input[1];
                long population = long.Parse(input[2]);

                if (!populationReport.ContainsKey(country))
                    populationReport.Add(country, new Dictionary<string, long>() { { city, population } });

                else if (populationReport[country].ContainsKey(city))
                    populationReport[country][city] += population;

                else
                    populationReport[country].Add(city, population);
            }

            foreach (var kvp in populationReport.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{kvp.Key} (total population: {kvp.Value.Values.Sum()})");

                foreach (var cityPopulationPair in kvp.Value.OrderByDescending(x => x.Value))
                    Console.WriteLine($"=>{cityPopulationPair.Key}: {cityPopulationPair.Value}");
            }
        }
    }
}

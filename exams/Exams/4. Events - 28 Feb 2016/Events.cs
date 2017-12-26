using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Events___28_Feb_2016
{
    class Events
    {
        private static DateTime eventTime;
        static void Main(string[] args)
        {
            var cities = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
            Regex regex = new Regex(@"^#([a-zA-Z]+):\s*@([a-zA-Z]+)\s*((\d+):(\d+))$");
            
            int lines = int.Parse(Console.ReadLine());

            for (int line = 0; line < lines; line++)
            {
                string data = Console.ReadLine();
                MatchCollection matches = regex.Matches(data);

                foreach (Match match in matches)
                {
                    string person = match.Groups[1].Value;
                    string city = match.Groups[2].Value;
                    string time = match.Groups[3].Value;

                    if (!IsValidDate(time)) break;

                    if (!cities.ContainsKey(city)) 
                        cities.Add(city, new SortedDictionary<string, List<string>>());

                    if (!cities[city].ContainsKey(person))
                        cities[city].Add(person, new List<string>());

                    cities[city][person].Add(time);
                }
            }

            string[] citiesToFilter = Console.ReadLine().Split(',');
            foreach (var city in cities)
            {
                if (citiesToFilter.Contains(city.Key))
                {
                    Console.WriteLine($"{city.Key}:");
                    int counter = 1;
                    foreach (var person in cities[city.Key])
                    {
                        Console.Write($"{counter++}. {person.Key} -> ");
                        Console.WriteLine(string.Join(", ", person.Value.OrderBy(x => x)));
                    }
                }
            }
        }

        private static bool IsValidDate(string d)
        {
            return DateTime.TryParse(d, out eventTime);
        }
    }
}

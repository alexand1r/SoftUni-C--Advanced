using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.SrabskoUnleashed
{
    class SrabskoUnleashed
    {
        static void Main(string[] args)
        {
            // Dictionary {string VENUE, Dictionary {string SINGER, int MONEYMADE} } }
            Dictionary<string, Dictionary<string, int>> concerts =
                new Dictionary<string, Dictionary<string, int>>();

            Regex regex = new Regex(@"(?<singer>[\w ]+) @(?<venue>[\w ]+) (?<count>\d+) (?<price>\d+)");
            while (true)
            {

                string input = Console.ReadLine();

                // exit
                if (input.ToLower() == "end")
                    break;

                // valid input
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    string venue = match.Groups["venue"].Value;
                    string singer = match.Groups["singer"].Value;
                    int ticketPrice = Int32.Parse(match.Groups["price"].Value);
                    int ticketCount = Int32.Parse(match.Groups["count"].Value);
                    int revenue = ticketPrice * ticketCount;

                    if (!concerts.ContainsKey(venue))
                        concerts.Add(venue, new Dictionary<string, int>() { { singer, revenue } });
                    else if (!concerts[venue].ContainsKey(singer))
                        concerts[venue].Add(singer, revenue);
                    else
                        concerts[venue][singer] += revenue;
                }
            }

            foreach (var concert in concerts)
            {
                Console.WriteLine(concert.Key);
                foreach (var innerKvp in concert.Value.OrderByDescending(x => x.Value))
                    Console.WriteLine($"#  {innerKvp.Key} -> {innerKvp.Value}");
            }
        }
    }
}

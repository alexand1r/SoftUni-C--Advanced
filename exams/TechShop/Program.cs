using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, long>> result = new Dictionary<string, SortedDictionary<string, long>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string product = input[2];
                string name = input[0];
                long price = long.Parse(input[1]);

                if (!result.ContainsKey(product))
                {
                    result[product] = new SortedDictionary<string, long>();
                }
                if (!result[product].ContainsKey(name))
                {
                    result[product][name] = 0l;
                }
                result[product][name] += price;
            }

            foreach (var item in result)
            {
                List<string> helper = new List<string>();
                foreach (var name in item.Value)
                {
                    helper.Add(string.Format($"{name.Key} {name.Value}"));
                }
                Console.WriteLine($"{item.Key}: {string.Join(", ",helper)}");
            }
        }
    }
}

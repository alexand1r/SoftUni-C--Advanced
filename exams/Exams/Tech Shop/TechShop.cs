using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Shop
{
    class TechShop
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, SortedDictionary<string, long>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                long price = long.Parse(data[1]);
                string product = data[2];

                if (!products.ContainsKey(product))
                    products.Add(product, new SortedDictionary<string, long>());

                if (!products[product].ContainsKey(name))
                    products[product].Add(name, 0);

                products[product][name] += price;
            }

            foreach (var product in products)
            {
                Console.Write($"{product.Key}: ");
                string names = string.Empty;
                foreach (var name in products[product.Key])
                {
                    names += name.Key + " " + name.Value + ", ";
                }
                names = names.Substring(0, names.Length - 2);
                Console.WriteLine(names);
            }
        }
    }
}

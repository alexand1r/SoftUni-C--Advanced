using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int expectedSum = int.Parse(Console.ReadLine());
            Func<string, bool> checkingAStringFunction = (string checkedString) =>
            {
                int sum = 0;
                for (int i = 0; i < checkedString.Length; i++)
                {
                    sum += (int)checkedString[i];
                }

                return sum >= expectedSum;
            };

            Func<Func<string, bool>, List<string>, string> getFirstStringThatMatchFunction =
                (Func<string, bool> function, List<string> collection) =>
                {
                    string foundString = collection.FirstOrDefault(s => function.Invoke(s));

                    return foundString;
                };

            var inputCollection = Console.ReadLine().Split().ToList();

            Console.WriteLine(getFirstStringThatMatchFunction.Invoke(checkingAStringFunction, inputCollection));
        }
    }
}

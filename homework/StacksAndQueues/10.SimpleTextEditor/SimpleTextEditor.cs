using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var output = new Stack<string>();

            for (var i = 0; i < number; i++)
            {
                var inputs = Console.ReadLine().Split(' ');
                switch (inputs[0])
                {
                    case "1":
                        if (!output.Any())
                        {
                            output.Push(inputs[1]);
                        }
                        else
                        {
                            output.Push(output.Peek() + inputs[1]);
                        }
                        break;
                    case "2":
                        var current = output.Peek();
                        output.Push(current.Substring(0, current.Length - int.Parse(inputs[1])));
                        break;
                    case "3":
                        Console.WriteLine(output.Peek()[int.Parse(inputs[1]) - 1]);
                        break;
                    case "4": output.Pop(); break;
                }
            }
        }
    }
}

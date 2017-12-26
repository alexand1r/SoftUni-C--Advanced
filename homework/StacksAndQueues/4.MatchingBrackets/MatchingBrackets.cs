using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            //TODO: Read input from console
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            int startIndex = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == '(')
                    stack.Push(i);
                else if (ch == ')')
                {
                    startIndex = stack.Pop();
                    string contents = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(contents);
                }
            }
        }
    }
}

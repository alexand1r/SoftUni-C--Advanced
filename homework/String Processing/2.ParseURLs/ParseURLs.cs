using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.ParseURLs
{
    class ParseURLs
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] reminder = input.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
            if (reminder.Length != 2 || reminder[1].IndexOf("/") < 0)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            string protocol = reminder[0];
            int serverEndIndex = reminder[1].IndexOf("/");
            string server = reminder[1].Substring(0, serverEndIndex);
            string resource = reminder[1].Substring(serverEndIndex + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resource}");
        }
    }
}

//https://www.google.bg/search?q=google&amp;oq=goo&amp;aqs=chrome.0.0j69i60l2://j0j69i57j69i65.2112j0j7&amp;sourceid=chrome&amp;ie=UTF-8
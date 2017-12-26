using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            // SortedList {string USERNAME, Dictionary{string IP, int NUMBER OF MESSAGES}}
            var users = new SortedList<string, Dictionary<string, int>>();
            while (true)
            {
                var input = Console.ReadLine().Split(new char[] { '=', ' ' });
                if (input[0].ToLower() == "end")
                    break;

                var ip = input[1];
                var username = input[5];

                if (!users.ContainsKey(username))
                    users.Add(username, new Dictionary<string, int>() { { ip, 0 } });

                if (!users[username].ContainsKey(ip))
                    users[username].Add(ip, 1);
                else
                    users[username][ip]++;
            }

            foreach (var user in users)
            {
                var index = 0;
                Console.WriteLine($"{user.Key}: ");
                foreach (var i in user.Value)
                {
                    Console.Write($"{i.Key} => {i.Value}");
                    Console.Write(index < user.Value.Count - 1 ? ", " : ".");
                    index++;
                }
                Console.WriteLine();
            }
        }
    }
}

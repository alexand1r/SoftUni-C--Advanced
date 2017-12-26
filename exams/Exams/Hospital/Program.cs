using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, Dictionary<int, List<string>>>();
            var doctors = new Dictionary<string, List<string>>();
            string cmd = Console.ReadLine();
            while (!cmd.Equals("Output"))
            {
                string[] data = cmd.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string dep = data[0];
                string doc = data[1] + " " + data[2];
                string patient = data[3];

                if (!departments.ContainsKey(dep))
                {
                    departments.Add(dep, new Dictionary<int, List<string>>());
                    for (int i = 0; i < 20; i++)
                    {
                        departments[dep].Add(i + 1, new List<string>());
                    }
                }

                if (!doctors.ContainsKey(doc))
                {
                    doctors.Add(doc, new List<string>());
                }

                for (int room = 1; room <= 20; room++)
                {
                    if (departments[dep][room].Count < 3)
                    {
                        departments[dep][room].Add(patient);
                        doctors[doc].Add(patient);
                        break;
                    }
                }

                cmd = Console.ReadLine();
            }

            string cmd2 = Console.ReadLine();
            while (!cmd2.Equals("End"))
            {
                string[] data = cmd2.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder sb = new StringBuilder();

                if (data.Length < 2)
                {
                    string department = data[0];
                    
                    foreach (var room in departments[department])
                    {
                        if (departments[department][room.Key].Count > 0)
                            Console.WriteLine(string.Join("\n", departments[department][room.Key]));                        
                    }
                }
                else if (data.Length >= 2)
                {
                    int room;
                    bool roomOrDoc = Int32.TryParse(data[1], out room);

                    if (roomOrDoc)
                    {
                        string department = data[0];    
                        Console.WriteLine(string.Join("\n", departments[department][room].OrderBy(x => x)));
                    }
                    else
                    {
                        string doctor = data[0] + " " + data[1];
                        Console.WriteLine(string.Join("\n", doctors[doctor].OrderBy(x => x)));
                    }
                }

                cmd2 = Console.ReadLine();
            }
        }
    }
}

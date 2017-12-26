using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Students_by_First_and_Last_Name
{
    class StudentsByFirstAndLastName
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string[]> studentNames = new List<string[]>();

            while (input != "END")
            {
                studentNames.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                input = Console.ReadLine();
            }

            var result = studentNames.Where(s => s[0].CompareTo(s[1]) < 0).ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student[0]} {student[1]}");
            }
        }
    }
}

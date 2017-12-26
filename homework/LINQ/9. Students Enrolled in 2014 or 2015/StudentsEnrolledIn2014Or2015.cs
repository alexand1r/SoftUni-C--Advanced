using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Students_Enrolled_in_2014_or_2015
{
    class StudentsEnrolledIn2014Or2015
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string[]> students = new List<string[]>();

            while (input != "END")
            {
                students.Add(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                input = Console.ReadLine();
            }

            List<string[]> result = students.Where(s => s[0].EndsWith("14") || s[0].EndsWith("15")).ToList();

            foreach (var student in result)
            {
                Console.WriteLine(string.Join(" ", student.Skip(1)));
            }
        }
    }
}

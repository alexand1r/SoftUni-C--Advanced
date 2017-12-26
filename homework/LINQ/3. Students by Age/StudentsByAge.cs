using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Students_by_Age
{
    class StudentsByAge
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>();
            while (true)
            {
                var student = Console.ReadLine();

                if (student == "END")
                    break;

                var age = int.Parse(string.Join("", student.Where(char.IsDigit)));
                if (age <= 24 && age >= 18)
                    students.Add(student);
            }
            foreach (var student in students)
                Console.WriteLine(student);
        }
    }
}

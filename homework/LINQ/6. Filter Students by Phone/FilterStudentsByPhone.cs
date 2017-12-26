﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Filter_Students_by_Phone
{
    class FilterStudentsByPhone
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

            List<string[]> result = students.Where(s => s[2].StartsWith("02") || s[2].StartsWith("+3592")).ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student[0]} {student[1]}");
            }
        }
    }
}
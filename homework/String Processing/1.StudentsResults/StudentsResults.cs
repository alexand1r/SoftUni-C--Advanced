using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.StudentsResults
{
    class StudentsResults
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] {' ', ',', '-'}, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                float first = float.Parse(data[1]);
                float second = float.Parse(data[2]);
                float third = float.Parse(data[3]);
                float average = (first + second + third) / 3;

                Console.WriteLine(string.Format("{0, -10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", name, first, second, third, average));
            }
        }
    }
}

//2
//Mara - 5, 4, 3
//Gosho - 3, 4, 5
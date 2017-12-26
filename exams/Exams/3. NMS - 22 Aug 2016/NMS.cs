using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.NMS___22_Aug_2016
{
    class NMS
    {
        static void Main(string[] args)
        {
            string result = string.Empty;

            string cmd = Console.ReadLine();
            while (!cmd.Equals("---NMS SEND---"))
            {
                string word = cmd;
                for (int letter = 0; letter < word.Length; letter++)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        if (char.ToLower(word[letter]) >= char.ToLower(result[result.Length - 1]))
                            result += word[letter];
                        else
                            result += " " + word[letter];
                    }
                    else
                        result += word[letter];
                }

                cmd = Console.ReadLine();
            }

            string delimiter = Console.ReadLine();
            result = result.Replace(" ", delimiter);
            Console.WriteLine(result);
        }
    }
}

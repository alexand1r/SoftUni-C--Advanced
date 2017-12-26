using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.WordCount
{
    class WordCount
    {
        // reading the words.txt file, splitting it into words, storing the words into Dictionary<string, int> dictionary as keys
        // the values are all still 0 -> dictionary.Add(s, 0);
        static Dictionary<string, int> ReadDictionary()
        {
            string[] words;
            Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            using (StreamReader reader = new StreamReader(@"..\..\words.txt"))
            {
                while (!reader.EndOfStream)
                {
                    words = reader.ReadLine().ToLower().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in words)
                        if (char.IsLetter(s[s.Length - 1]))
                            dictionary.Add(s, 0);
                        else
                            dictionary.Add(s.Substring(0, s.Length - 2), 0);
                }
            }
            return dictionary;
        }

        // a word found into the input matches a word from the words dictionary, we increase the respective dictionary value by one
        static void CountWordInLine(string line, Dictionary<string, int> dictionary)
        {
            string[] input = line.ToLower().Split(new string[] { " ", ",", "." }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                string key;
                if (char.IsLetter(input[i][input[i].Length - 1]))
                    key = input[i];
                else
                    key = input[i].Substring(0, input[i].Length - 2); // trimming punctuation symbols
                if (dictionary.ContainsKey(key))
                    dictionary[key]++;
            }
        }

        static void Main()
        {
            // we try to read the dictionary file, and acknowledge with an exception an eventual failure, this also closing the stream
            Dictionary<string, int> dictionary;
            try
            {
                dictionary = ReadDictionary();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return;
            }

            // we try to match the words from the test.txt file we read with the ones from the dictionary
            // and acknowledge with an exception an eventual failure, this also closing the stream
            try
            {
                using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
                {
                    while (!reader.EndOfStream)
                        CountWordInLine(reader.ReadLine(), dictionary);
                    //Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return;
            }

            // now we try to write the counting results to a new file, result.txt
            // and acknowledge with an exception an eventual failure
            // OrderByDescending(key => key.Value) does the sorting
            try
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\result.txt"))
                {
                    foreach (KeyValuePair<string, int> item in dictionary.OrderByDescending(key => key.Value))
                    {
                        writer.WriteLine("{0} - {1}", item.Key, item.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading dictionary file. Reason:" + ex.Message);
                Console.WriteLine(ex.StackTrace);
                return;
            }
            Console.WriteLine("Task complete:");

            // print input, words, and output files to the console
            Console.WriteLine("\nInput file:");
            string inputContents = File.ReadAllText(@"..\..\text.txt");
            Console.WriteLine(inputContents);

            Console.WriteLine("\nWords file:");
            string dictionaryContents = File.ReadAllText(@"..\..\words.txt");
            Console.WriteLine(dictionaryContents);

            Console.WriteLine("\nOutput file:");
            string outputContents = File.ReadAllText(@"..\..\result.txt");
            Console.WriteLine(outputContents);
        }
    }
}

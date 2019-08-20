using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem22
    {
        private static readonly Dictionary<char, int> alphabetValues = BuildDictionary();
        public void Method(bool printOutput = false)
        {
            Console.WriteLine("assign a name score to each name in the file and sum all of the scores");

            // read file
            string nameFile = File.ReadAllText("22names.txt");

            // split into individual names
            string[] names = nameFile.Split(',');
            Array.Sort(names);
            int[] nameValues = new int[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                // remove " characters to leave only the name
                names[i] = names[i].Trim('"');
                // get the value of each string by its alphabetical characters,
                // and multiply by its chronological index in the list of names
                nameValues[i] = GetStringValue(names[i]) * (i + 1);

                if(printOutput)
                    Console.WriteLine(
                    $"{(i + 1).ToString().PadRight(5)} | {names[i].PadRight(12)} | {nameValues[i].ToString().PadRight(7)}");
            }

            // get the total of the name values
            int total = nameValues.Sum();

            Console.WriteLine($"total value of names in file: {total}");
        }

        private static int GetStringValue(string str)
        {
            int sum = 0;
            foreach (char c in str)
            {
                alphabetValues.TryGetValue(c, out int value);
                sum += value;
            }
            return sum;
        }

        private static Dictionary<char, int> BuildDictionary()
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            int val = 1;
            for (char c = 'a'; c <= 'z'; c++)
            {
                dictionary.Add(c, val);
                val++;
            }
            val = 1;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dictionary.Add(c, val);
                val++;
            }
            return dictionary;
        }
    }
}

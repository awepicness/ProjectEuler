using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem42
    {
        public void Method()
        {
            Console.WriteLine("convert words to numbers based on the alphabetical position of each letter of the word.");
            Console.WriteLine("if the number is a triangle number (exists in the sequence tn = .5n(n+1)) add it to the list");

            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            int i = 1;
            for (char c = 'a'; c <= 'z'; c++)
            {
                alphabet.Add(c, i);
                i++;
            }

            HashSet<decimal> triangleNumbers = new HashSet<decimal>();
            int index = 0;
            while (index < 100)
            {
                triangleNumbers.Add(new decimal(.5) * index * (index + 1));
                index++;
            }

            string filename = "42words.txt";
            string text = File.ReadAllText(filename);
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
                if (c != '"')
                    sb.Append(c);

            string[] words = sb.ToString().Split(',');


            int triangleNumberCount = 0;
            foreach (string word in words)
            {
                string lower = word.ToLower();
                int wordSum = 0;
                foreach (char c in lower)
                {
                    wordSum += alphabet[c];
                }

                if (triangleNumbers.Contains(wordSum))
                    triangleNumberCount++;
            }

            Console.WriteLine($"there are {triangleNumberCount} triangle number words in {filename}");
        }
    }
}

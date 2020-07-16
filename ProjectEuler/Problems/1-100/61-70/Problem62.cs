using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem62
    {
        public void Method()
        {
            Console.WriteLine("find the smallest cube for which exactly five permutations of its digits are cube");

            // arbitrary - cube root of max int value
            const int cubeLimit = 8500;
            const int permutationMatches = 5;

            // generate cubes, convert them to a special string to be able to match them
            string[] cubeStrings = new string[cubeLimit];
            for (int i = 0; i < cubeLimit; i++)
                cubeStrings[i] = ConvertInt(BigInteger.Pow(i, 3));

            // find smallest cube for which 4 other cubes share the same string representation
            // this works because permutations have the same string representation
            int j = 0;
            string key = cubeStrings.GroupBy(s => s) // group cube by their converted string representation
                                    .FirstOrDefault(g => g.Count() == permutationMatches) // find the first one where the number of entries matches the expected permutation count
                                    ?.Key; // retrieve the converted string representation
            bool found = !string.IsNullOrWhiteSpace(key);

            // find the first location of the converted string - this is the result
            if (found)
                j = Array.IndexOf(cubeStrings, key); 

            Console.WriteLine(found
                ? $"{j}^3 = {BigInteger.Pow(j, 3)} is the smallest cube that can be permuted to {permutationMatches} other cubes"
                : "cube not found");
        }

        /// <summary>
        /// Converts an integer to a string where each digit is in numerical order in the string
        /// and each digit is prefixed by its number of occurrences.
        /// ex: 55233 -> 122325 (one 2, two 3s, two 5s)
        /// </summary>
        /// <param name="n">integer to be converted</param>
        /// <returns></returns>
        private string ConvertInt(BigInteger n)
        {
            Dictionary<int, int> charCount = new Dictionary<int, int>();
            foreach (char c in n.ToString())
            {
                int cu = c - '0';
                charCount[cu] = charCount.ContainsKey(cu) ? charCount[cu] + 1 : 1;
            }
            return string.Concat(charCount.OrderBy(kvp => kvp.Key).Select(kvp => $"{kvp.Value}{kvp.Key}"));
        }
    }
}

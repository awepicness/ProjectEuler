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

            // arbitary - cube root of max int value
            const int cubeLimit = 8500;
            const int permutationMatches = 5;

            // generate cubes, convert them to strings 
            BigInteger[] cubes = new BigInteger[cubeLimit];
            string[] cubeStrings = new string[cubeLimit];
            for (int i = 0; i < cubeLimit; i++)
            {
                cubes[i] = BigInteger.Pow(i, 3);
                string c = ConvertInt(cubes[i]);
                cubeStrings[i] = c;
            }

            // find smallest cube for which 4 other cubes share the same string representation
            // this works because permutations have the same string representation
            int j;
            bool found = false;
            for(j = 0; j < cubeLimit; j++)
            {
                int count = cubeStrings.Count(s => s == cubeStrings[j]);
                if (count != permutationMatches)
                    continue;
                found = true;
                break;
            }

            Console.WriteLine(found
                ? $"{j}^3 = {BigInteger.Pow(j, 3)} is the smallest cube that can be permuted to {permutationMatches} other cubes"
                : "cube not found");
        }

        /// <summary>
        /// Converts an integer to a string where each digit is in numerical order in the string
        /// and each digit is prefixed by its number of occurrences
        /// ex: 55233 -> 122325 (one 2, two 3s, three 5s)
        /// </summary>
        /// <param name="n">integer to be converted</param>
        /// <returns></returns>
        private string ConvertInt(BigInteger n)
        {
            Dictionary<int, int> charCount = new Dictionary<int, int>();
            foreach (char c in n.ToString())
            {
                int cu = c - '0';
                if (charCount.ContainsKey(cu))
                    charCount[cu]++;
                else
                    charCount[cu] = 1;
            }

            StringBuilder res = new StringBuilder();
            foreach (KeyValuePair<int, int> kvp in charCount.OrderBy(k => k.Key))
                res.Append($"{kvp.Value}{kvp.Key}");
            return res.ToString();
        }
    }
}

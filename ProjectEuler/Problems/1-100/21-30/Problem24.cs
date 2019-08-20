using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem24
    {
        private static List<string> Permutations = new List<string>();
        public void Method()
        {
            Console.WriteLine("what is the millionth lexicographic permutation of the digits 0,1,2,3,4,5,6,7,8,9");

            string num = "0123456789";
            permutation("", num);
            Console.WriteLine(Permutations[999999]);
        }

        private static void permutation(string pre, string str)
        {
            int n = str.Length;
            if (n == 0)
                Permutations.Add(pre);
            else
                for (int i = 0; i < n; i++)
                    permutation(pre + str[i], str.Substring(0, i) + str.Substring(i+1));
        }
    }
}

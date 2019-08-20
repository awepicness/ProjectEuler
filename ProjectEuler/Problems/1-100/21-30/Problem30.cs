using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem30
    {
        public void Method()
        {
            Console.WriteLine("find the sum of all numbers that can be written as the sum of fifth powers of their digits");

            // upper bound:
            // the max digit is 9, and 9^5 = 59049. so we need a number with at least 5 digits.
            // 5 * 9^5 = 295245, so with 5 digits we can make a 6 digit number. (too low)
            // 6 * 9^5 = 354294, so with 6 digits we can make a 6 digit number.
            // this seems like a good approximation. lets do another check:
            // 9 * 9^5 (or 9^6) = 531441, so with 9 digits we can only make a 6 digit number.
            // so a number with 6 digits seems like a good bound.

            const int pow = 5;

            List<int> results = new List<int>();

            for (int num = 2; num < Math.Pow(9, pow) * 6; num++) // loose approximation of upper bound (should be over)
            {
                // parse number for digits
                string toParse = num.ToString();
                int[] iDigits = new int[toParse.Length];
                int[] powers = new int[toParse.Length];
                for (int i = 0; i < toParse.Length; i++)
                {
                    // convert each char to int
                    iDigits[i] = toParse[i] - '0'; // subtracting character 0 acts as an int conversion 

                    // find int^5
                    powers[i] = (int)Math.Pow(iDigits[i], pow);
                }

                // add results
                if (num == powers.Sum())
                    results.Add(num);
            }

            int sum = results.Sum();

            Console.WriteLine($"there are {results.Count} numbers whose digits to the power of {pow} = the original number");
            Console.WriteLine($"the sum of these numbers is {sum}");
        }
    }
}

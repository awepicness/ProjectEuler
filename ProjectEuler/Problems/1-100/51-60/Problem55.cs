using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem55
    {
        public void Method()
        {
            Console.WriteLine("How many Lychrel numbers are there below ten thousand?");

            // a lychrel number is a natural number that can *not* form a palindrome through the iterative process
            // of repeatedly reversing its digits and adding the resulting numbers
            // ex: 47: 47 + 74 = 121 -> 121 is a palindrome, stop.
            // ex: 349: 349 + 943 = 1292
            // 1292 + 2921 = 4213
            // 4213 + 3124 = 7337 -> 7337 is a palindrome, stop.

            const int limit = 10000;
            const int lychrelLimit = 50;

            int lychrelCount = 0;
            for (int i = 1; i < limit; i++)
            {
                BigInteger current = i;
                for (long j = 0; j < lychrelLimit; j++)
                {
                    // add the reversed int current to itself
                    current += BigInteger.Parse(ReverseString(current.ToString()));

                    // if current is now a palindrome, break
                    if (current.ToString() == ReverseString(current.ToString()))
                        break;
                }

                if (current.ToString() != ReverseString(current.ToString()))
                    lychrelCount++;
            }

            Console.WriteLine($"There are {lychrelCount} Lychrel Numbers less than {limit}.");
        }

        private static string ReverseString(string input)
        {
            char[] output = input.ToCharArray();
            Array.Reverse(output);
            return new string(output);
        }
    }
}

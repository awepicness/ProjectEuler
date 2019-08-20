using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem80
    {
        public void Method()
        {
            Console.WriteLine("For the first one hundred natural numbers, find the total of the digital sums of the first one hundred decimal digits for all the irrational square roots.");

            // go through the first 100 natural numbers
            // take the square root of each one
            // determine if the square root is irrational
            // if it is, add up the each of the first 100 digits, starting in the decimal place
            // add that number to the overall sum and return that sum at the end

            // some of this is from mathblog.dk since it's shorter,
            // but I did solve it correctly on my own once I had the BigInteger sqrt method

            int j = 1, digitSum = 0;

            for (int i = 1; i <= 100; i++)
            {
                // if the number's sqrt is natural, skip it
                if (j * j == i)
                {
                    j++;
                    continue;
                }

                BigInteger sqrt = HelperMethods.Sqrt(i, 100);

                foreach (char c in sqrt.ToString())
                    digitSum += c - '0';
            }

            Console.WriteLine($"Sum of digits of irrational square roots of natural numbers from 1-100 is {digitSum}");
        }
    }
}

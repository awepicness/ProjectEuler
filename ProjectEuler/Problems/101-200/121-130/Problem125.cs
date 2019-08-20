using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem125
    {
        public void Method()
        {
            double limit = Math.Pow(10, 8);
            double sqrt = Math.Sqrt(limit);

            HashSet<double> consecSquareSums = new HashSet<double>();

            // generate every possible consecutive square sum
            double sum = 0;
            for (double bn = 1; bn <= sqrt; bn++) // base number
            {
                // get bn^2
                double square = bn * bn;
                consecSquareSums.Add(square);

                // tempBn serves as a sum for each consecutive square, starting from the base number bn.
                // iterate through every consecutive square starting at the base and add their running sums to the list

                for (double i = bn + 1; i <= sqrt; i++)
                {
                    square += i * i;

                    if (square > limit) break;

                    if (HelperMethods.IsPalindrome(square.ToString()) && !consecSquareSums.Contains(square))
                    {
                        sum += square;
                        consecSquareSums.Add(square);
                    }
                }
            }

            // determine which consecutive square sums are palindromes and sum them all up
            Console.WriteLine($"sum of all palindromic consecutive square sums < {limit} is {sum}");
        }
    }
}

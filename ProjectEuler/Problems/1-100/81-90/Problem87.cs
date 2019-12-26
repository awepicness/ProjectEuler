using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem87
    {
        public void Method()
        {
            Console.WriteLine("How many numbers below fifty million can be expressed as the sum of a prime square, prime cube, and prime fourth power?");

            // to start, we need to find the upper bound for primes we need to generate
            // the max would be some number p such that the square is maximized and the cube and fourth are minimized,
            // to the point that they are less than 50 mil.
            // so basically find the sqrt of 50 mill
            // 7071

            // wow i did it myself without help!

            const int resultLimit = 50000000;
            int primeLimit = (int) Math.Sqrt(resultLimit);

            int[] primes = HelperMethods.ESieve(2, primeLimit);
            long[] squares = new long[primes.Length];
            long[] cubes = new long[primes.Length];
            long[] tesseracts = new long[primes.Length];

            for (int i = 0; i < primes.Length; i++)
            {
                squares[i] = primes[i] * primes[i];
                cubes[i] = primes[i] * primes[i] * primes[i];
                tesseracts[i] = primes[i] * primes[i] * primes[i] * primes[i];
            }

            // make a place to store results
            HashSet<long> results = new HashSet<long>();

            // now iterate through every possible combination of primes and generate all numbers
            foreach (long tes in tesseracts)
            {
                if (tes >= resultLimit)
                    break;
                foreach (long cube in cubes)
                {
                    if (cube >= resultLimit)
                        break;
                    foreach (long square in squares)
                    {
                        long result = square + cube + tes;
                        if (result < resultLimit)
                            results.Add(result);
                        else
                            break;
                    }
                }
            }

            Console.WriteLine($"There are {results.Count} numbers below {resultLimit} that can be expressed as the sum of a prime square, cube, and fourth power");
        }
    }
}

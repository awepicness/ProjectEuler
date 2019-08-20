using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem131
    {
        public void Method2()
        {
            Console.WriteLine("Find the number of primes for which p cubed + p squared times some number n is a perfect cube");

            // there are some primes p for which there exists a positive integer n such that n^3 + n^2 * p is a perfect cube
            // ex: p = 19, and n = 8. 8^3 + 8^2 * 19 = 12^3
            // what is most surprising is that for each prime with this property, the value of n is unique.
            // there are only 4 such primes below one hundred
            // how many are there below 1 million?

            const int limit = 100;

            int[] primes = HelperMethods.ESieve(2, limit);

            HashSet<int> results = new HashSet<int>();

            for (int n = 1; n < limit; n++)
            {
                foreach (int prime in primes)
                {
                    double eqn = n * n * n + n * n * prime;
                    double cuberoot = Math.Pow(eqn, 1.0 / 3.0);
                    if (cuberoot == (int) cuberoot)
                        results.Add((int) cuberoot);
                }
            }

            Console.WriteLine($"{results.Count} results");
        }
    }
}

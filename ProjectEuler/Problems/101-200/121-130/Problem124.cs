using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem124
    {
        public void Method()
        {
            Console.WriteLine("Let rad(n) be the product of the distinct prime factors of a number n. " +
                              "Calculate rad(n) for 1 <= n <= 100,000, order the results by rad(n). " +
                              "Print the 10000th result, assuming the sorted list starts at 1");

            const int limit = 100000;
            const int kthResult = 10000;

            int[] primes = HelperMethods.ESieve(2, limit);

            Dictionary<int, int> values = new Dictionary<int, int>();
            for (int i = 1; i <= limit; i++)
                values[i] = rad(i, primes);
            
            var result = values.OrderBy(kvp => kvp.Value).ToList()[kthResult - 1];
            Console.WriteLine($"E[{kthResult}]: n = {result.Key} (rad(n) = {result.Value})");
        }

        private int rad(int n, int[] primes)
        {
            int prod = 1;
            foreach (int p in HelperMethods.primeFactors(n, primes))
                prod *= p;
            return prod;
        }
    }
}

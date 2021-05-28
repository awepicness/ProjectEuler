using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem357
    {
        public void Method()
        {
            Console.WriteLine("Consider the divisors of 30: 1,2,3,5,6,10,15,30.\n" +
                              "It can be seen that for every divisor d of 30, d + 30 / d is prime.\n" + 
                              "Find the sum of all positive integers n not exceeding 100 000 000 such that for every divisor d of n, d + n / d is prime.");

            // answer: 1739023853137

            // https://oeis.org/A080715

            /* another way of writing this problem is: 
             * find all positive integers (a, b) such that a*b = n and a + b is prime
             */

            const int limit = 100_000_000;

            var primes = new HashSet<int>(HelperMethods.ESieve(limit));

            var results = new HashSet<long>();
            for (int n = 1; n <= limit; n++)
            {
                bool allDivisors = true;
                
                for (int i = 1; i <= Math.Sqrt(n); i++)
                    if (n % i == 0)
                    {
                        int a = i, b = n / i;
                        if (!primes.Contains(a + b))
                        {
                            allDivisors = false;
                            break;
                        }
                    }

                if (allDivisors)
                    results.Add(n);
            }


            Console.WriteLine($"sum: {results.Sum()}");
        }
    }
}

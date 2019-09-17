using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem203
    {
        public void Method()
        {
            Console.WriteLine("find the sum of the distinct squarefree numbers in the first 51 rows of Pascal's triangle");
            // a number n is squarefree if no prime^2 divides n

            const int ptRowLimit = 51;

            // generate distinct numbers of 51 rows of pascal's triangle
            HashSet<long> pascalsTriangle = new HashSet<long>();
            for (int i = 1; i < ptRowLimit; i++)
                for(int j = 1; j <= i; j++)
                    pascalsTriangle.Add(BinomialCoefficient(i, j));
            pascalsTriangle = pascalsTriangle.OrderBy(t => t).ToHashSet();

            // determine which numbers are squarefree
            long limit = pascalsTriangle.Max();
            int[] primes = HelperMethods.ESieve(2, (int)Math.Sqrt(limit) + 1);
            long[] lprimes = new long[primes.Length];
            for (int i = 0; i < primes.Length; i++)
                lprimes[i] = (long) primes[i];

            HashSet<long> squareFrees = new HashSet<long>();
            foreach (long n in pascalsTriangle)
            {
                bool divisible = true;
                foreach (long p in lprimes)
                {
                    long p2 = p * p;
                    if (p2 > n)
                        break;
                    if (n % p2 != 0)
                        continue;
                    divisible = false;
                    break;
                }

                if (divisible)
                    squareFrees.Add(n);
            }

            // sum the squarefree numbers
            long sum = 0;
            foreach (long s in squareFrees)
                sum += s;

            Console.WriteLine($"sum: {sum}");
        }

        private static long BinomialCoefficient(long n, long k)
        {
            long result = 1;

            if (k > n - k)
                k = n - k;

            for (int i = 0; i < k; ++i)
            {
                result *= (n - i);
                result /= (i + 1);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem263
    {
        public void Method()
        {
            Console.WriteLine("find the sum of the first 4 engineers' paradises");
            // first: practical numbers
            // a practical number is a number n for which all divisors of n can be written as 
            // a sum of distinct divisors of n
            // ex: 6 has divisors 1, 2, 3, 6
            //     1 = 1, 2 = 2, 3 = 1 + 2, 4 = 1 + 3, and 6 = 6

            // second: sexy pairs
            // two numbers x and y form a sexy pair if x and y are prime and y - x = 6
            // 'sex' is latin for 6

            // a number n is an "engineers' paradise' if:
            //     (n-9, n-3), (n-3, n+3), (n+3, n+9) are sexy pairs
            //     n-9, n-3, n+3, and n+9 are all prime
            //     n-8, n-4, n, n+4, and n+8 are all practical

            const int uLim = 100_000_000;
            const int engParadiseLim = 4;

            // generate primes to an arbitrary limit 
            int[] primes = HelperMethods.ESieve(2, uLim);

            List<Tuple<int, int>> sexyPairs = new List<Tuple<int, int>>();
            for (int i = 0; i < primes.Length - 1; i++)
            {
                if (primes[i + 1] - primes[i] == 6)
                    sexyPairs.Add(new Tuple<int, int>(primes[i], primes[i + 1]));
            }

            List<Tuple<int, int>> tripleSexyPairs = new List<Tuple<int, int>>();
            for (int i = 0; i < sexyPairs.Count - 2; i++)
            {
                if (sexyPairs[i].Item2 == sexyPairs[i + 1].Item1
                    && sexyPairs[i + 1].Item2 == sexyPairs[i + 2].Item1)
                {
                    tripleSexyPairs.Add(new Tuple<int, int>(sexyPairs[i].Item1, sexyPairs[i + 2].Item2));
                }
            }

            List<int> engParadises = new List<int>();
            int count = 0;
            foreach (var t in tripleSexyPairs)
            {
                int n = t.Item1 + 9;
                if (IsPractical(n - 8) && IsPractical(n - 4)
                                       && IsPractical(n) && IsPractical(n + 4)
                                       && IsPractical(n + 8))
                {
                    engParadises.Add(n);
                    count++;
                }

                if (count == engParadiseLim)
                    break;
            }

            if (count < engParadiseLim)
                Console.WriteLine($"only {count} engineers paradises were found with prime limit at {uLim}\n(no answer found)");
            else
                Console.WriteLine(engParadises.Sum());

        }


        // determines if a subset of numbers in set sum to sum
        private bool IsSubsetSum(int[] set, int n, int sum)
        {
            bool[,] subset = new bool[sum+1,n+1];

            for (int i = 0; i <= n; i++)
                subset[0, i] = true;

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= set[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - set[j - 1], j - 1];
                }
            }

            return subset[sum, n];
        }

        // np-complete problem as you have to solve the subset sum problem
        // (for each divisor d of n, does some subset of the divisors sum to d?)
        private bool IsPractical(int n)
        {
            if (n <= 0)
                return false;

            int[] divisors = HelperMethods.GetDivisors(n);

            foreach (int d in divisors)
            {
                if (d < 3) continue;
                // subset sum problem
                int[] divisorExceptD = divisors.Where(x => x != d).ToArray();
                if (!IsSubsetSum(divisorExceptD, divisorExceptD.Length, d))
                    return false;
            }

            return true;
        }
    }
}

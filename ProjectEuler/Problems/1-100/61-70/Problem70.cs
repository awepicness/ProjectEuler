using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem70
    {
        public void Method()
        {
            Console.WriteLine(" find the value of n where 1 < n < 10^7 for which Euler's totient function of n (phi(n)) " +
                              "is a permutation of n and the ratio n/phi(n) produces a minimum");
            Console.WriteLine("note: takes a while, but is still within minute time limit");
            double min = int.MaxValue;
            int minN = 0;
            double minTot = 0;
            for (int i = 2; i < Math.Pow(10, 7); i++)
            {
                double totient = phi(i);

                if (i / totient < min && IsPermutation(i.ToString(), totient.ToString()))
                {
                    min = i / totient;
                    minN = i;
                    minTot = totient;
                }
            }

            Console.WriteLine($"n={minN}, phi(n)={minTot} minimizes n/phi(n) with a ratio of {min}");
        }

        private bool IsPermutation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;
            var ac = a.ToCharArray().OrderBy(n => n).ToArray();
            var bc = b.ToCharArray().OrderBy(n => n).ToArray();

            for(int i = 0; i < ac.Length; i++)
                if (ac[i] != bc[i])
                    return false;
            return true;
        }

        private double phi(int n)
        {
            double result = n;
            for (int p = 2; p * p <= n; ++p)
            {
                if (n % p == 0)
                {
                    while (n % p == 0)
                        n /= p;
                    result *= 1.0 - 1.0 / p;
                }
            }

            if (n > 1)
                result *= 1.0 - 1.0 / n;
            return result;
        }
    }
}

using System;

namespace ProjectEuler.Problems
{
    class Problem134
    {
        public void Method2()
        {
            Console.WriteLine("For every consecutive pair of primes for which p2 > p1 >= 5, " +
                              "find a number n such that the last digits of n = p1 and n % p2 = 0. Sum all of these number from the " +
                              "inclusive range of 5 <= p1 <= 1000000");

            // unfinished

            const int limit = 1000000;

            int[] primes = HelperMethods.ESieve(5, limit);

            long sum = 0;
            for(int i = 0; i < primes.Length - 1; i++)
            {
                int p1 = primes[i];
                int p2 = primes[i + 1];

                int prefix = 0;

                long n = p1;
                while(true)
                {
                    string concat = string.Concat(prefix, p1);
                    n = long.Parse(concat);
                    if (n % p2 == 0)
                        break;
                    prefix++;
                }

                sum += n;
            }

            Console.WriteLine($"sum: {sum}");
        }
    }
}

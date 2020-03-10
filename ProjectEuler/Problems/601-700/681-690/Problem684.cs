using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem684
    {
        public void Method2()
        {
            Console.WriteLine("Let s(n) be the smallest number that has a digit sum of n. " +
                              "Let S(k) = sum from n=1 to k of s(n). Further, let f[i] be the fibonacci" +
                              " sequence defined by f[0] = 0, f[1] = 1, and f[i] = f[i - 2] + f[i - 1] for all i >= 2. " +
                              "Find the sum from i=2 to 90 of S(f[i]). return the answer mod 10^9 + 7);");

            const long modulo = 1000000007;
            const int limit = 90;

            long[] fibonacci = generateFibonacci(limit);
            // doesn't work: the math.pow call limits mindigitsum's usefulness to < 100,
            // but it's called up to the 90th fibonacci number: 2,880,067,194,370,816,120.
            // clearly there's some pattern i'm missing because 10 ^ f[90] will NOT work

            foreach (var f in fibonacci)
                Console.WriteLine(minDigitSum(f));

            //long s = 0;
            //for (int i = 1; i <= 20; i++)
            //{
            //    long mds = minDigitSum(i);
            //    s += mds;
            //    Console.WriteLine($"{i}, {mds}, {s}");
            //}
            //Console.WriteLine(s);

        }

        // s(n)
        // find the minimum number with a digitsum of n
        long minDigitSum(long n)
        {
            return ((n % 9) + 1) * (long) Math.Pow(10, n / 9) - 1;
        }

        long[] generateFibonacci(int limit)
        {
            long[] result = new long[limit + 1];

            for (int i = 0; i <= limit; i++)
            {
                if (i < 2)
                    result[i] = i;
                else
                {
                    result[i] = result[i - 2] + result[i - 1];
                }
            }

            return result;
        }
    }
}

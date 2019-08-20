using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem57
    {
        public void Method()
        {
            Console.WriteLine("in the first 1000 expansions of the infinite continued fraction for Sqrt(2), how many fractions contain a numerator with more digits than the denominator?");

            // thank you mathblog.dk

            const int limit = 1000;
            int result = 0;

            BigInteger den = 2;
            BigInteger num = 3;

            for (int i = 1; i < limit; i++)
            {
                num += 2 * den;
                den = num - den;
                if ((int)BigInteger.Log10(num) > (int)BigInteger.Log10(den))
                    result++;
            }

            Console.WriteLine(result);
        }
    }
}

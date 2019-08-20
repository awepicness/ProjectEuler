using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem97
    {
        public void Method()
        {
            Console.WriteLine("In 2004, the large non-Mersenne prime 28433×2^7830457+1 was found. Find the last 10 digits of this number");

            long mod = 10000000000;
            BigInteger result = new BigInteger(28433) * BigInteger.ModPow(2, 7830457, mod) + 1;
            result %= mod;

            Console.WriteLine(result);

        }
    }
}

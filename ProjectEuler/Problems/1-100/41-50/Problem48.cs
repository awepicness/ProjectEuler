using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem48
    {
        public void Method()
        {
            // find the last 10 digits of the series 1^1 + 2^2 + 3^3 + ... + 1000^1000
            BigInteger sum = 0;
            for (int i = 1; i <= 1000; i++)
                sum += BigInteger.Pow(new BigInteger(i), i);

            Console.WriteLine(sum.ToString().Substring(sum.ToString().Length - 10));
        }
    }
}

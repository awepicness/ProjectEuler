using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem188
    {
        public void Method()
        {
            Console.WriteLine("find the last 8 digits of 1777^^1855 (tetration of 1777 to 1855)");

            Console.WriteLine(tetration(1777, 1855, 100_000_000));
        }

        // tetration of a and b, modulus m
        private BigInteger tetration(BigInteger a, BigInteger b, BigInteger m)
        {
            BigInteger t0 = 1;
            BigInteger t1 = 0;
            for (BigInteger i = 0; i < b; i++)
            {
                t1 = BigInteger.ModPow(a, t0, m);
                if (t0 == t1)
                    break;
                t0 = t1;
            }

            return t1;
        }
    }
}

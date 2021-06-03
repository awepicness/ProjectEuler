using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem435
    {
        //private const long n = 1_000_000_000_000_000; // 10^15
        private const long n = 1000 + 1;

        public void Method2()
        {
            Console.WriteLine("let f[n], n >= 0 be the nth fibonacci numbers (f[0] = 0, f[1] = 1).\n" +
                              "Define the polynomials F[n], n >= 0 as F[n](x) = sum from i=0 to n of f[i] * x^i.\n" +
                              "Let n = 10^15. find the sum from x=0 to 100 of F[n](x). give your answer modulo 1,307,674,368,000 (= 15!)");


            var fibs = new BigInteger[n];
            fibs[0] = BigInteger.Zero;
            fibs[1] = BigInteger.One;

            for (long i = 2; i < n; i++)
                fibs[i] = fibs[i - 2] + fibs[i - 1];

            BigInteger sum = BigInteger.Zero;
            for (BigInteger x = BigInteger.Zero; x < n; x += BigInteger.One)
                sum += F(x, fibs);

            BigInteger mod = HelperMethods.Factorial(15);
            Console.WriteLine($"Sum mod 15!: {sum % mod}");
        }

        private BigInteger F(BigInteger x, BigInteger[] fibs)
        {
            BigInteger sum = fibs[0];
            BigInteger xb = x;

            for (long i = 1; i < n; i++)
            {
                sum += fibs[i] * x;
                x *= xb;
            }

            return sum;
        }
    }
}

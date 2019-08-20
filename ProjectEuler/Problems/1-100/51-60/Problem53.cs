using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem53
    {
        public void Method()
        {
            Console.WriteLine("how many, not necessarily distinct, values of (n! / (r!(n-r)!)) where r <= n and 1<=n<=100, are greater than 1 million?");
            const int nLimit = 100;

            List<BigInteger> factorials = new List<BigInteger>();
            for (BigInteger i = 0; i <= nLimit; i++)
                factorials.Add(Factorial(i));

            BigInteger mil = new BigInteger(1000000);
            int count = 0;
            for (int n = 1; n <= nLimit; n++)
            for (int r = 1; r < n; r++)
                if (factorials[n] / (factorials[r] * factorials[n - r]) > mil)
                    count++;

            Console.WriteLine($"There are {count} values of nCr for 1<=n<=100 that are greater than 1 million");
        }

        private static BigInteger Factorial(BigInteger num)
        {
            BigInteger sum = 1;
            for (BigInteger i = 2; i <= num; i++)
                sum *= i;
            return sum;
        }
    }
}

using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem63
    {
        public void Method()
        {
            Console.WriteLine("how many n-digit positive integers exist which are also an nth power?");

            // aka find all numbers where there value can be expressed as some number (1-9)^(1-9) where the exponent 
            // is the same as the number of digits in the resulting number
            // answer: 49

            int count = 0;
            for (int i = 1; i < 25; i++)
                for (int j = 1; j < 25; j++)
                {
                    BigInteger pow = BigInteger.Pow(i, j);
                    int digitCount = 0;
                    foreach (char _ in pow.ToString())
                        digitCount++;
                    if (digitCount == j)
                        count++;
                }
            
            Console.WriteLine($"There are {count} numbers");
        }
    }
}

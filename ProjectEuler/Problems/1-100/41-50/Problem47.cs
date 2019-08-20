using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem47
    {
        public void Method()
        {
            Console.WriteLine("what is the first series of four consecutive integers that have four distinct prime factors?");
            Console.WriteLine("note: solution takes ~35s to calculate as it re uses a lot of functions");

            const int neededPFs = 4;

            // determine where to start i by finding the first neededPFs prime factors and multiplying them
            int[] primes = HelperMethods.ESieve(2, neededPFs * neededPFs);

            int i = 1;
            for(int n = 0; n < neededPFs; n++)
                i *= primes[n];

            while (true)
            {
                int count = 0;
                for (int j = i; j < i + neededPFs; j++)
                {
                    int[] factors = HelperMethods.primeFactors(j);
                    if (factors.Length != neededPFs || factors.Any(factor => !HelperMethods.IsPrime(factor)))
                        break;
                    count++;
                }

                if (count == neededPFs)
                    break;

                i++;
            }
            Console.WriteLine($"The first of {neededPFs} consecutive integers with {neededPFs} distinct prime factors is: {i}");
        }
    }
}

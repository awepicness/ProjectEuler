using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem27
    {
        public void Method()
        {
            Console.WriteLine("Find the product of the coefficients, a and b, for the quadratic expression " +
                              "that produces the maximum number of primes for consecutive values of n, " +
                              "starting with n = 0, where | a | < 1000 and | b | <= 1000");
            
            // note - Given that we start at 0 and the result is a series of consecutive primes,
            // that means b MUST be a prime. We sped this up by calculating
            // all primes < 1000 and iterating over those for b instead of every integer. 
            // this cut down runtime from ~220ms to ~70ms!

            int absLimit = 1000;
            int[] bPos = GetPrimes(-absLimit, absLimit);

            // store max prime
            int maxPrime = 0;
            int finalA = 0;
            int finalB = 0;

            for (int a = -absLimit; a < absLimit; a++)
            {
                foreach (int b in bPos)
                {
                    int primes = FindNumberOfPrimes(a, b);
                    if (primes > maxPrime)
                    {
                        maxPrime = primes;
                        finalA = a;
                        finalB = b;
                    }
                }
            }

            Console.WriteLine($"The quadratic equation n^2 + {finalA}*n + {finalB} produces the most primes: {maxPrime}");
            Console.WriteLine($"The product of the coefficients a ({finalA}) and b ({finalB}) is {finalA * finalB}");
        }

        private static int FindNumberOfPrimes(int a, int b)
        {
            int numberOfPrimes = 0;
            int input = 0;

            while (true)
            {
                if (!HelperMethods.IsPrime(input * input + a * input + b))
                    break;
                input++;
                numberOfPrimes++;
            }

            return numberOfPrimes;
        }

        private static int[] GetPrimes(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int i = start; i < end; i++)
            {
                if (HelperMethods.IsPrime(i))
                    primes.Add(i);
            }

            return primes.ToArray();
        }
    }
}

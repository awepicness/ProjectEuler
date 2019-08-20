using System;

namespace ProjectEuler.Problems
{
    class Problem58
    {
        public void Method()
        {
            Console.WriteLine("Find the side length of the square spiral for which the ratio of primes along both " +
                              "diagonals first falls below 10%");

            double count = 1;
            double primeCount = 0;
            double ratio = 100;

            int diagCorner = 1;
            int sl = 1;
            while(ratio >= 10)
            {
                sl++;
                for (int i = 0; i < 4; i++)
                {
                    diagCorner += sl;
                    if (HelperMethods.IsPrime(diagCorner))
                        primeCount++;
                }

                count += 4;

                ratio = primeCount / count * 100;
                sl++;
            }

            Console.WriteLine($"side length: {sl}");
        }
    }
}

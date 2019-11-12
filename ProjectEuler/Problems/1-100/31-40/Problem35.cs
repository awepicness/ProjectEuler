using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem35
    {
        public void Method()
        {
            Console.WriteLine("how many circular primes are there below one million?");
            // circular prime: all rotations of digits are prime
            // ex: 197 is circular prime: 197, 971, and 719 are all prime

            int limit = 1000000;

            int[] primes = HelperMethods.ESieve(2, limit);
            List<int> circularPrimes = new List<int>();
            foreach(int p in primes)
            {
                if (IsCircularPrime(p.ToString(), p.ToString()))
                    circularPrimes.Add(p);
            }

            Console.WriteLine($"There are {circularPrimes.Count} circular primes less than {limit}");
        }

        private static bool IsCircularPrime(string numString, string origNumString, int iteration = 0)
        {
            while (true)
            {
                // if the number has been rotated back to the original number without issue, return true
                if (iteration > 0 && numString == origNumString)
                    return true;

                // get number from string and rotate number
                int num = int.Parse(numString);
                string rotate = numString.Substring(1) + numString[0];

                // if iteration > 0, then the number must have been rotated
                // check if it is prime; if so, go to next rotation
                // OR
                // if this is first iteration, we know that this number is already prime, so check next rotation
                if (iteration > 0 && HelperMethods.IsPrime(num) || iteration == 0)
                {
                    numString = rotate;
                    iteration++;
                    continue;
                }

                // here, we know iteration > 0 and the number is not prime, so return false
                return false;
            }
        }
    }
}

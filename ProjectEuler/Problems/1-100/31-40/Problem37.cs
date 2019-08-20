using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem37
    {
        public void Method(bool printOutput = false)
        {
            Console.WriteLine("find the sum of the only eleven primes that are truncatable from left to right and right to left");
            // ex: 3797 is prime
            // its truncations from ltr are prime: 797, 97, 7
            // its truncations from rtl are prime: 379, 37, 3
            // note - 2, 3, 5, 7 are NOT truncatable primes (nothing to truncate)

            // answer: their sum is 748317
            // time: 450-500 ms
            const int limit = 1000000;

            List<int> truncatablePrimes = new List<int>();

            for (int i = 8; i < limit; i++) // ignore 2 3 5 7, so start at 8
                if (TruncatePrime(i))
                    truncatablePrimes.Add(i);
            
            Console.WriteLine($"There are {truncatablePrimes.Count} truncatable primes less than {limit}");
            if (printOutput)
            {
                Console.WriteLine("Their values are:");
                foreach (int n in truncatablePrimes)
                    Console.Write(n + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"Their sum is {truncatablePrimes.Sum()}");
        }

        private static bool TruncatePrime(int num)
        {
            // check if number is prime
            if (HelperMethods.IsPrime(num))
            {
                string numString = num.ToString();

                StringBuilder truncateLeft = new StringBuilder(numString.Substring(1));
                StringBuilder truncateRight = new StringBuilder(numString.Substring(0, numString.Length - 1));

                // truncate number from left to right and right to left
                // if any truncation is not prime, return false
                while (truncateLeft.Length > 0)
                {
                    if (!HelperMethods.IsPrime(int.Parse(truncateLeft.ToString())))
                        return false;
                    truncateLeft.Remove(0, 1);
                }

                while (truncateRight.Length > 0)
                {
                    if (!HelperMethods.IsPrime(int.Parse(truncateRight.ToString())))
                        return false;
                    truncateRight.Remove(truncateRight.Length - 1, 1);
                }

                // if the number and every truncation ltr and rtl are prime, return true
                return true;
            }

            return false;
        }
    }
}

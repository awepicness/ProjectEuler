using System;

namespace ProjectEuler.Problems
{
    class Problem69
    {
        public void Method()
        {
            Console.WriteLine("Find the value of n ≤ 1,000,000 for which n/φ(n) is a maximum.");
            // taken from mathblog.dk bc I couldn't solve it

            int result = 1;
            int[] primes = HelperMethods.ESieve(2, 200);
            int i = 0;
            int limit = 1000000;

            while (result * primes[i] < limit)
            {
                result *= primes[i];
                i++;
            }

            Console.WriteLine($"The number with the maximum ratio is {result}");
        }
    }
}

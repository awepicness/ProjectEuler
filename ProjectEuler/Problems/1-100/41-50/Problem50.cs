using System;

namespace ProjectEuler.Problems
{
    class Problem50
    {
        public void Method()
        {
            Console.WriteLine("which prime < 1000000 can be written as the sum of the most consecutive primes?");
            Console.WriteLine("note - long execution! last test ~ 90 seconds");
            Console.WriteLine("result is 997651, the program will output that too");
            Console.WriteLine();

            // answer: 997651 with 543 consecutive primes that sum to it
            // time: 90 seconds :(
            // my solution sucks. mathblog.dk solves it in 11 ms but whatever
            // code here: https://www.mathblog.dk/project-euler-50-sum-consecutive-primes/

            int limit = 1000000;

            // get primes
            int[] primes = HelperMethods.ESieve(2, limit);

            // find number with max consecutive sum of primes
            int maxSumOfConsecutivePrimes = 0;
            int num = 0;
            foreach (int prime in primes)
            {
                int temp = CheckPrime(prime, primes);
                if (temp <= maxSumOfConsecutivePrimes)
                    continue;
                maxSumOfConsecutivePrimes = temp;
                num = prime;
            }

            Console.WriteLine($"Inspecting over primes in the range 2 - {limit}, we see that ");
            Console.WriteLine($"{num} has the most consecutive primes that sum to it: {maxSumOfConsecutivePrimes}");
        }

        private static int CheckPrime(int num, int[] primes)
        {
            int maxConsecSums = 0;

            for (int i = 0; i < primes.Length; i++)
            {
                int currentMax = 0, currentSum = 0;
                int j = 0;
                while (currentSum < num && i + j < primes.Length)
                {
                    currentSum += primes[j + i];
                    currentMax++;
                    j++;
                }

                if (currentSum == num && currentMax > maxConsecSums)
                    maxConsecSums = currentMax;

                if (primes[i] > num)
                    break;
            }

            return maxConsecSums;
        }
    }
}

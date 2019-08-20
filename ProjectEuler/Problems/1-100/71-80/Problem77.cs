using System;

namespace ProjectEuler.Problems
{
    class Problem77
    {
        public void Method()
        {
            Console.WriteLine("What is the first number which can be written as the sum of primes on over 5000 different ways?");

            // thank god for mathblog.dk, i was on the right track with modifying the answer to 76 but didn't have it right

            int[] primes = HelperMethods.ESieve(2, 1000);

            int target = 2;

            while (true)
            {
                int[] ways = new int[target + 1];
                ways[0] = 1;

                for (int i = 0; i < primes.Length; i++)
                    for (int j = primes[i]; j <= target; j++)
                        ways[j] += ways[j - primes[i]];

                if (ways[target] > 5000)
                {
                    Console.WriteLine($"The first number written in over 5000 ways is {target}, with {ways[ways.Length-1]} ways");
                    break;
                }
                target++;
            }

        }
    }
}

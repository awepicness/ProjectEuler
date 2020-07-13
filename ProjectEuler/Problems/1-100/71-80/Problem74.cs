using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem74
    {
        private readonly int[] f = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
        public void Method()
        {
            Console.WriteLine("How many chains, with a starting number below one million, contain exactly sixty non-repeating terms?");
            Console.WriteLine("A chain here means a sequence of numbers in which one number produces the next by summing the factorial of each of a given numbers digits.");

            // ex: 169 -> 363601 -> 1454 -> 169

            // thank you mathblog.dk

            const int limit = 1000000;
            const int chainLimit = 60;

            int result = 0;
            for (int i = 1; i <= limit; i++)
            {
                var seq = new HashSet<int>();

                int n = i;
                while (!seq.Contains(n))
                {
                    seq.Add(n);

                    int facsum = 0;
                    while (n > 0)
                    {
                        facsum += f[n % 10];
                        n /= 10;
                    }
                    n = facsum;
                }

                if (seq.Count == chainLimit)
                    result++;
            }

            Console.WriteLine($"There are {result} chains of length {chainLimit}");
        }
    }
}

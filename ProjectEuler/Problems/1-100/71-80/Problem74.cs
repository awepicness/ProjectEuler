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
            Console.WriteLine("A chain here means a number in which the sum of the factorials of its digits produce numbers that, following the same process," +
                              " return to the original number");

            // ex: 169 -> 363601 -> 1454 -> 169

            // thank you mathblog.dk

            const int limit = 1000000;
            const int chainLimit = 60;

            int result = 0;
            for (int i = 1; i <= limit; i++)
            {
                int n = i;
                List<int> seq = new List<int>();

                while (!seq.Contains(n))
                {
                    seq.Add(n);
                    n = FacSum(n);
                }

                if (seq.Count == chainLimit)
                    result++;
            }

            Console.WriteLine($"There are {result} chains of length {chainLimit}");
        }

        private int FacSum(int n)
        {
            int temp = n;
            int facsum = 0;

            while (temp > 0)
            {
                facsum += f[temp % 10];
                temp /= 10;
            }
            return facsum;
        }
    }
}

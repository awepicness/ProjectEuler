using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem95
    {
        private int[] sumOfFactorsList;
        public void Method()
        {
            Console.WriteLine("Find the smallest member of the longest amicable chain with no element exceeding one million.");

            const int limit = 1000000;

            // yeah, my brute force answer took 8 seconds to go to 10000 so I gave up.
            // mathblog.dk time!

            int result = 0;
            int chainLength = 0;

            generateFactors(limit);

            bool[] numbers = new bool[limit + 1];

            for (int i = 2; i < limit + 1; i++)
            {
                if (numbers[i]) continue;
                List<int> chain = new List<int>();

                int newNumber = i;
                bool broken = false;

                while (!chain.Contains(newNumber))
                {
                    chain.Add(newNumber);
                    newNumber = sumOfFactorsList[newNumber];

                    if (newNumber > limit || numbers[newNumber])
                    {
                        broken = true;
                        break;
                    }
                }

                if (!broken)
                {
                    int smallest = int.MaxValue;
                    int first = chain.IndexOf(newNumber);

                    if (chain.Count - first > chainLength)
                    {
                        for (int j = first; j < chain.Count; j++)
                        {
                            if (chain[j] < smallest)
                                smallest = chain[j];
                        }

                        chainLength = chain.Count - first;
                        result = smallest;
                    }
                }

                foreach (int j in chain)
                {
                    numbers[j] = true;
                }

            }

            Console.WriteLine($"The smallest number in the longest chain is {result}");
        }

        private void generateFactors(int limit)
        {
            sumOfFactorsList = new int[limit + 1];
            for (int i = 1; i <= limit / 2; i++)
            {
                for (int j = 2 * i; j <= limit; j += i)
                {
                    sumOfFactorsList[j] += i;
                }
            }
        }
    }
}

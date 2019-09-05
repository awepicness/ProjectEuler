using System;

namespace ProjectEuler.Problems
{
    class Problem70
    {
        public void Method()
        {
            Console.WriteLine(" find the value of n where 1 < n < 10^7 for which Euler's totient function of n (phi(n)) " +
                              "is a permutation of n and the ratio n/phi(n) produces a minimum");
            Console.WriteLine("note: takes a while, but is still within minute time limit");

            const int loopLimit = 10000000;

            double min = int.MaxValue;
            int minN = 0;
            double minTot = 0;
            for (int i = 2; i < loopLimit; i++)
            {
                double totient = HelperMethods.Phi(i);

                if (i / totient < min && HelperMethods.IsPermutation(i.ToString(), totient.ToString()))
                {
                    min = i / totient;
                    minN = i;
                    minTot = totient;
                }
            }

            Console.WriteLine($"n={minN}, phi(n)={minTot} minimizes n/phi(n) with a ratio of {min}");
        }
    }
}

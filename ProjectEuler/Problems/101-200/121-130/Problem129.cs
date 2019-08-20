using System;

namespace ProjectEuler.Problems
{
    class Problem129
    {
        public void Method()
        {
            Console.WriteLine("find the least value of n for which A(n) first exceeds one-million");

            // yeah I didn't understand this problem either
            // thank you mathblog.dk

            int limit = 1000001;

            int n = limit;

            while (A(n) < limit)
                n += 2;

            Console.WriteLine($"The least value of n for which A(n) first exceeds one million is {n}");
        }

        private int A(int n)
        {
            if (HelperMethods.GCD(n, 10) != 1)
                return 0;

            int x = 1;
            int k = 1;

            while (x != 0)
            {
                x = (x * 10 + 1) % n;
                k++;
            }
            return k;
        }
    }
}

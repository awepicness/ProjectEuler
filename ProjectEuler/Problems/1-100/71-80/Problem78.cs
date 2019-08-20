using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem78
    {
        public void Method()
        {
            Console.WriteLine("let p(n) represent the number of different ways in which n coins can be separated into piles.");
            Console.WriteLine("Find the least value of n for which p(n) is divisible by one million");

            // my first guess was to use problems 76/77 to try and solve this, but it's actually
            // different. It relies on integer partitions like the last two, but the numbers calculated
            // reach astronomical values quickly, which means a lot has to be changed

            // thank you mathblog.dk

            List<int> p = new List<int> {1};

            int n = 1;
            while (true)
            {
                int i = 0, penta = 1;
                p.Add(0);

                while (penta <= n)
                {
                    int sign = (i % 4 > 1) ? -1 : 1;
                    p[n] += sign * p[n - penta];
                    p[n] %= 1000000;
                    i++;

                    int j = (i % 2 == 0) ? i / 2 + 1 : -(i / 2 + 1);
                    penta = j * (3 * j - 1) / 2;
                }

                if (p[n] == 0)
                    break;
                n++;
            }

            Console.WriteLine($"n = {n} is the least value for which p(n) is divisible by 1000000");
        }
    }
}

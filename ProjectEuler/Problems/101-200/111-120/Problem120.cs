using System;

namespace ProjectEuler.Problems
{
    class Problem120
    {
        public void Method()
        {
            Console.WriteLine("Square remainders");

            // let r be the remainder when (a-1)^n + (a+1)^n is divided by a^2
            // for 3 <= a <= 1000, find sum(maximum r)

            int r = 0;
            for (int a = 3; a <= 1000; a++)
                r += 2 * a * ((a - 1) / 2);

            Console.WriteLine(r);
        }
    }
}

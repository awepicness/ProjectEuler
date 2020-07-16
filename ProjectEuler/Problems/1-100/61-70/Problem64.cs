using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem64
    {
        public void Method()
        {
            Console.WriteLine("Exactly four continued fractions, for N≤13, have an odd period. How many continued fractions for N≤10000 have an odd period?");

            // thanks to mathblog.dk
            // https://www.mathblog.dk/project-euler-continued-fractions-odd-period/

            const int upperBound = 10000;

            int result = 0;
            for (int n = 2; n <= upperBound; n++)
            {
                int limit = (int) Math.Sqrt(n);
                if (limit * limit == n) 
                    continue;

                // continued fraction expansion algorithm
                // https://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Continued_fraction_expansion
                int period = 0, d = 1, m = 0, a = limit;

                do
                {
                    m = d * a - m;
                    d = (n - m * m) / d;
                    a = (limit + m) / d;
                    period++;
                } while (a != 2 * limit);

                if (period % 2 == 1) 
                    result++;
            }

            Console.WriteLine($"There are {result} square roots with odd period below {upperBound}");
        }
    }
}

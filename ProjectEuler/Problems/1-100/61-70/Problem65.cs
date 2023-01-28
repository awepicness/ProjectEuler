using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems._1_100._61_70
{
    public class Problem65
    {
        public void Method()
        {
            Console.WriteLine($"Given that the constant e can be represented as a convergent with [2; (1, 2, 1, 1, 4, 1, 1, 6, 1...)], " +
                $"find the sum of the digits in the numerator of the continuous fraction at the 100th step");

            // thanks: https://www.educative.io/answers/convergents-of-e-project-euler--sharp65

            // it is given that the approximation of e at the 10th step has a numerator of 1457, thus the sum of the digits is 1 + 4 + 5 + 7 = 17

            /*
             * you'll notice that the continuous fraction's denominator stuff can be represented as (1, 2k, 1)...
             * see this table of values showing the kth step, the value of the array at k, and the numerator
             * k    f   num
             * 1    1   2
             * 2    2   3
             * 3    1   8
             * 4    1   11
             * 5    4   19
             * 
             * it can be seen that the pattern of the numerator is
             * num[k] = num[k - 1] * f[k - 1] + num[k - 2]
             */

            const int limit = 100;

            Func<BigInteger, int> sumDigits = (x) => x.ToString().Select(c => int.Parse(c.ToString())).Sum();

            BigInteger n = 2, prev_n = 1;
            int f = 1;
            for (int k = 2; k <= limit; k++)
            {
                var temp = prev_n;
                if (k % 3 == 0)
                {
                    f = 2 * k / 3;
                }
                else
                {
                    f = 1;
                }
                prev_n = n;
                n = f * prev_n + temp;
            }

            var result = sumDigits(n);
            Console.WriteLine(result);
        }
    }
}

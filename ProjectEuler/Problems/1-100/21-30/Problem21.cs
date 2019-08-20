using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem21
    {
        public void Method()
        {
            Console.WriteLine("find the sum of all amicable numbers < 10,000");
            // d(n) is sum of numbers less than n which divide evenly into n
            // if d(a) = b and d(b) = a and a != b then a and b are amicable numbers
            // ex: d(220) = (1+2+4+5+10+11+20+22+44+55+110) = 284
            // d(284) = (1+2+4+71+142) = 220
            // 220 and 284 are amicable numbers
            // answer: 31626 is the sum
            int limit = 10000;
            List<int[]> amicableNumbers = new List<int[]>();

            for (int i = 1; i < limit; i++)
            {
                // calculate sumDivisors(i) once instead of 10000 times in the if statements lol
                int sumI = HelperMethods.SumDivisors(i);
                for (int j = i + 2; j < limit; j += 2) // j+=2 instead of j++: no known pair of amicable numbers is even/odd, so keep it even/even or odd/odd
                    if (sumI == j && HelperMethods.SumDivisors(j) == i)
                        amicableNumbers.Add(new[] { i, j });
            }

            int sum = 0;
            foreach (int[] am in amicableNumbers)
            {
                Console.WriteLine($"{am[0]},{am[1]}");
                sum += am[0] + am[1];
            }

            Console.WriteLine($"sum of amicable numbers less than {limit}: {sum}");
        }
    }
}

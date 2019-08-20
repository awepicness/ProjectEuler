using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem56
    {
        public void Method()
        {
            Console.WriteLine("considering natural numbers of the form, a^b, where a,b < 100, what is the maximum sum of the digits of a^b?");

            const int aLimit = 100, bLimit = 100;

            int maxSum = 0, maxA = 0, maxB = 0;
            BigInteger numberWithMaxSum = 0;
            for (int a = 1; a < aLimit; a++)
            {
                for (int b = 1; b < bLimit; b++)
                {
                    BigInteger ab = BigInteger.Pow(a, b);
                    int abDigitSum = SumDigits(ab);

                    if (abDigitSum <= maxSum)
                        continue;

                    maxSum = abDigitSum;
                    numberWithMaxSum = ab;
                    maxA = a;
                    maxB = b;
                }
            }

            Console.WriteLine($"The maximal digit sum of a^b where a,b < 100 is {maxSum}");
            Console.WriteLine($"a = {maxA}, b = {maxB}, and a^b = {numberWithMaxSum}");
        }

        private static int SumDigits(BigInteger input)
        {
            int result = 0;
            foreach (char c in input.ToString())
                result += c - '0';
            return result;
        }
    }
}

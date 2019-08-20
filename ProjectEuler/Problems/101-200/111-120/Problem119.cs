using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem119
    {
        public void Method()
        {
            Console.WriteLine("a sub n = the sum of its digits to some arbitrary power. find a sub 30");

            // according to mathblog.dk, there are two ways to solve this:
            // Either we go through each number and see if their digit sum can be raised to a power
            // such that it is equal to the number.
            // Or we go the other way around and raise smaller numbers to different powers and check their digit sum. 

            // I originally took the first way, but calculation to a-sub 15 took a minute so that didn't work,
            // here's his solution

            List<BigInteger> a = new List<BigInteger>();

            for (int b = 2; b < 400; b++)
            {
                BigInteger value = b;
                for (int e = 2; e < 50; e++)
                {
                    value *= b;

                    if (DigitSum(value) == b)
                        a.Add(value);
                    
                    if (a.Count > 50) break;
                }
                if (a.Count > 50) break;
            }

            a.Sort();

            Console.WriteLine("a30 is {0}", a[29]);
        }

        private BigInteger DigitSum(BigInteger val)
        {
            BigInteger sum = 0;
            while (val != 0)
            {
                sum += val % 10;
                val /= 10;
            }

            return sum;
        }
    }
}

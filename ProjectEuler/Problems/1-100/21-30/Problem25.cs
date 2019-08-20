using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem25
    {
        public void Method()
        {
            Console.WriteLine("calculate fibonacci recursively to find the iteration of the first term with 1000 digits");
            int result = Fibonacci(1, 1);

            Console.WriteLine($"the first number with >= 1000 digits is at iteration {result}");
        }

        private static int Fibonacci(BigInteger prev1, BigInteger prev2)
        {
            BigInteger temp = prev1;
            int iter = 1;
            while (temp.ToString().Length < 1000)
            {
                iter++;
                temp = prev1;
                prev1 += prev2;
                prev2 = temp;
            }
            return iter;
        }
    }
}

using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem20
    {
        public void Method()
        {
            Console.WriteLine("Find the sum of the digits in the number 100!");
            BigInteger hundredFactorial = Factorial(100);

            string hfstring = hundredFactorial.ToString();
            int sum = 0;
            foreach (char c in hfstring)
                sum += c - '0';

            Console.WriteLine($"100! = {hundredFactorial}");
            Console.WriteLine($"sum of digits in 100! = {sum}");
        }

        private static BigInteger Factorial(int num)
        {
            BigInteger result = new BigInteger(1);
            for (int i = num; i > 0; i--)
                result *= i;

            return result;
        }
    }
}

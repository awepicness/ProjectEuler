using System;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem16
    {
        public void Method()
        {
            Console.WriteLine("what is the sum of the digits of 2^1000?");
            int basic = 2;
            int power = 1000;
            BigInteger bigboi = BigInteger.Pow(basic, power);

            Console.WriteLine($"{basic}^{power} = {bigboi}");

            BigInteger sum = new BigInteger(0);
            foreach (char c in bigboi.ToString())
                sum += c - '0';

            Console.WriteLine($"sum of each digit is {sum}");
        }
    }
}

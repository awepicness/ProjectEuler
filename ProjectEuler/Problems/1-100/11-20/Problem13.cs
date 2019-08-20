using System;
using System.IO;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class Problem13
    {
        public void Method()
        {
            Console.WriteLine("find the first 10 digits of the sum of the following hundred 50-digit numbers");

            BigInteger[] list = GetBigIntegers();
            BigInteger sum = new BigInteger();

            foreach (BigInteger bigint in list)
                sum += bigint;

            string firstTenDigits = sum.ToString().Substring(0, 10);

            Console.WriteLine($"first ten digits: {firstTenDigits}");
        }

        private static BigInteger[] GetBigIntegers()
        {
            const string filename = "13numbers.txt";

            // read all lines in file and parse them all to BigIntegers
            return Array.ConvertAll(File.ReadAllLines(filename), BigInteger.Parse);
        }
    }
}

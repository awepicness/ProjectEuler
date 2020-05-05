using System;

namespace ProjectEuler
{
    class Problem3
    {
        public void Method()
        {
            Console.WriteLine("Find Largest Prime Factor of 600851475143 ");

            long input = 600851475143;

            long largest = FindLargestPrimeFactor(input);

            Console.WriteLine($"The largest prime factor of {input} is {largest}");
            Console.WriteLine();

            Console.WriteLine();
        }

        private static long FindLargestPrimeFactor(long num)
        {
            for (long i = (long) Math.Ceiling(Math.Sqrt(num)); i > 0; i--)
            {
                if (num % i == 0 && HelperMethods.IsPrime(i))
                    return i;
            }

            return 0;
        }
    }
}

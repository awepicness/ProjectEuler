using System;
using System.Collections.Generic;

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

            //List<decimal> allPrimeFactors = FindAllPrimeFactors(input);

            //Console.WriteLine($"all prime factors of {input}:");
            //foreach (decimal i in allPrimeFactors)
            //    Console.Write($"{i} ");

            Console.WriteLine();
        }

        private static bool IsPrime(decimal num)
        {
            if (num == 0 || num == 1)
                return false;

            for (int i = 2; i <= HelperMethods.DecimalSqrt(num); i++)
                if (num % i == 0)
                    return false;
            return true;
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

        private static List<decimal> FindAllPrimeFactors(decimal num)
        {
            List<decimal> result = new List<decimal>();
            for (decimal i = Math.Ceiling(HelperMethods.DecimalSqrt(num)); i > 0; i--)
            {
                if (num % i == 0)
                    if (IsPrime(i))
                        result.Add(i);
            }

            return result;
        }

        
    }
}

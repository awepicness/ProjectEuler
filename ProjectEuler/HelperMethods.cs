using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    class HelperMethods
    {
        public static bool IsPrime(int num)
        {
            if (num < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0)
                    return false;
            return true;
        }

        public static bool IsPrime(long num)
        {
            if (num < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0)
                    return false;
            return true;
        }

        public static bool IsPalindrome(string input)
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i] != input[input.Length - i - 1])
                    return false;
            return true;
        }

        public static int Factorial(int num)
        {
            int sum = 1;
            for (int i = 1; i <= num; i++)
                sum *= i;
            return sum;
        }

        // made my own originally, but of course mathblog.dk's version is faster and more versatile :(
        public static bool IsPandigital(long num)
        {
            int digits = 0;
            int count = 0;

            while (num > 0)
            {
                int temp = digits;
                digits = digits | 1 << (int) (num % 10 - 1);
                if (temp == digits)
                    return false;

                count++;
                num /= 10;
            }

            return digits == (1 << count) - 1;
        }

        // thank you mathblog.dk
        public static int[] ESieve(int lowerLimit, int upperLimit)
        {

            int sieveBound = (upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));

            if (lowerLimit < 3)
            {
                numbers.Add(2);
                lowerLimit = 3;
            }

            for (int i = (lowerLimit - 1) / 2; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }

        // thank you stack overflow
        public static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a == 0 ? b : a;
        }

        // i think i got this from mathblog.dk yet again
        public static decimal DecimalSqrt(decimal x, decimal epsilon = 0.0M)
        {
            if (x < 0) throw new OverflowException("Cannot calculate square root from a negative number");

            decimal current = (decimal)Math.Sqrt((double)x), previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }

        // thank you mathblog.dk
        public static BigInteger Sqrt(int n, int digits)
        {
            BigInteger limit = BigInteger.Pow(10, digits + 1);
            BigInteger a = 5 * n;
            BigInteger b = 5;

            while (b < limit)
            {
                if (a >= b)
                {
                    a -= b;
                    b += 10;
                }
                else
                {
                    {
                        a *= 100;
                        b = (b / 10) * 100 + 5;
                    }
                }
            }

            return b / 100;
        }

        public static int SumDivisors(int num)
        {
            int sum = 0;
            for (int i = 1; i <= num / 2; i++)
                if (num % i == 0)
                    sum += i;

            return sum;
        }

        /// <summary>
        /// finds all prime factors of a number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[] primeFactors(int num)
        {
            int[] primes = ESieve(2, num / 2 + 1);
            
            return primeFactors(num, primes);
        }

        /// <summary>
        /// given a number and an array of primes, finds all prime factors that appear in that array
        /// </summary>
        /// <param name="num"></param>
        /// <param name="primes"></param>
        /// <returns>an int array of factors of 'num' that appear in 'primes'</returns>
        public static int[] primeFactors(int num, int[] primes)
        {
            List<int> primeFactors = new List<int>();

            int primeLimit = num / 2 + 1;
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i] > primeLimit)
                    break;
                if (num % primes[i] == 0)
                    primeFactors.Add(primes[i]);
            }
            return primeFactors.ToArray();
        }

        /// <summary>
        /// Euler's Totient function Phi
        /// determines the number of primes relative to n
        /// </summary>
        /// <param name="n">input</param>
        /// <returns>the quantity of primes relative to n</returns>
        public static double Phi(int n)
        {
            double result = n;
            for (int p = 2; p * p <= n; ++p)
            {
                if (n % p == 0)
                {
                    while (n % p == 0)
                        n /= p;
                    result *= 1.0 - 1.0 / p;
                }
            }

            if (n > 1)
                result *= 1.0 - 1.0 / n;
            return result;
        }

        /// <summary>
        /// determines if string b is a permutation of string a
        /// </summary>
        /// <param name="a">parent string</param>
        /// <param name="b">permuted string</param>
        /// <returns>true if b is a permutation of a, otherwise false</returns>
        public static bool IsPermutation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;
            var ac = a.ToCharArray().OrderBy(n => n).ToArray();
            var bc = b.ToCharArray().OrderBy(n => n).ToArray();

            for (int i = 0; i < ac.Length; i++)
                if (ac[i] != bc[i])
                    return false;
            return true;
        }
    }

    // potential functions:

    // BigInteger factorial in problem 53
    // reverse a string in problem 55

}

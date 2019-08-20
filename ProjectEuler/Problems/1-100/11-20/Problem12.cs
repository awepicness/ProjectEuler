using System;

namespace ProjectEuler.Problems
{
    class Problem12
    {
        public void Method()
        {
            Console.WriteLine("what is the value of the first triangle number to have over five hundred divisors?");

            // aka find the first number divisible by at least 500 other numbers
            // only need to list the number with 500+ divisors, not what the divisors are

            int num = 0, nextTnum = 0;
            while (true)
            {
                if (IsDivisible(num) > 500)
                    break;
                num += nextTnum++;
            }

            Console.WriteLine($"{num} has at least 500 divisors");
        }

        private static int IsDivisible(int num)
        {
            int totalDivisors = 1; // a number is always divisible by 1
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0)
                    totalDivisors++; 
            
            return totalDivisors * 2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem23
    {
        // using hashset instead of list decreases time from 57 seconds to .08 seconds lol
        private static HashSet<int> abundantNumbers = new HashSet<int>();
        public void Method()
        {
            Console.WriteLine("find the sum of all positive integers which cannot be written as the sum of two abundant numbers");
            // every number above 28123 can be written as the sum of two abundant numbers, so only iterate up to that point

            const int limit = 28124;

            // find all abundant numbers less than 28123
            for (int i = 1; i < limit; i++)
                if (IsAbundant(i))
                    abundantNumbers.Add(i);
            
            // find numbers that cannot be written as the sum of two abundant numbers
            HashSet<int> numbersNotSumOfTwoAbundants = new HashSet<int>();

            // iterate through each number up to limit
            for (int num = 1; num < limit; num++)
                if (!IsAbundantSum(num))
                    numbersNotSumOfTwoAbundants.Add(num);

            // sum all numbers that are not the sum of two abundant numbers
            int sum = numbersNotSumOfTwoAbundants.Sum();

            Console.WriteLine($"sum of all numbers less than {limit} that cannot be expressed as the sum of two abundant numbers: {sum}");
        }

        private static bool IsAbundant(int num)
        {
            // calculate sum of proper divisors (divisors that are less than the number)
            int sum = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0)
                    sum += i;
            }

            // sum < num : deficient
            // sum = num : perfect
            // sum > num : abundant
            return sum > num;
        }

        private static bool IsAbundantSum(int num)
        {
            foreach (int i in abundantNumbers)
            {
                // abundantNumbers is ordered, so if i > num no further numbers can sum to num
                if (i > num)
                    return false;
                // if abundantNumbers contains num-i than true
                // num-i + i = num
                if (abundantNumbers.Contains(num - i))
                    return true;
            }

            return false;
        }
    }
}

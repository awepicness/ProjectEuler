using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem41
    {
        public void Method()
        {
            Console.WriteLine("what is the largest pandigital prime from 1 to n that only uses each digit up to n once?");

            const int limit = 10000000;

            int[] primes = HelperMethods.ESieve(2, limit);
            
            List<int> nums = new List<int>();
            foreach (int i in primes)
                if (HelperMethods.IsPandigital(i))
                    nums.Add(i);

            Console.WriteLine($"there are {nums.Count} pandigital primes");
            Console.WriteLine($"max pandigital prime is {nums.Max()}");
        }
    }
}

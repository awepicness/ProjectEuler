using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem10
    {
        public void Method()
        {
            Console.WriteLine("find the sum of all primes below two million");

            var primes = HelperMethods.ESieve(2, 2000000);
            long sum = 0;
            foreach (var p in primes)
                sum += p;

            Console.WriteLine($"sum of all primes below two million = {sum}");
        }
    }
}

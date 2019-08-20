using System;

namespace ProjectEuler.Problems
{
    class Problem10
    {
        public void Method()
        {
            Console.WriteLine("find the sum of all primes below two million");
            decimal sum = 0;
            for (int i = 2; i < 2000000; i++)
                if (HelperMethods.IsPrime(i))
                    sum += i;
            
            Console.WriteLine($"sum of all primes below two million = {sum}");
        }
    }
}

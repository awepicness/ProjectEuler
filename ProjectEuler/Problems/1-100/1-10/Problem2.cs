using System;

namespace ProjectEuler
{
    class Problem2
    {
        public void Method()
        {
            Console.WriteLine("Find the sum of every fibonacci number less than 4 million");
            const int limit = 4000000;

            long fib1 = 1;
            long fib2 = 1;
            long result = 0;
            long sum = 0;
            while (result < limit)
            {
                if (result % 2 == 0)
                    sum += result;

                result = fib1 + fib2;
                fib2 = fib1;
                fib1 = result;
            }

            Console.WriteLine($"sum: {sum}");
        }
    }
}

using System;

namespace ProjectEuler.Problems
{
    class Problem112
    {
        public void Method()
        {
            Console.WriteLine("Find the least number for which the proportion of bouncy numbers is exactly 99%.");

            // a bouncy number is a number where its digits are neither increasing or decreasing
            // ex: 155349

            const double percent = 99;

            double n = 99;
            double bouncyCount = 0;
            while (100*bouncyCount/n < percent)
            {
                n++;
                if (HelperMethods.IsBouncy(n))
                    bouncyCount++;
            }
            Console.WriteLine($"{percent}% numbers less than {n} are bouncy");
        }
    }
}

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
                if (IsBouncy(n))
                    bouncyCount++;
            }
            Console.WriteLine($"{percent}% numbers less than {n} are bouncy");
        }

        private static bool IsBouncy(double num)
        {
            int upCount = 0;
            int downCount = 0;
            string numString = num.ToString();
            for (int i = 0; i < numString.Length - 1; i++)
            {
                if (numString[i] > numString[i + 1])
                    upCount++;
                else if (numString[i] < numString[i + 1])
                    downCount++;

                if (upCount > 0 && downCount > 0)
                    return true;
            }
            return false;
        }
    }
}

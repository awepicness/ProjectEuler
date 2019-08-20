using System;

namespace ProjectEuler.Problems
{
    class Problem14
    {
        public void Method()
        {
            Console.WriteLine("Collatz Conjecture! which starting number less than a million produces the longest collatz chain?");

            // i had the wrong answer originally because I didn't consider that the collatz number
            // could go past the int max value, heck

            double maxNumber = 0, maxChain = 0;
            for (double number = 1; number < 1000000; number++)
            {
                double chain = Collatz(number);
                if (chain > maxChain)
                {
                    maxNumber = number;
                    maxChain = chain;
                }
            }
            Console.WriteLine($"{maxNumber} produces the longest Collatz Conjecture chain of any number below one million");
            Console.WriteLine($"{maxNumber} has a chain of {maxChain}");
        }

        private static double Collatz(double num)
        {
            double chain = 0;
            while (num > 1)
            {
                if (num % 2 == 0)
                    num /= 2;
                else
                    num = 3 * num + 1;
                chain++;
            }

            return chain;
        }
    }
}

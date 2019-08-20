using System;

namespace ProjectEuler
{
    class Problem7
    {
        public void Method()
        {
            Console.WriteLine("find the 10,001st prime number");
            // result: 104743
            int primeCounter = 0;
            int i = 1;
            while (primeCounter != 10001)
            {
                i++;
                if (HelperMethods.IsPrime(i))
                    primeCounter++;
            }

            Console.WriteLine($"{i} is the 10,001st prime number");
        }
    }
}

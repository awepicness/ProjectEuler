using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem145
    {
        public void Method()
        {
            Console.WriteLine("how many numbers are there < 1 billion where the number + its reverse " +
                              "only contains odd digits?");
            Console.WriteLine($"\nhey! this program takes ~ 50 seconds to calculate for me, but it will depend " +
                              $"on your computer. just so you know.");
            // answer: 608720

            const int limit = 1_000_000_000;

            int count = 0;
            for(int i = 1; i < limit; i+=2)
                if(IsReversible(i))
                    count+=2;
            
            Console.WriteLine($"{count} / {limit} reversible numbers");
        }

        private bool IsReversible(int num)
        {
            // disallow leading 0s in reverse number: skip i = 100 because rev(i) = 001.
            if (num % 10 == 0)
                return false;

            // reverse num
            int rev = 0;
            int n = num;
            while (n > 0)
            {
                rev = (rev * 10) + n % 10;
                n /= 10;
            }

            // sum num and reverse
            rev += num;

            while (rev > 0)
            {
                if (((rev % 10) & 1) == 0)
                    return false;
                rev /= 10;
            }

            return true;
        }
    }
}

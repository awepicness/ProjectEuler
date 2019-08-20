using System;

namespace ProjectEuler.Problems
{
    class Problem36
    {
        public void Method()
        {
            Console.WriteLine("find the sum of all numbers < 1000000 that are palindromic in base 10 and base 2");
            
            // answer: 872187
            // time: 120-150 ms

            int sum = 0;
            const int limit = 1000000;
            const int newBase = 2;

            for (int i = 1; i < limit; i++)
                // check base 10 number
                if (HelperMethods.IsPalindrome(i.ToString()))
                    // check new base conversion
                    if (HelperMethods.IsPalindrome(Convert.ToString(i, newBase)))
                        sum += i;
            
            Console.WriteLine($"sum of all numbers < {limit} that are palindromes in base 10 and base {newBase}: {sum}");
        }
    }
}

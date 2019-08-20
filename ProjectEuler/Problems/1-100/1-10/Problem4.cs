using System;

namespace ProjectEuler
{
    class Problem4
    {
        public void Method()
        {
            Console.WriteLine("Find the largest palindrome made from the product of two 3-digit numbers");
            int one = 0;
            int two = 0;
            int biggestPalindrome = 0;
            for (int i = 999; i > 99; i--)
                for (int j = 999; j > 99; j--)
                    if (HelperMethods.IsPalindrome((i * j).ToString()) && i * j > biggestPalindrome)
                    {
                        biggestPalindrome = i * j;
                        one = i;
                        two = j;
                    }
            
            Console.WriteLine($"The biggest palindrome made from the product of two 3-digit numbers is {biggestPalindrome}, using {one}*{two}");
        }
    }
}

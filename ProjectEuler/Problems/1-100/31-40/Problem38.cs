using System;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem38
    {
        public void Method()
        {
            Console.WriteLine("find the largest 1-9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2,...,n) where n > 1");
            // ex: 192 
            // 192x1 = 192; 192x2 = 384; 192x3 = 576
            // concatenate each product = 192384576 -> this number is 1-9 pandigital
            // ex2: 9
            // 9x1 = 9; 9x2 = 18; 9x3 = 27; 9x4 = 36; 9x5 = 45
            // concat each product = 918273645 -> this number is 1-9 pandigital

            // max iteration is 9876: concatenating anything larger than that will be larger than the max 9-digit 
            // pandigital number. 9877 concat 9877*2 = 987719754 > 987654321
            // 9876 concat 9876*2 = 987619752 < 987654321

            long max = 0;
            int maxI = 0;
            for (int i = 1; i <= 9876; i++)
            {
                int m = 0;
                if (i < 10)
                    m = 5;
                else if (i < 100)
                    m = 4;
                else if (i < 1000)
                    m = 3;
                else if (i < 10000)
                    m = 2;

                StringBuilder concat = new StringBuilder(i.ToString());
                for (int n = 2; n <= m; n++)
                    concat.Append((i * n).ToString());
                
                long num = long.Parse(concat.ToString());
                if (num < 123456789 || num > 987654321)
                    continue;

                if (HelperMethods.IsPandigital(num) && num > max)
                {
                    max = num;
                    maxI = i;
                }
            }

            Console.WriteLine($"The max number with a pandigital product of num * (1,...,n) is {maxI}");
            Console.WriteLine($"it's pandigital product is {max}");
        }
    }
}

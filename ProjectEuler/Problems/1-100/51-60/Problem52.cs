using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem52
    {
        public void Method()
        {
            Console.WriteLine("find the smallest positive integer x such that 2x, 3x, 4x, 5x, and 6x all contain the same digits");

            int i = 0;
            while (true)
            {
                // if the first digit of the integer is 5 or greater, we know that multiplying it by 2 will add
                // another digit to the length of the integer as a string. not a proven answer for all generic versions of
                // this question but it at least works here
                if (i.ToString()[0] - '0' >= 5)
                    i *= 2;

                i++;

                HashSet<int> iDigits = new HashSet<int>();
                foreach (char c in i.ToString())
                    iDigits.Add(c - '0');

                HashSet<int> i2Digits = new HashSet<int>();
                foreach (char c in (2 * i).ToString())
                    i2Digits.Add(c - '0');

                if (!iDigits.SetEquals(i2Digits))
                    continue;

                HashSet<int> i3Digits = new HashSet<int>();

                foreach (char c in (3 * i).ToString())
                    i3Digits.Add(c - '0');

                if (!iDigits.SetEquals(i3Digits))
                    continue;

                HashSet<int> i4Digits = new HashSet<int>();

                foreach (char c in (4 * i).ToString())
                    i4Digits.Add(c - '0');

                if (!iDigits.SetEquals(i4Digits))
                    continue;

                HashSet<int> i5Digits = new HashSet<int>();

                foreach (char c in (5 * i).ToString())
                    i5Digits.Add(c - '0');

                if (!iDigits.SetEquals(i5Digits))
                    continue;

                HashSet<int> i6Digits = new HashSet<int>();

                foreach (char c in (6 * i).ToString())
                    i6Digits.Add(c - '0');

                if (!iDigits.SetEquals(i6Digits))
                    continue;
                break;
            }

            Console.WriteLine($"{i} * 2, 3, 4, 5, and 6 all have the same digits as {i}");
        }
    }
}

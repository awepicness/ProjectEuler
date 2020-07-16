using System;
using System.Collections.Generic;
using System.Linq;

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

                HashSet<int> iDigits = buildDigits(i, 1);

                HashSet<int> i2Digits = buildDigits(i, 2);

                if (!iDigits.SetEquals(i2Digits))
                    continue;

                HashSet<int> i3Digits = buildDigits(i, 3);

                if (!iDigits.SetEquals(i3Digits))
                    continue;

                HashSet<int> i4Digits = buildDigits(i, 4);

                if (!iDigits.SetEquals(i4Digits))
                    continue;

                HashSet<int> i5Digits = buildDigits(i, 5);

                if (!iDigits.SetEquals(i5Digits))
                    continue;

                HashSet<int> i6Digits = buildDigits(i, 6);

                if (!iDigits.SetEquals(i6Digits))
                    continue;
                break;
            }

            Console.WriteLine($"{i} * 2, 3, 4, 5, and 6 all have the same digits as {i}");
        }

        private HashSet<int> buildDigits(int num, int mult) => (num * mult).ToString().Select(c => c - '0').ToHashSet();
    }
}

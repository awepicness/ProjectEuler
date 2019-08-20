using System;

namespace ProjectEuler.Problems
{
    class Problem19
    {
        public void Method()
        {
            Console.WriteLine("How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?");
            DateTime nineteenHundredsBegin = new DateTime(1901, 1, 1);
            DateTime nineteenHundredsEnd = new DateTime(2000, 12, 31, 11, 59, 59);

            DateTime firstSunday = new DateTime(1901, 1, 6);

            int sundayCount = 0;

            // iterate through each sunday through the 1900s
            for (DateTime d = firstSunday; d <= nineteenHundredsEnd; d = d.AddDays(7))
                // if sunday was the first of the month, increment counter
                if (d.Day == 1)
                    sundayCount++;

            Console.WriteLine($"Sunday fell on the first day of the month {sundayCount} times between {nineteenHundredsBegin} and {nineteenHundredsEnd}");
        }
    }
}

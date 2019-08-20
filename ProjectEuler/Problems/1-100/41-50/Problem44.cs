using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem44
    {
        public void Method()
        {
            Console.WriteLine("find the pair of pentagonal numbers A and B for which their sum and difference are pentagonal and |B-A| is minimized");
            Console.WriteLine("what is the value of |B-A|?");

            // pentagonal number formula: Pn = n(3n-1)/2
            // 1 5 12 22 35 51 70 92 117 145...

            HashSet<int> pentagonalNumbers = new HashSet<int>();
            int index = 1;
            while (index < 10000)
            {
                pentagonalNumbers.Add(index * (3 * index - 1) / 2);
                index++;
            }

            int d = int.MaxValue;
            int pk = 0, pj = 0;

            foreach (int p1 in pentagonalNumbers)
            foreach (int p2 in pentagonalNumbers)
            {
                if (Math.Abs(p2 - p1) >= d || !pentagonalNumbers.Contains(p1 + p2) || !pentagonalNumbers.Contains(p2 - p1))
                    continue;
                d = p2 - p1;
                pk = p2;
                pj = p1;
            }

            Console.WriteLine($"Min value of |B - A| where B, A, B+A, and B-A are all pentagonal numbers is {d}. B = {pj}, A = {pk} ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem45
    {
        public void Method()
        {
            Console.WriteLine("find the next number after 40755 that is a triangle, pentagonal, and hexagonal number");

            const double limit = 1000000;

            HashSet<double> triangles = new HashSet<double>();
            HashSet<double> pentagonals = new HashSet<double>();
            HashSet<double> hexagonals = new HashSet<double>();

            for (double i = 0; i < limit; i++)
            {
                triangles.Add(i * (i + 1) / 2);
                pentagonals.Add(i * (3 * i - 1) / 2);
                hexagonals.Add(i * (2 * i - 1));
            }

            HashSet<double> all = new HashSet<double>();

            foreach (double i in triangles)
            {
                if (!pentagonals.Contains(i) || !hexagonals.Contains(i))
                    continue;
                all.Add(i);
            }

            Console.WriteLine($"There are {all.Count} numbers that are shared between the first {limit} triangular, pentagonal, and hexagonal numbers");
            Console.WriteLine($"The next T/P/H number after 40755 = {all.Last()}");
        }
    }
}

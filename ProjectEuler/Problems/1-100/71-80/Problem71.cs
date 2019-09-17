using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem71
    {
        public void Method()
        {
            Console.WriteLine("By listing the set of reduced proper fractions for d ≤ 1,000,000 in " +
                              "ascending order of size, find the numerator of the fraction immediately " +
                              "to the left of 3/7.");
            const int dLimit = 1_000_000;

            HashSet<Tuple<int, int>> RCFs = new HashSet<Tuple<int, int>>();

            for (int d = 1; d <= dLimit; d++)
            {
                var num = 3.0 / 7.0 * d; // the answer has gotta be within a couple of 3/7 * d
                for (int n = (int)num - 1; n < num + 1; n++)
                {
                    if (HelperMethods.GCD(n, d) == 1)
                        RCFs.Add(new Tuple<int, int>(n, d));
                }
            }

            Tuple<int, int>[] rcfArray = RCFs.OrderBy(t => t.Item1 / (double)t.Item2).ToArray();
            int i = Array.IndexOf(rcfArray, new Tuple<int, int>(3, 7));
            Console.WriteLine(i > -1
                ? $"{rcfArray[i - 1].Item1}/{rcfArray[i - 1].Item2} is left of 3/7 for d <= {dLimit}"
                : $"3/7 not found for d <= {dLimit}");
        }
    }
}

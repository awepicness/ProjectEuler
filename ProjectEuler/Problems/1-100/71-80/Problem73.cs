using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem73
    {
        public void Method()
        {
            Console.WriteLine("how many fractions lie between 1/3 and 1/2 in the sorted set of reduced proper fractions " +
                              "of the form n/d where n < d for d <= 12000?");

            // d <= 8, answer is 3

            const int dLimit = 12000;
            const double lLimit = 0.333333334, uLimit = 0.5;

            List<double> decimals = new List<double>();
            for (int d = 2; d <= dLimit; d++)
                for (int n = 1; n < d; n++)
                    if (HelperMethods.GCD(n, d) == 1)
                        decimals.Add((double) n/d);

            Console.WriteLine($"There are {decimals.Count(d => d > lLimit && d < uLimit)} RPFs between {lLimit} and {uLimit}" +
                              $" for d <= {dLimit}");
        }
    }
}

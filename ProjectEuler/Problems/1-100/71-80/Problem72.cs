using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem72
    {
        public void Method()
        {
            Console.WriteLine("how many elements would be contained in the set of reduced proper fractions, " +
                              "where each fraction takes the form n/d, for d <= 1,000,000?");

            const int dLimit = 1000000;

            // unusable brute force method - too slow for even 10,000, let alone 1,000,000
            //HashSet<Tuple<int, int>> RCFs = new HashSet<Tuple<int, int>>();
            //for (int d = 2; d <= dLimit; d++)
            //    for (int n = 1; n < d; n++)
            //        if (HelperMethods.GCD(n, d) == 1)
            //            RCFs.Add(new Tuple<int, int>(n, d));


            // pattern: for each number d, sum up the numbers with which d is relatively prime
            double count = 0;
            for (int d = 2; d <= dLimit; d++)
                count += HelperMethods.Phi(d);
            
            Console.WriteLine($"the set of RCFs where d <= {dLimit} contains {count} fractions.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem757
    {
        private static Dictionary<int, int[]> stealthyDivisors = new Dictionary<int, int[]>();
        public void Method()
        {
            Console.WriteLine("A positive integer N is stealthy, if there exist positive integers a, b, c, d such that ab = cd = N and a+b = c+d+1.\n" +
                              "For example, 36 = 4*9 = 6*6 is stealthy. You are also given that there are 2851 stealthy numbers not exceeding 10^6.\n" + 
                              "How many stealthy numbers are there that don't exceed 10^14?");

            // I experimented with my isStealthy method below and discovered that all "stealthy" numbers follow an integer series called Bipronics
            // bipronics are numbers defined by the equation: x * (x + 1) * y * (y + 1)

            // answer: 75737353

            const long max = 100000000000000;

            var bipronics = new HashSet<long>(); // oeis A072389
            for (long x = 1; x <= Math.Sqrt(max); x++)
            {
                long xfactor = x * (x + 1);
                if (x > max)
                    break;
                for (long y = 1; y <= x; y++)
                {
                    long yfactor = y * (y + 1);
                    if (yfactor > max)
                        break;

                    long val = xfactor * yfactor;
                    if (val > max)
                        break;
                    
                    bipronics.Add(val);
                }
            }
            
            
            Console.WriteLine($"There are {bipronics.Count} stealthy numbers <= {max}");
        }

        private bool isStealthy(int n)
        {
            var divisors = HelperMethods.GetDivisors(n);
            if (divisors.Length < 4)
                return false;

            for (int j = 0; j < divisors.Length; j += 2)
            {
                int a = divisors[j], b = divisors[j + 1];
                for (int k = j + 2; k < divisors.Length; k += 2)
                {
                    int c = divisors[k], d = divisors[k + 1];
                    if (a + b == c + d + 1)
                    {
                        stealthyDivisors[n] = new int[] {a, b, c, d};
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

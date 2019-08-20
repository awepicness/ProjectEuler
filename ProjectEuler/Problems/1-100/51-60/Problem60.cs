using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem60
    {
        public void Method()
        {
            Console.WriteLine("Find the lowest sum for a set of five primes for which any " +
                              "two primes concatenate to produce another prime.");

            int[] primes = HelperMethods.ESieve(2, 19000);

            int sum = int.MaxValue;
            int count = primes.Length;
            for (int i = 0; i < count; i++)
            {
                int p1 = primes[i];
                string pn1 = p1.ToString();

                if (p1 > sum / 2)
                    break;

                for (int j = i + 1; j < count; j++)
                {
                    int p2 = primes[j];
                    string pn2 = p2.ToString();

                    if (p2 > sum / 2)
                        break;

                    if (   !HelperMethods.IsPrime(long.Parse(pn1 + pn2))
                        || !HelperMethods.IsPrime(long.Parse(pn2 + pn1)))
                        continue;

                    for (int k = j + 1; k < count; k++)
                    {
                        int p3 = primes[k];
                        string pn3 = p3.ToString();

                        if (p3 > sum / 2)
                            break;

                        if (   !HelperMethods.IsPrime(long.Parse(pn1 + pn3))
                            || !HelperMethods.IsPrime(long.Parse(pn3 + pn1))
                            || !HelperMethods.IsPrime(long.Parse(pn2 + pn3))
                            || !HelperMethods.IsPrime(long.Parse(pn3 + pn2)))
                            continue;

                        for (int l = k + 1; l < count; l++)
                        {
                            int p4 = primes[l];
                            string pn4 = p4.ToString();

                            if (p4 > sum / 2)
                                break;

                            if (   !HelperMethods.IsPrime(long.Parse(pn1 + pn4))
                                || !HelperMethods.IsPrime(long.Parse(pn4 + pn1))
                                || !HelperMethods.IsPrime(long.Parse(pn2 + pn4))
                                || !HelperMethods.IsPrime(long.Parse(pn4 + pn2))
                                || !HelperMethods.IsPrime(long.Parse(pn3 + pn4))
                                || !HelperMethods.IsPrime(long.Parse(pn4 + pn3)))
                                continue;

                            for (int m = l + 1; m < count; m++)
                            {
                                int p5 = primes[m];
                                string pn5 = p5.ToString();

                                if (p5 > sum / 2)
                                    break;

                                if (   !HelperMethods.IsPrime(long.Parse(pn1 + pn5))
                                    || !HelperMethods.IsPrime(long.Parse(pn5 + pn1))
                                    || !HelperMethods.IsPrime(long.Parse(pn2 + pn5))
                                    || !HelperMethods.IsPrime(long.Parse(pn5 + pn2))
                                    || !HelperMethods.IsPrime(long.Parse(pn3 + pn5))
                                    || !HelperMethods.IsPrime(long.Parse(pn5 + pn3))
                                    || !HelperMethods.IsPrime(long.Parse(pn4 + pn5))
                                    || !HelperMethods.IsPrime(long.Parse(pn5 + pn4)))
                                    continue;

                                HashSet<int> results = new HashSet<int> {p1, p2, p3, p4, p5};
                                int cursum = results.Sum();
                                Console.WriteLine($"{p1} + {p2} + {p3} + {p4} + {p5} = {cursum}");
                                if (cursum < sum)
                                    sum = cursum;
                                // answer to end program instead of continuing to find solutions since there are none it seems :(
                                if (sum == 26033)
                                    break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"lowest sum: {sum}");
        }
    }
}

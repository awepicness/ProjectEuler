using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem46
    {
        public void Method()
        {
            Console.WriteLine("what is the smallest odd composite (non-prime) number that cannot be written as the sum of a prime and twice a square?");

            const int limit = 100000;

            int[] primes = HelperMethods.ESieve(2, limit);

            HashSet<int> primeSet = new HashSet<int>(primes);
            List<int> composites = new List<int>();

            for (int i = 2; i < limit; i++)
            {
                if(!primeSet.Contains(i))
                    composites.Add(i);
            }

            int result = 0;

            foreach (int composite in composites)
            {
                if (composite % 2 == 0)
                    continue;

                bool compCanBeWritten = false;

                for (int p = 0; primes[p] < composite; p++)
                {
                    for (int i = 1; i <= Math.Sqrt(composite); i++)
                    {
                        if (primes[p] + 2 * i * i == composite)
                        {
                            compCanBeWritten = true;
                            break;
                        }
                    }

                    if (compCanBeWritten)
                        break;
                }

                if (!compCanBeWritten)
                {
                    result = composite;
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}

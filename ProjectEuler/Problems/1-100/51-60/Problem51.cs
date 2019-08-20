using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem51
    {
        public void Method()
        {
            Console.WriteLine("What is the smallest prime which, by replacing part of the number " +
                              "(not necessarily adjacent digits) with the same digit, " +
                              "is part of an eight prime value family.");

            // given: 
            // 13 is the smallest for a six prime value family (13, 23, 43, 53, 73, 83 all prime)
            // 56003 is the smallest for 7 (56003, 56113, 56333, 56443, 56663, 56773, 56993)

            // lower bound:
            // number must have at least 3 digits - 111, 222, 333 aren't prime so that rules out any 3 digit possibility
            // there's gotta be a better way than brute force guessing the lower bound, but let's just start with 1000
            // arbitrary upper limit for now

            const int familySize = 8;

            int[] primes = HelperMethods.ESieve(10000, 1000000);

            HashSet<int> invalids = new HashSet<int>();

            // iterate through each prime possibility
            foreach (int prime in primes)
            {
                string p = prime.ToString();

                // iterate through each possible permutation of indices
                for (int i = 0; i < p.Length; i++)
                {
                    for (int j = i + 1; j < p.Length; j++)
                    {
                        for (int k = j + 1; k < p.Length; k++)
                        {
                            // iterate through each possible number and replace the characters at indices
                            // i,j,k with num

                            int notPrimeCount = 0;
                            List<int> column = new List<int>();
                            for (char num = '0'; num <= '9'; num++)
                            {
                                StringBuilder sb = new StringBuilder(p)
                                {
                                    [i] = num,
                                    [j] = num,
                                    [k] = num
                                };
                                int cur = int.Parse(sb.ToString());
                                if (cur.ToString().Length != p.Length)
                                    continue;
                                if (!HelperMethods.IsPrime(cur))
                                    notPrimeCount++;
                                else 
                                    column.Add(cur);

                                if (notPrimeCount == 3)
                                    break;
                                
                                // must be valid here --> it's prime and not (yet) in the invalid cache
                                if (column.Count < familySize)
                                    continue;

                                Console.WriteLine("Family of 8 found");
                                Console.WriteLine($"min: {column.Min()}");
                                Console.WriteLine("Family: ");
                                foreach(int n in column)
                                    Console.WriteLine(n);
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("no result found");
        }
    }
}

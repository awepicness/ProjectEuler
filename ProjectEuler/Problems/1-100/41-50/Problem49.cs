using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.Problems
{
    class Problem49
    {
        public void Method()
        {
            Console.WriteLine("find an increasing sequence of 3 numbers, each with 4 digits, where the numbers are prime and permutations of each other.");
            // ex: 1487 is prime. 1487 + 3330 = 4817
            // 4817 is prime. 4817 + 3330 = 8147
            // 8147 is prime.


            // find all primes
            HashSet<int> primes = new HashSet<int>();
            const int lowLimit = 1000;
            const int upLimit = 10000;
            for (int i = lowLimit; i < upLimit; i++)
                if (HelperMethods.IsPrime(i))
                    primes.Add(i);

            // somehow need to find sequences of primes that increase by the same amount
            // go through each number and add arbitrary amounts up to 5000 and check if the sums are prime and permutations?
            // very computationally expensive but should work

            List<List<int>> results = new List<List<int>>();
            // iterate through each prime number
            foreach (int prime in primes)
            {
                // try adding every possible value to the prime, check if new result is prime.
                // if so, add i again to that prime and check if the next new result is prime.
                HashSet<int> primeDigits = new HashSet<int>();
                foreach (char c in prime.ToString())
                    primeDigits.Add(c - '0');


                for (int i = 1; i < upLimit / 2; i++)
                {
                    if (primes.Contains(prime + i) && primes.Contains(prime + 2 * i))
                    {
                        // check if numbers are permutations of each other
                        HashSet<int> primePlusI = new HashSet<int>();
                        foreach (char c in (prime + i).ToString())
                            primePlusI.Add(c - '0');

                        // check second number
                        if (primeDigits.SetEquals(primePlusI))
                        {
                            HashSet<int> PrimePlusTwoI = new HashSet<int>();
                            foreach (char c in (prime + 2 * i).ToString())
                                PrimePlusTwoI.Add(c - '0');
                            if (primeDigits.SetEquals(PrimePlusTwoI))
                            {
                                results.Add(new List<int> { prime, prime + i, prime + 2 * i });
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"results contains {results.Count} possible answers. These are the results, the concatenation of the numbers in each possibility:");
            foreach (List<int> list in results)
            {
                Console.WriteLine();
                StringBuilder result = new StringBuilder();
                foreach (int i in list)
                    result.Append(i);
                Console.WriteLine(result.ToString());
            }

            Console.WriteLine("Note - both results work, but the first one is given as an example. The program still finds it anyways");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem32
    {
        private static readonly HashSet<int> digits = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public void Method()
        {
            Console.WriteLine("find the sum of all products whose multiplicand/multiplier/product " +
                              "identity can be written as a 1-9 pandigital");

            // ex: 39 x 186 = 7254. these numbers contain all digits 1-9

            HashSet<int> products = new HashSet<int>();

            // lower bound for 2dig*3dig = 10*100 = 1000 --- total 9 dig
            // upper bound for 2dig*3dig = 99*999 = 98901, total 10 dig

            for(int i = 1; i < 10000; i++)
                for (int j = i + 1; j < 10000; j++)
                {
                    int prod = i * j;
                    if (prod > 99999)
                        break;

                    string concat = $"{i}{j}{prod}";
                    if (concat.Length != 9)
                        continue;
                    if (HelperMethods.IsPandigital(long.Parse(concat)))
                        products.Add(prod);
                }



            Console.WriteLine($"There are {products.Count} products in which the concatenation of 2 of their divisors and the product itself results in a 1-9 pandigital number");
            Console.WriteLine($"Their sum is {products.Sum()}");
        }
    }
}

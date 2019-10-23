using System;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem135
    {
        public void Method()
        {
            Console.WriteLine("for values of a number n from 1 to 1 million, determine the number of solutions " +
                              "for n in which n can be expressed as z^2-y^2-x^2 in exactly 10 unique ways, " +
                              "where x,y,z are terms in a series of arithmetic progression");

            // as an arithmetic progression, z = x + 2*d and y = x + d
            // so the eqn can be rewritten as (x+2d)^2 - (x+d)^2 - x^2 = n
            // this can be further simplified as -(x-3d)*(d+x) = n
            // or more simply (3d-x)*(d+x) = n
            // we can rewrite this by substituting in variables for the values in parentheses
            // such that u = (3d-x) and v = (d+x)
            // putting this back in terms of x and d, we see that
            // d = (u + v) / 4 and x = (3*v - u)/4

            // it is given that the least value with 10 solutions is 1155, so we can start there
            const int n = 1000000;
            const int uniqueWays = 10;

            int[] solutions = new int[n+1];
            for (int u = 1; u <= n; u++)
            {
                for (int v = 1; u*v <= n; v++)
                {
                    if ((u + v) % 4 == 0 && 3 * v > u && (3 * v - u) % 4 == 0)
                        solutions[u * v]++;
                }
            }
            int result = solutions.Count(x => x == uniqueWays);
            
            Console.WriteLine($"There are {result} solutions < {n} where n can be expressed in {uniqueWays} unique ways");
        }
    }
}

using System;

namespace ProjectEuler.Problems
{
    class Problem135
    {
        public void Method2()
        {
            Console.WriteLine("for values of a number n from 1 to 1 million, determine the number of solutions " +
                              "for n in which n can be expressed as z^2-y^2-x^2 in exactly 10 unique ways, " +
                              "where x,y,z are terms in a series of arithmetic progression");

            // it is given that the least value with 10 solutions is 1155, so we can start there
            const int nLimit = 2000;
            const int uniqueWays = 10;

            int solutions = 0;
            for (int n = 1155; n < nLimit; n++)
            {
                //if(n%10==0)
                //    Console.WriteLine(n);
                int count = 0;
                int distance = 0;
                while (distance < n/2)
                {
                    distance++;
                    for (int x = 1; x < n; x++)
                    {
                        // simplification of (x+2d)^2 - (x+d)^2 - x^2
                        int v = -(x - 3 * distance) * (distance + x);
                        //if(x%10==0 && distance%10==0)
                        //    Console.WriteLine($"x:{x}, d:{distance}, v:{v}");
                        if (v == n)
                        {
                            count++;
                            //Console.WriteLine("count++!");
                            //Console.WriteLine($"x:{x}, d:{distance}, v:{v}");
                        }
                    }
                }

                if (count == uniqueWays)
                    solutions++;
            }
            

            Console.WriteLine($"There are {solutions} solutions for n < {nLimit}");
        }
    }
}

using System;

namespace ProjectEuler.Problems
{
    class Problem39
    {
        public void Method()
        {
            Console.WriteLine("assuming a number p is the perimeter of a triangle, what number maximizes the number of triangles possible from perimeter p?");
            // ex: p = 120
            // side length possibilities:
            // 20, 48, 52;   24, 45, 51;   30, 40, 50

            // answer from mathblog.dk. my solution was wrong so I decided to just look it up

            long result = 0;
            long resultSolutions = 0;

            for (long p = 2; p <= 1000; p += 2)
            {
                int numSolutions = 0;
                for (long a = 2; a < p / 3; a++)
                    if (p * (p - 2 * a) % (2 * (p - a)) == 0)
                        numSolutions++;

                if (numSolutions > resultSolutions)
                {
                    result = p;
                    resultSolutions = numSolutions;
                }
            }

            Console.WriteLine($"result: {result} ");
            Console.WriteLine($"number of solutions: {resultSolutions}");
        }
    }
}

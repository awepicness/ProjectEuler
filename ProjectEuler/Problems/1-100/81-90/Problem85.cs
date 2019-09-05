using System;

namespace ProjectEuler.Problems
{
    class Problem85
    {
        public void Method()
        {
            Console.WriteLine("Although there exists no rectangular grid that can be sectioned into 2 million rectangles, " +
                              "find the area of the grid with the nearest solution");

            // formula: n*m*(n+1)*(m+1)/4 = number of sub-rectangles in an n x m rectangle

            // max value of n^2 / 4 = 2000000 solved for n is 2828.4
            const int nMax = 2001;
            const int searchValue = 2000000;

            int min = int.MaxValue;
            int nMin = 0, mMin = 0, nBymMin = 0;
            for (int n = 1; n < nMax; n++)
            {
                for (int m = 1; m <= n; m++)
                {
                    int cur = n * m * (n + 1) * (m + 1) / 4;
                    if (cur > searchValue)
                        break;

                    int abs = searchValue - cur;
                    if (abs >= min)
                        continue;

                    min = abs;
                    nMin = n;
                    mMin = m;
                    nBymMin = cur;
                }
            }
            Console.WriteLine($"a(n) {nMin}*{mMin} rectangle has {nBymMin} subs and an area of {nMin * mMin}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    class Problem92
    {
        public void Method()
        {
            Console.WriteLine("Using square digit chains, how many starting numbers below 10 million will arrive at 89?");

            const int upperLimit = 10000000;

            // caching answers brought time from 14sec to 4.4sec
            // according to math blog you can use combinatorics, but I haven't really studied that yet
            // and I'm happy that I got the answer on my own
            HashSet<int> cache89 = new HashSet<int>();
            HashSet<int> cache1 = new HashSet<int>();

            int count89 = 0;
            for (int i = 1; i < upperLimit; i++)
            {
                int num = i;
                while (true)
                {
                    int newNum = 0;
                    foreach (char c in num.ToString())
                        newNum += (int) Math.Pow(c - '0', 2);

                    num = newNum;

                    if (newNum == 89 || cache89.Contains(newNum))
                    {
                        count89++;
                        cache89.Add(i);
                        break;
                    }

                    if (newNum == 1 || cache1.Contains(newNum))
                    {
                        cache1.Add(i);
                        break;
                    }
                }
            }

            Console.WriteLine(count89);
        }
    }
}

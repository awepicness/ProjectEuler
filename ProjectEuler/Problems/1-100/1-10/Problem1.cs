using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    class Problem1
    {
        public void Method()
        {
            Console.WriteLine("Find the sum of all multiples of 3 or 5 that are less than 1000");

            List<int> multiples = new List<int>();

            for (int i = 0; i < 1000; i++)
                if (i % 3 == 0 || i % 5 == 0)
                    multiples.Add(i);

            int sum = multiples.Sum();
            Console.WriteLine(sum);
        }
    }
}

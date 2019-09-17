using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem197
    {
        private const double twoPow = 30.403243784;
        private const double tenPow = 1E-09;
        public void Method()
        {
            Console.WriteLine("Given the recursive function f(x) (coded below), find u[n] + u[n+1] for n = 10^12");

            // I don't understand it completely, but originally made a dictionary of repeated values and noticed the 
            // values when i was a factor of 1001 alternated between 2 values, as if the function made a loop.
            // so I just added those values and got the right answer

            double u = -1.0;
            double sum = 0.0;
            for(long i = 1; i <= 2002; i++)
            {
                u = func(u);
                if(i % 1001 == 0)
                    sum += u;
            }

            Console.WriteLine($"result: {sum}");
        }

        private double func(double x) => Math.Floor(Math.Pow(2, twoPow - x * x)) * tenPow;
    }
}

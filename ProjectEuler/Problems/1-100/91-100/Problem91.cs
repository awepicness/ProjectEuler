using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem91
    {
        public void Method()
        {
            Console.WriteLine("how many right triangles with integer coordinates are there such that" +
                              " one point is fixed at the origin and the other two ( (x1,y1), (x2,y2) )" +
                              " have values for each x and y >= 0 and <= 50?");

            // see OEIS A155154: https://oeis.org/A155154

            // thanks mathblog.dk, you helped me when no one else would :')
            const int n = 50;

            int result = n * n * 3;
            for (int x = 1; x <= n; x++)
            {
                for (int y = 1; y <= n; y++)
                {
                    int f = HelperMethods.GCD(x, y);
                    result += Math.Min(y * f / x, (n - x) * f / y) * 2;
                }
            }

            Console.WriteLine(result);
        }
    }
}

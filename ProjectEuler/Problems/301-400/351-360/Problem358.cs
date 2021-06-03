using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem358
    {
        public void Method2()
        {
            Console.WriteLine("A cyclic number with n digits has a very interesting property:" +
                              "When it is multiplied by 1, 2, 3, 4, ... n, all the products have exactly the same digits, " +
                              "in the same order, but rotated in a circular fashion!");

            naiveCyclic();
        }

        private void naiveCyclic()
        {
            var cyclics = new List<int>();

            int n = 11;
            while (true)
            {
                //if(n % 1000 == 0)
                //    Console.WriteLine(n);
                string ns = n.ToString();
                var chars = new HashSet<char>(ns);

                bool isCyclic = true;
                for (int i = 1; i <= ns.Length; i++)
                {
                    if (!new HashSet<char>((n * i).ToString()).SetEquals(chars))
                    {
                        isCyclic = false;
                        break;
                    }
                }

                if (isCyclic)
                {
                    cyclics.Add(n);
                    Console.WriteLine(n);

                    if(cyclics.Count == 2)
                        break;
                }

                n++;
            }

            Console.WriteLine(n);
        }
    }
}

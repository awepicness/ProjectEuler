using System;

namespace ProjectEuler.Problems
{
    class Problem33
    {
        public void Method()
        {
            Console.WriteLine("Find the denominator of the resulting product of 4 fractions such that:" +
                              "\n - each fraction's numerator and denominator contain 2 digits," +
                              "\n - removing the common digit of the numerator and denominator and dividing them yields " +
                              "\n\t the same result as dividing the numerator and denominator," +
                              "\n - trivial examples where num and denom % 10 = 0 (such as 30/50) are ignored\n");

            decimal product = 1;
            int count = 0;
            for (decimal num = 10; num < 100; num++)
            {
                for(decimal den = num + 1; den < 100; den++)
                {
                    if (num % 10 == 0 && den % 10 == 0)
                        continue;

                    string ns = num.ToString(), ds = den.ToString();

                    int pos;
                    int dpos;
                    if (ns[0] == ds[0])
                    {
                        pos = 0; dpos = 0;
                    }
                    else if (ns[0] == ds[1])
                    {
                        pos = 0; dpos = 1;
                    }
                    else if (ns[1] == ds[0])
                    {
                        pos = 1; dpos = 0;
                    }
                    else if (ns[1] == ds[1])
                    {
                        pos = 1; dpos = 1;
                    }
                    else continue;

                    decimal newNum = decimal.Parse(pos == 0 ? ns.Substring(1) : ns.Substring(0, 1));
                    decimal newDen = decimal.Parse(dpos == 0 ? ds.Substring(1) : ds.Substring(0, 1));

                    if (newDen == 0 || num / den != newNum / newDen)
                        continue;

                    count++;
                    product *= newNum / newDen;
                    Console.WriteLine($"{num}/{den}, --> {newNum}/{newDen}");
                }
            }

            Console.WriteLine($"{count} nums found, product: {product}");
            Console.WriteLine("not gonna take the time to write an algo to find denom of product, it's just 100");
        }
    }
}

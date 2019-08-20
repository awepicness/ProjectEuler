using System;

namespace ProjectEuler
{
    class Problem8
    {
        public void Method()
        {
            Console.WriteLine("find the thirteen adjacent digits in the following 1000 digit number that have the greatest product");
            // result: 23514624000
            const string thousandDigits =
                "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";

            decimal totalProduct = 0;
            decimal[] productDigits = new decimal[13];
            decimal[] thirteenDigits = new decimal[13];
            for (int i = 0; i < thirteenDigits.Length; i++)
                thirteenDigits[i] = 0;

            // iterate through each character (digit) in string
            for (int i = 0; i < thousandDigits.Length - thirteenDigits.Length; i++)
            {
                // set each of the thirteen values based on current string index
                for (int j = 0; j < thirteenDigits.Length; j++)
                    thirteenDigits[j] = int.Parse(thousandDigits[i + j].ToString());
                
                // once set, iterate through each and multiply their values
                decimal currentProduct = 1;
                foreach (decimal j in thirteenDigits)
                    currentProduct *= j;
                
                // compare to max product found so far
                if (currentProduct > totalProduct)
                {
                    totalProduct = currentProduct;
                    // clone digits
                    for (int d = 0; d < thirteenDigits.Length; d++)
                        productDigits[d] = thirteenDigits[d];
                }

            }

            Console.WriteLine($"The largest product you can make from this string is {totalProduct}");
            Console.WriteLine("This is made by multiplying the following digits:");

            for (int i = 0; i < productDigits.Length; i++)
                if (i < productDigits.Length - 1)
                    Console.Write(productDigits[i] + "*");
                else
                    Console.Write(productDigits[i]);
            Console.WriteLine();
        }
    }
}

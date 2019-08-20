using System;

namespace ProjectEuler
{
    class Problem6
    {
        public void Method()
        {
            Console.WriteLine("find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum");

            // sum of squares of the first ten natural numbers: 1^2 + 2^2 + ... + 10^2 = 385
            // the square of the sum of the first ten natural numbers: (1 + 2 + ... + 10)^2 = 3025
            // diff between square of sum of first ten natural numbers and sum of squares of first ten natural numbers is 3025-385 = 2640

            int sumOfHundredSquares = 0, squareOfHundredSums = 0;
            for (int i = 1; i <= 100; i++)
            {
                sumOfHundredSquares += i * i;
                squareOfHundredSums += i;
            }

            squareOfHundredSums *= squareOfHundredSums;

            int difference = squareOfHundredSums - sumOfHundredSquares;
            Console.WriteLine("The difference of the square of the sum of the first hundred natural numbers " +
                              "and the sum of squares of the first hundred natural numbers: " +
                              $"{squareOfHundredSums} - {sumOfHundredSquares} = {difference}");
        }
    }
}

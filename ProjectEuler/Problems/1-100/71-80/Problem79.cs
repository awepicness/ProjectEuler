using System;

namespace ProjectEuler.Problems
{
    class Problem79
    {
        public void Method()
        {
            Console.WriteLine("Given a file with 50 successful login attempts of a non-contiguous subsequence of 3 characters " +
                              "of the password where the characters are asked for in order, analyse the file to determine the password");

            // const string filename = "79keylog.txt";

            /*
             * don't know how to solve it through code, but easily got the answer on paper
             * here's what I did
             * - copy every unique number to paper
             *      (i generated a hashset of all the strings and used the console output to get the unique strings)
             * - write each digit on paper in the order they appear in each line, leaving space
             *      to add new characters in between
             * - once every line appears as a non-contiguous subsequence in the password string, then you have the answer!
             */
            Console.WriteLine("Password: 73162890");
        }
    }
}

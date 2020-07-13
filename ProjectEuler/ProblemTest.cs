using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    // class for testing other problems
    class ProblemTest
    {
        public void Method()
        {
            var input = 0;
            var expectedAnswer = true;
            int iters = 100000;

            // Func<input type, output type>
            Func<int, int> function = null;
            Stopwatch stop = Stopwatch.StartNew();
            var ans = function(input);
            for (int i = 0; i < iters - 1; i++)
                ans = function(input);
            stop.Stop();

            Console.WriteLine($"Answer: {ans}\n\n" +
                              $"Correct: {Equals(ans, expectedAnswer)}\n" +
                              $"Iterations: {iters}\n" +
                              $"Time per iteration: {stop.ElapsedMilliseconds * 1000 / iters} us\n" +
                              $"Total time: {stop.ElapsedMilliseconds} ms\n");
        }

    }
}
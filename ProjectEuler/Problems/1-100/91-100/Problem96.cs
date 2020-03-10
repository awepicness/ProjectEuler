using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectEuler.HelperClasses;

namespace ProjectEuler.Problems
{
    class Problem96
    {
        const int n = 9;
        public void Method()
        {
            Console.WriteLine("given 50 different sudoku puzzles, solve each one. Take the first 3 numbers in the first" +
                              " row of each solution, interpret them as a single 3-digit number, and sum all of them" +
                              " together as your answer");

            const string file = "96sudoku.txt";

            int sum = 0;
            List<Sudoku> puzzles = BuildSudokuList(file);
            for (int i = 0; i < 50; i++)
            {
                Sudoku p = puzzles[i];
                p.solveSudoku();

                // error checking - none found!
                //if(!puzzles[i].isAnswer())
                //    Console.WriteLine("ERROR");

                sum += int.Parse($"{p[0, 0]}{p[0, 1]}{p[0, 2]}");
            }
            
            Console.WriteLine($"sum: {sum}");
        }

        private List<Sudoku> BuildSudokuList(string fileName)
        {
            List<Sudoku> puzzles = new List<Sudoku>();

            List<string> fileLines = File.ReadAllLines(fileName).ToList();

            Sudoku current = new Sudoku(new int[n, n]);
            int i = 0;
            foreach (string line in fileLines)
            {
                // add puzzle to list, reset puzzle
                if (line.Contains("Grid"))
                {
                    puzzles.Add(current);
                    current = new Sudoku(new int[n, n]);
                    i = 0;
                    continue;
                }

                // else update puzzle lines
                for (int j = 0; j < n; j++)
                {
                    char c = line[j];
                    current.Grid[i, j] = c - '0';
                }
                i++;
            }
            puzzles.Add(current);
            return puzzles;
        }


    }
}

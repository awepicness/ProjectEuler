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
        public void Method2()
        {
            Console.WriteLine("given 50 different sudoku puzzles, solve each one. Take the first 3 numbers in the first" +
                              " row of each solution, interpret them as a single 3-digit number, and sum all of them" +
                              " together as your answer");

            const string file = "96sudoku.txt";


            List<Sudoku> puzzles = BuildSudokuList(file);
            
            Console.WriteLine();
        }

        private List<Sudoku> BuildSudokuList(string fileName)
        {
            List<Sudoku> puzzles = new List<Sudoku>();

            List<string> fileLines = File.ReadAllLines(fileName).ToList();
            fileLines.RemoveAt(0); // remove "grid 0" line

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

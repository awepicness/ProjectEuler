using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.HelperClasses
{
    public class Sudoku
    {
        private const int n = 9;
        public int[,] Grid { get; set; }

        public Sudoku(int[,] grid)
        {
            if(grid.GetLength(0) != n || grid.GetLength(1) != n)
                throw new Exception("grid must be 9x9");

            Grid = grid;
        }

    }

    public static class SudokuExtensions
    {
        private const int n = 9;


        public static bool isAnswer(this Sudoku s)
        {
            for (int i = 0; i < n; i++)
            {
                // build row and column;
                int[] row = new int[n], col = new int[n];
                for (int j = 0; j < n; j++)
                {
                    row[j] = s.Grid[i, j];
                    col[j] = s.Grid[j, i];
                }

                // verify rows and columns
                if (!verifyRowCol(row) || !verifyRowCol(col))
                    return false;
            }

            // generate boxes
            int[,] box1 = new int[3,3];
            int[,] box2 = new int[3,3];
            int[,] box3 = new int[3,3];
            int[,] box4 = new int[3,3];
            int[,] box5 = new int[3,3];
            int[,] box6 = new int[3,3];
            int[,] box7 = new int[3,3];
            int[,] box8 = new int[3,3];
            int[,] box9 = new int[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    box1[i, j] = s.Grid[i, j];
                    box4[i, j] = s.Grid[i + 3, j];
                    box7[i, j] = s.Grid[i + 6, j];
                }

                for (int j = 3; j < 6; j++)
                {
                    box2[i, j - 3] = s.Grid[i, j];
                    box5[i, j - 3] = s.Grid[i + 3, j];
                    box8[i, j - 3] = s.Grid[i + 6, j];
                }

                for (int j = 6; j < 9; j++)
                {
                    box3[i, j - 6] = s.Grid[i, j];
                    box6[i, j - 6] = s.Grid[i + 3, j];
                    box9[i, j - 6] = s.Grid[i + 6, j];
                }
            }
            
            // verify boxes
            List<int[,]> boxes = new List<int[,]>
                { box1, box2, box3, box4, box5, box6, box7, box8, box9 };

            return boxes.All(verifyBox);
        }

        private static HashSet<int> answerArr = new HashSet<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};

        private static bool verifyRowCol(int[] r) => r.ToHashSet().SetEquals(answerArr);

        private static bool verifyBox(int[,] box)
        {
            HashSet<int> vals = new HashSet<int>();
            foreach(int i in box)
                vals.Add(i);
            return vals.SetEquals(answerArr);
        }
    }
}

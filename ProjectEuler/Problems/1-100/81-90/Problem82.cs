using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler.Problems
{
    class Problem82
    {
        public void Method()
        {
            Console.WriteLine("Find the minimal path sum in the provided file containing an 80x80 matrix from any number in the left column " +
                              "to any number in the right column by moving right, up, and down");

            const string filename = "82matrix.txt";

            const int n = 80;

            // read file
            string[] file = File.ReadAllLines(filename);

            // create string matrix
            string[][] stringMatrix = new string[file.Length][];
            for (int i = 0; i < file.Length; i++)
                stringMatrix[i] = file[i].Split(',');

            // initialize integer matrix
            int[][] matrix = new int[stringMatrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
                matrix[i] = new int[stringMatrix.Length];

            // convert string matrix to integer matrix
            for (int i = 0; i < n; i++)
                matrix[i] = Array.ConvertAll(stringMatrix[i], int.Parse);

            // solve
            int min = int.MaxValue;

            // find the minimum starting at each row
            for (int i = 0; i < matrix.Length; i++)
            {

            }
        }
    }

    class Node
    {
        public Node Up { get; set; }
        public Node Right { get; set; }
        public Node Down { get; set; }
        public int Key { get; set; }
        public string Color { get; set; } 
        public int? DiscoveryTime { get; set; }
        public int? FinishTime { get; set; }

        public Node(int key, string color)
        {
            Key = key;
            Color = color;
        }
    }

    class Edge
    {
        public Node U { get; set; }
        public Node V { get; set; }
        public double? Weight { get; set; }

        public Edge(Node u, Node v, double? weight)
        {
            U = u;
            V = v;
            Weight = weight;
        }
    }

    class Graph
    {
        public List<Node> Vertices { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph(List<Node> vertices, List<Edge> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }
    }
}

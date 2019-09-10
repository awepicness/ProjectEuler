using System;
using System.Collections.Generic;
using System.IO;
using ProjectEuler.HelperClasses;

namespace ProjectEuler.Problems
{
    class Problem107
    {
        public void Method()
        {
            Console.WriteLine("Using the given file, find the maximum saving which can be achieved by removing " +
                              "redundant edges whilst ensuring that the network remains connected.");

            // unfortunately, I haven't learned anything about forests and minimizing undirected graphs yet
            // so this fell into the "I don't know where to start" problems 

            // update 9/10/2019 - I get it now, this is just the minimum spanning tree problem
            // I think this follows floyd-warshalls algo - get all edges, sort by weight, and take each edge as long as a cycle is not produced

            // thank you mathblog.dk

            // read input file
            const string filename = "107network.txt";
            string[] lines = File.ReadAllLines(filename);

            // create a forest F (set of trees) where each vertex in the graph is a separate tree
            int N = lines[0].Split(',').Length;
            DisjointSet vertices = new DisjointSet(N);

            // create a set S containing all the edges in the graph
            // the tuple contains weight,vertex, vertex
            List<Tuple<int, int, int>> edges = new List<Tuple<int, int, int>>();
            int initialWeight = 0;

            for (int i = 0; i < N; i++)
            {
                string[] edge = lines[i].Split(',');

                for (int j = 0; j < i; j++)
                {
                    if (edge[j] != "-")
                    {
                        int weight = int.Parse(edge[j]);
                        edges.Add(new Tuple<int, int, int>(weight, i, j));
                        initialWeight += weight;
                    }
                }
            }

            // sort edges to have the minimum weight at top
            edges.Sort();
            int k = 0;

            // while S is non-empty and F is not yet spanning
            int minSpanningTreeWeight = 0;
            while (!vertices.isSpanning())
            {
                // remove an edge with minimum weight from S
                // since we have a sorted list we just go through the list

                // if that edge connects two different trees,
                // then add it to the forest,
                // combining two trees into a single tree
                if (vertices.Find(edges[k].Item2) != vertices.Find(edges[k].Item3))
                {
                    vertices.Union(edges[k].Item2, edges[k].Item3);
                    minSpanningTreeWeight += edges[k].Item1;
                }

                k++;
            }

            Console.WriteLine($"The saving is {initialWeight - minSpanningTreeWeight}");
        }
    }
}

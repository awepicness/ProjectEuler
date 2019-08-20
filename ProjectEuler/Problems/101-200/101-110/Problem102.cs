using System;
using System.IO;
using ProjectEuler.HelperClasses;

namespace ProjectEuler.Problems
{
    class Problem102
    {
        public void Method()
        {
            Console.WriteLine("Using the given text file of triangle coordinates, determine how many of the triangles contain the origin");

            const string filename = "102triangles.txt";

            string[] trianglesFile = File.ReadAllLines(filename);

            int originCount = 0, triangleCount = 0;
            foreach (string str in trianglesFile)
            {
                string[] triangleString = str.Split(',');
                double[] X = { double.Parse(triangleString[0]), double.Parse(triangleString[1]) };
                double[] Y = { double.Parse(triangleString[2]), double.Parse(triangleString[3]) };
                double[] Z = { double.Parse(triangleString[4]), double.Parse(triangleString[5]) };
                Triangle t = new Triangle(X, Y, Z);
                triangleCount++;
                if (t.ContainsOrigin())
                    originCount++;
            }

            Console.WriteLine($"{originCount} / {triangleCount} triangles contain the origin");
        }
    }
}

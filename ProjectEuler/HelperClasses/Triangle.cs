using System;

namespace ProjectEuler.HelperClasses
{
    class Triangle
    {
        public double[] A { get; }
        public double[] B { get; }
        public double[] C { get; }
        public double Area { get; }

        public Triangle(double[] a, double[] b, double[] c)
        {
            if(a.Length != 2 || b.Length != 2 || c.Length != 2)
                throw new IndexOutOfRangeException("Coordinates only contain 2 numbers");

            A = a;
            B = b;
            C = c;

            Area = TriangleArea(A[0], A[1], B[0], B[1], C[0], C[1]);
        }

        public bool ContainsOrigin()
        {
            return ContainsPoint();
        }

        public bool ContainsPoint(double pointX = 0, double pointY = 0)
        {
            // calculate area of each triangle of 2 points and the origin (3 total) 
            // if those areas sum to the area of the full triangle, the origin is contained

            double area1 = TriangleArea(pointX, pointY, B[0], B[1], C[0], C[1]);
            double area2 = TriangleArea(A[0], A[1], pointX, pointY, C[0], C[1]);
            double area3 = TriangleArea(A[0], A[1], B[0], B[1], pointX, pointY);

            return area1 + area2 + area3 == Area;
        }


        private static double TriangleArea(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }
    }
}

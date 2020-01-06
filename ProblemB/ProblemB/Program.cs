using System;

namespace ProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(-5, 1);
            Point point2 = new Point(-2, 2);
            Point point3 = new Point(1, 3);
            Point point4 = new Point(4, 4);
            Point point5 = new Point(1, 2);
            Point point6 = new Point(1, -1);
            Point point7 = new Point(-8, 0);

            Point[] points = { point1, point2, point3, point4, point5, point6, point7 };
            
            Algorithm algorithm = new Algorithm(points);

            Console.WriteLine(algorithm.maxValue().ToString());
        }
    }
}

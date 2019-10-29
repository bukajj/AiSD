using System;

namespace ProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            Point startPoint = new Point(2,2);
            Point endPoint = new Point(8,-100);
            Algorithm algorithm = new Algorithm(startPoint, endPoint);
            Console.WriteLine(algorithm.JumpsAlgorithm());
        }
    }
}

using System;

namespace ProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testCounter = 0; testCounter<tests; testCounter++)
            {
                int counter = 0;
                int jumpers = Convert.ToInt32(Console.ReadLine());
                Point[,] points = new Point[2, jumpers];
                for (int i = 0; i < jumpers; i++)
                {
                    int[] point_args = new int[2];
                    string[] text = Console.ReadLine().Split(new char[] { ' ' });
                    for (int j=0; j<2; j++)
                    {
                        point_args[j] = Convert.ToInt32(text[j]);
                    }

                    Point point = new Point(point_args[0], point_args[1]);
                    points[0, i] = point;
                }
                for (int i = 0; i < jumpers; i++)
                {
                    int[] point_args = new int[2];
                    string[] text = Console.ReadLine().Split(new char[] { ' ' });
                    for (int j = 0; j < 2; j++)
                    {
                        point_args[j] = Convert.ToInt32(text[j]);
                    }

                    Point point = new Point(point_args[0], point_args[1]);
                    points[1, i] = point;
                }
                for(int i=0; i<jumpers; i++)
                {
                    Algorithm algorithm = new Algorithm(points[0, i], points[1, i]);
                    counter += algorithm.JumpsAlgorithm();
                }
                Console.WriteLine(counter.ToString());
            }
        }
    }
}

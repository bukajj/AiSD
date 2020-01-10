using System;
using System.IO;

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            int testsCount = Convert.ToInt32(Console.ReadLine());
            
            for (int testCounter=0; testCounter < testsCount; testCounter++)
            {
                int friendsCount = Convert.ToInt32(Console.ReadLine());
                Point[] points = new Point[friendsCount];
                
                for (int friendsCouner = 0; friendsCouner < friendsCount; friendsCouner++)
                {
                    int[] point = new int[2];
                    string[] splitText = Console.ReadLine().Split(new char[] { ' ' });
                    for (int i=0; i < 2; i++)
                    {
                        point[i] = Convert.ToInt32(splitText[i]);
                    }
                    points[friendsCouner] = new Point(point[0], point[1]);
                }

                Algorithm algorithm = new Algorithm(points);

                Console.WriteLine(algorithm.ShortestPathAlgorithm().ToString());
            }
        }
    }
}

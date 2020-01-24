using System;
using System.IO;

/*
 * Klasa, dzięki której wykonywany jest program. 
 * Używane jest standardowe wejście i wyjście, tak jak jest to opisane w wymaganiach.
 */

namespace ProblemA
{
    class Program
    {
        static void Main(string[] args)
        {
            int tests = Convert.ToInt32(Console.ReadLine());
            
            for (int testCounter=0; testCounter < tests; testCounter++)
            {
                int friends = Convert.ToInt32(Console.ReadLine());
                Point[] points = new Point[friends];
                
                for (int friendsCouner = 0; friendsCouner < friends; friendsCouner++)
                {
                    int[] point = new int[2];
                    string[] text = Console.ReadLine().Split(new char[] { ' ' });
                    for (int i=0; i < 2; i++)
                    {
                        point[i] = Convert.ToInt32(text[i]);
                    }
                    points[friendsCouner] = new Point(point[0], point[1]);
                }

                Algorithm algorithm = new Algorithm(points);

                Console.WriteLine(algorithm.ShortestPath().ToString());
            }
        }
    }
}

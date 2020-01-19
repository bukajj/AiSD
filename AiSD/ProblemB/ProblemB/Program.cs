using System;

/*
 * Wykonanie programu zgodnie z wymaganiami.
 */

namespace ProblemB
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentLine = Console.ReadLine();
            int mainCounter = 0;

            while(!currentLine[0].Equals('-') && !currentLine[1].Equals('-'))
            {
                Point[] points = new Point[1000];
                int counter = 0;

                while (!currentLine[0].Equals('-') && !currentLine[1].Equals('-'))
                {
                    string[] text = currentLine.Split(new char[] { ' ' });
                    int[] point_args = new int[2];

                    for (int i=0; i<2; i++)
                    {
                        point_args[i] = Convert.ToInt32(text[i]);
                    }

                    points[counter] = new Point(point_args[0], point_args[1]);
                    counter++;
                    currentLine = Console.ReadLine();
                }

                Point[] new_points = new Point[counter];
                for (int i=0; i<new_points.Length; i++)
                {
                    new_points[i] = points[i];
                }

                Algorithm algorithm = new Algorithm(new_points);
                Console.WriteLine((mainCounter+1).ToString() + ". " + algorithm.maxValue().ToString());
                currentLine = Console.ReadLine();
                mainCounter++;
            }
        }   
    }
}

using System;

/*
 * Klasa wykonująca program, zgodnie z założeniami.
 */

namespace ProblemC
{
    class Program
    {
        static void Main(string[] args)
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testCounter = 0; testCounter<tests; testCounter++)
            {
                int jumpers = Convert.ToInt32(Console.ReadLine());
                Point[] starts = new Point[jumpers];
                Point[] ends = new Point[jumpers];
                for (int i = 0; i < jumpers; i++)
                {
                    int[] point_args = new int[2];
                    string[] text = Console.ReadLine().Split(new char[] { ' ' });
                    for (int j=0; j<2; j++)
                    {
                        point_args[j] = Convert.ToInt32(text[j]);
                    }

                    Point point = new Point(point_args[0], point_args[1]);
                    starts[i] = point;
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
                    ends[i] = point;
                }

                MultipleAlgotithms multipleAlgotithms = new MultipleAlgotithms(starts, ends);  

                Console.WriteLine(multipleAlgotithms.algorithm());
            }
        }
    }
}

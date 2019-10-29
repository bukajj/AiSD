using System;

namespace ShortestPathApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ilość prób: ");
            int z = int.Parse(Console.ReadLine());
            while(z>50 || z < 1)
            {
                Console.WriteLine("Podaj wartość 0<z<50");
                z = int.Parse(Console.ReadLine());
            }

            int[] pointsCount = new int[z];
            for (int i=0; i<z; i++)
            {
                Console.WriteLine("Podaj ilość punktów dla próby " + (i + 1) + ": ");
                pointsCount[i] = int.Parse(Console.ReadLine());
                while (pointsCount[i]<1 || pointsCount[i] > 10000)
                {
                    Console.WriteLine("Podaj wartość 0<z<10000");
                    pointsCount[i] = int.Parse(Console.ReadLine());
                }
            }

            Point[][] points = new Point[z][];
            for (int i=0; i<z; i++)
            {
                Console.WriteLine("Próba: " + (i + 1));
                points[i] = new Point[pointsCount[i]];
                Point[] tab = new Point[pointsCount[i]];

                for (int j=0; j<pointsCount[i]; j++)
                {
                    Console.WriteLine("Podaj wartość x punktu " + (j+1) + ": ");
                    int x = int.Parse(Console.ReadLine());
                    x = Point.ArgValidator(x);

                    Console.WriteLine("Podaj wartość y punktu " + (j + 1) + ": ");
                    int y = int.Parse(Console.ReadLine());
                    y = Point.ArgValidator(y);
                    
                    tab[j] = new Point(x, y);
                }
                points[i] = tab;
            }

            for (int i=0; i<z; i++)
            {
                Algorithm algorithm = new Algorithm(points[i]);
                Console.WriteLine(algorithm.ShortestPathAlgorithm());
            }
        }
    }
}

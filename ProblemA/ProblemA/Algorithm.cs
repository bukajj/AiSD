using System;
using System.Collections.Generic;
using System.Text;

/*
 * Główny algorytm, składa się z dwóch metod: CountPath i ShortestPathAlgorithm.
 * 
 *      CountPath oblicza sumę długości ścieżek od jednego punktu do wszystkich innych. 
 *      W argumentach metody podajemy punkt i minimalną sumę ścieżek, którą się udało uzyskać.
 *      Jeśli nowa suma ścieżek jest mniejsza od podanej, to jest ona zwracana, jeśli nie, to zwracana jest suma podana jako argument metody.
 *      
 *      ShortestPathAlgorithm korzysta z metody CountPath w celu oblicznia ścieżki dla każdego punktu. Zwracana jest najkrótsza.
 */

namespace ProblemA
{
    class Algorithm
    {
        Point[] points;
        public Algorithm(Point[] points)
        {
            this.points = points;
        }

        private int CountPath(Point point, int path)
        {
            int i = 0;
            int newPath = 0;
            while (newPath < path && i < points.Length)
            {
                newPath += Math.Abs(point.x - points[i].x) + Math.Abs(point.y - points[i].y);
                i++;
            }
            return (newPath < path) ? newPath : path;
        }

        public int ShortestPathAlgorithm()
        {
            int path = Int32.MaxValue;
            foreach (Point item in this.points)
            {
                path = CountPath(item, path);
            }
            return path;
        }


    }
}

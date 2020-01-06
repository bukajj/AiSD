using System;
using System.Collections.Generic;
using System.Text;

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

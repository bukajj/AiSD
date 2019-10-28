using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestPathApp
{
    class Algorithm
    {
        Point[] points;
        public Algorithm(Point[] points)
        {
            this.points = points;
        }
        
        private int CountPath(Point point)
        {
            int path = Int32.MaxValue;
            
            foreach(Point item in this.points)
            {
                int newPath = 0;
                while()
                newPath += Math.Abs(point.x - item.x) + Math.Abs(point.y - item.y);
            }
            return path;
        }

        public int ShortestPathAlgorithm()
        {
           
            
            foreach (Point item in this.points)
            
            return path;
        }


    }
}

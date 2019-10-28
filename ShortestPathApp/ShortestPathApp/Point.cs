using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestPathApp
{
    public class Point
    {
        internal int x { get; set; }
        internal int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

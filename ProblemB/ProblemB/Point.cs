using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemB
{
    internal class Point
    {
        internal double x { get; set; }
        internal double y { get; set; }

        internal Point(int x, int y)
        {
            this.x = (double)x;
            this.y = (double)y;
        }
    }
}

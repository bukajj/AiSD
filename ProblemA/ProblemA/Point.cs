using System;
using System.Collections.Generic;
using System.Text;

/*
 *Klasa Point służy do przechowywania punktów. Jej obiekty to po prostu punkty.
 */

namespace ProblemA
{
    internal class Point
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

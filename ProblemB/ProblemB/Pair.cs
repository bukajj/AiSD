using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemB
{
    internal class Pair // w tej klasie wyznaczam równianie prostej między punktami - func
    {
        internal Point Point1 { get; set; }
        internal Point Point2 { get; set; }
        internal string func = null;

        internal Pair(Point Point1, Point Point2)
        {
            this.Point1 = Point1;
            this.Point2 = Point2;
        }

        private double? countA()
        {
           if (Point1.x == Point2.x)
            {
                return null;
            }
           else if (Point1.y == Point2.y)
            {
                return 0;
            }
            else
            {
                return Math.Ceiling(100* (Point2.y - Point1.y) / (Point2.x - Point1.x))/100;
            }
        }
        private double? countB(double? a)
        {
            if (a == 0)
            {
                return Point1.y;
            }
            else if (a == null)
            {
                return null;
            }
            else
            {
                return Math.Ceiling(100 * (double)(Point1.y - a * Point1.x)) / 100;
            }
        }
        internal void countFunc()
        {
            double? a = countA();
            double? b = countB(a);

            if (a == null)
            {
                func = "x = " + Point1.x.ToString();
            }
            else if (a == 0)
            {
                func = "y = " + b.ToString();
            }
            else
            {
                func = "y = " + a.ToString() + "x + (" + b.ToString() + ")";
            }
        }
    }
}

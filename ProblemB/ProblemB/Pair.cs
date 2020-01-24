using System;
using System.Collections.Generic;
using System.Text;

/*
 * Klasa pary punktów. Wyliczamy w niej równanie prostej dwóch punktów.
 */

namespace ProblemB
{
    internal class Pair 
    {
        internal Point Point1 { get; set; }
        internal Point Point2 { get; set; }
        internal string func = null;

        internal Pair(Point Point1, Point Point2)
        {
            this.Point1 = Point1;
            this.Point2 = Point2;
        }

        /*
         * W tej metodzie wyznaczany jest współczynnik kierunkowy prostej. Jeśli prosta jest pionowa, to ta metoda zwraca null.
         */
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

        /*
         * W tej metodzie wyznaczany jest współczynnik b prostej w postaci kierunkowej y=ax+b. Jeśli a=null to b=null.
         * */
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

        /*
         * W tej metodzie zwracana jest cała funkcja w postaci łańcucha znaków. Wszystkie współczynniki są odpowiednio zaokrąglone.
         */
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

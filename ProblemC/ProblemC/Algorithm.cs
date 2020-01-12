using System;
using System.Collections.Generic;
using System.Text;

/*
 * Algorytm obliczjący najkrótszą drogę dla 1 skoczka.
 */

namespace ProblemC
{
    class Algorithm
    {
        private Point startPoint;
        private Point endPoint;

        public Algorithm(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }


        /*
         * W przypadku, gdy skoczek znajduje się w odległości Ymax<=3 i Xmax<=3 to mamy skończoną liczbę rozwiązań.
         */
        private int CloseJumps(int distX, int distY)
        {
            int dist2 = (int)(Math.Pow(distX, 2.0) + Math.Pow(distY, 2.0));

            if (dist2 == 8)
            {
                return 4;
            }
            else if (dist2 == 5)
            {
                return 1;
            }
            else if (dist2 == 4 || dist2 == 2 || dist2 == 10 || dist2 == 18)
            {
                return 2;
            }
            else if (dist2 == 1 || dist2 == 9 || dist2 == 13)
            {
                return 3;
            }
            else return 0;
        }

        /*
         * Krok, jeśli po głównej osi kroku przybliżamy się o 2, po drugiej albo zmniejszamy dystans o 1, albo jeśli dystans = 0 to oddalamy się o 1.
         */
        private Point Step(int distA, int distB)
        {
            int dist1 = distA - 2;
            int dist2 = distB;

            if (dist2 > 0)
            {
                dist2 -= 1;
            }
            else dist2 = 1;

            Point distAB = new Point(dist1, dist2);
            return distAB;
        }


        /*
         * Główny algorytm.
         * Obliczmamy dystans po x i po y.
         * Jeśli nie znajdujemy się w zakresie: Ymax<=3 i Xmax<=3, to wykonujemy kroki. Jeśli dystans po x>2 to po głównej osi x, jeśli nie to jeśli dystans po y>2 to po głównej osi y.
         * Gdy Ymax<=3 i Xmax<=3 to korzystamy z CloseJumps().
         * Zwracamy minimalną liczbę kroków.
         */
        public int JumpsAlgorithm()
        {
            int jumps = 0;

            int distX = Math.Abs(endPoint.x - startPoint.x);
            int distY = Math.Abs(endPoint.y - startPoint.y);

            while (distX > 3 || distY > 3)
            {
                jumps++;
                Point step;

                if (distX > 2)
                {
                    step = Step(distX, distY);
                    distX = step.x;
                    distY = step.y;
                }
                else
                {
                    step = Step(distY, distX);
                    distY = step.x;
                    distX = step.y;
                }
            }

            jumps += CloseJumps(distX, distY);

            return jumps;
        }
    }
}

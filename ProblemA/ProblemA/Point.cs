using System;
using System.Collections.Generic;
using System.Text;

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

        public static int ArgValidator(int a)
        {
            int arg = a;
            while (arg < 0 && arg > 100000)
            {
                Console.WriteLine("Podaj wartość 0<=arg<=100000");
                arg = int.Parse(Console.ReadLine());
            }
            return arg;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

/*
 * Główna klasa algorytmu, której zadaniem jest znalezienie maksymalnej ilości punktów współliniowych.
 */

namespace ProblemB
{
    internal class Algorithm
    {
        private Point[] Points;
        private Pair[] Pairs;
        private int[] Iterations;
        internal Algorithm(Point[] Points)
        {
            this.Points = Points;
        }

        /*
         * Wszystkie punkty łączone są w pary i obliczane są proste łączące punkty w parach.
         */
        private void setPairs()
        {
            if (Points.Length > 1)
            {
                Pairs = new Pair[Points.Length * (Points.Length - 1) / 2];
                int k = 0;
                for (int i = 0; i < Points.Length; i++)
                {
                    for (int j = i + 1; j < Points.Length; j++)
                    {
                        Pairs[k] = new Pair(Points[i], Points[j]);
                        Pairs[k].countFunc();
                        k++;
                    }
                }
            }
        }

        /*
         * Metoda obliczająca liczbę punktów współliniowych dla danej funkcji. 
         * Przechodzi po liście do końca i zlicza, jeśli było wystąpienie danej funkcji wcześniej, to zostało to już zliczone, więc nie ma sensu liczyć ponownie.
         * Iteracja po liście Par wykonywana jest tylko wtedy, gdy jest więcej niż 1 para.
         */
        private void iterationsCount()
        {
            if (Points.Length > 1)
            {
                if (Pairs.Length > 1)
                {
                    Iterations = new int[Pairs.Length];
                    for (int i = 0; i < Pairs.Length; i++)
                    {
                        int counter = 2;
                        for (int j = i + 1; j < Pairs.Length; j++)
                        {
                            if (Pairs[i].func.Equals(Pairs[j].func) && Pairs[i].Point1.Equals(Pairs[j].Point1)) counter++;
                        }
                        Iterations[i] = counter;
                    }
                }
            }
        }

        /*
         * Sprawdzenie maksymalnej ilości punktów współliniowych poprzez użycie metody iterationsCount(), metoda jest używana, tylko, gdy mamy więcej niż 2 punkty.
         */
        internal int maxValue()
        {       
            if (Points.Length == 0)
            {
                return 0;
            }
            else if (Points.Length == 1)
            {
                return 1;
            }
            else if (Points.Length == 2)
            {
                return 2;
            }
            else
            {
                setPairs();
                iterationsCount();
                int max = Iterations[0];
                for (int i=1; i<Iterations.Length; i++)
                {
                    if (Iterations[i] > max)
                    {
                        max = Iterations[i];
                    }
                }
                return max;
            }
        }
    }
}

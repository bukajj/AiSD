using System;
using System.Collections.Generic;
using System.Text;

/*
 * Klasa obliczająca najlepsze ustawienie skoczków względem punktów końcowych. Obliczana jest w niej minimalna ilość ruchów potrzebna do rozwiązania problemu.
 */

namespace ProblemC
{
    internal class MultipleAlgotithms
    {
        private Point[] positions { get; set; }
        private Point[] destinations { get; set; }
        internal MultipleAlgotithms(Point[] positions, Point[] destinations)
        {
            this.positions = positions;
            this.destinations = destinations;
        }

        /*
         * Główny algorytm.
         */
        internal int algorithm()
        {
            int value = Int32.MaxValue;
            int[,] values = new int[positions.Length,positions.Length];

            /*
             * Dla każdego skoczka obliczamy jego odległość od każdego punktu końcowego.
             */
            for(int i=0; i<positions.Length; i++)
            {
                for(int j=0; j< positions.Length; j++)
                {
                    Algorithm algorithm = new Algorithm(positions[i], destinations[j]);
                    values[i, j] = algorithm.JumpsAlgorithm();
                }
            }

            /*
             * Tablica indeksów punktów
             */
            int[] TabIndexes = new int[positions.Length];
            for (int i = 0; i < positions.Length; i++)
            {
                TabIndexes[i] = i;
            }

            /*
             * minimalna następna ilość skoków dla następnych skoczków wybierana z punktów, do których jeszcze można dojść
             */
            int[] minNext = new int[TabIndexes.Length];
            for (int i=0; i<TabIndexes.Length; i++)
            {
                minNext[i] = Int32.MaxValue;
                for (int j=0; j<TabIndexes.Length; j++)
                {
                    if (values[i, j] < minNext[i])
                    {
                        minNext[i] = values[i, j];
                    }
                }
            }
            
            /*
             * Obliczanie minimalnej sumy skoków. Metoda rekursywna.
             * Dla każdego punktu końcowego i skoczka dodajemy następne wartości minimalne, przekazując indeks, wartość obecną, tablicę indeksów - które są użyte a które nie, oraz tablicę z danymi.
             * Usprawnienia do funkcji:
             * - jeśli suma wartości aktualnej i sumy minimalnych przyszłych wartości jest większa od minimalnej aktualnej wartości to kończymy liczyć dla danego przypadku
             * Jeśli wartość końcowa jest mniejsza od minimalnej to minimum jest podmieniane.
             */
            void counter(int[,] data, int[] indexes, int acc, int index)
            {
                int helper = acc;
                for (int i=0; i<indexes.Length; i++)
                {
                    if (indexes[i]! >= 0)
                    {
                        helper += minNext[i];
                    }
                }
                if (helper <= value)
                {
                    if (index == indexes.Length)
                    {
                        if (acc < value) value = acc;
                    }
                    else
                    {
                        for (int j = 0; j < indexes.Length; j++)
                        {
                            if (indexes[j] >= 0)
                            {
                                int[] newIndexes = new int[indexes.Length];
                                for (int k = 0; k < indexes.Length; k++)
                                {
                                    newIndexes[k] = indexes[k];
                                }
                                newIndexes[j] = -1;
                                int newAcc = 0;
                                newAcc += acc + data[index, j];
                                int newIndex = 1;
                                newIndex += index;
                                counter(data, newIndexes, newAcc, newIndex);
                            }
                        }
                    }
                }    
            }

            /* 
             * Wywołanie counter() dla startowych wartości i zwrócenie minimum.
             */
            counter(values, TabIndexes, 0, 0);
            return value;
        }
    }
}

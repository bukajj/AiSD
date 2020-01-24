using System;

namespace Macierz_Odwotna
{
    class Program
    {
        public static void PrintMatrix(double[,] matrix)
        {
            Console.WriteLine();
            for (int i=0; i<matrix.GetLength(0);i++)
            {
                for (int j=0; j<matrix.GetLength(1);j++)
                {
                    Console.Write("\t" + matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void DivRow (double[,] outputMatrix, int row, double divValue)
        {
            for (int i = 0; i < outputMatrix.GetLength(0) * 2; i++)
            {
                outputMatrix[row, i] /= divValue;
            }
        }
        public static void SubDivRow(double[,] outputMatrix, int row1, double divValue, int row2)
        {
            for (int i = 0; i < outputMatrix.GetLength(0) * 2; i++)
            {
                outputMatrix[row1, i] /= divValue;
                outputMatrix[row1, i] -= outputMatrix[row2, i];
            }
        }
        public static void InverseMatrix(double[,] matrix)
        {
            //deklaracja macierzy wyjsciowej o wymiarach [n,2n]
            double[,] outputMatrix = new double[matrix.GetLength(0), 2 * matrix.GetLength(0)];

            //wypisujemy macierz wejsciową
            Console.WriteLine("Macierz wejsciowa wartośći:");
            PrintMatrix(matrix);

            //kopiowanie macierzy wejsciowej
            for (int i=0;i<matrix.GetLength(0);i++)
            {
                for (int j=0;j<matrix.GetLength(0);j++)
                {
                    outputMatrix[i, j] = matrix[i, j];

                    //dodajemy macierz jednostkową po prawej stronie
                    if (i == j)
                    {
                        outputMatrix[i, j + matrix.GetLength(0)] = 1;
                    }
                    else
                    {
                        outputMatrix[i, j + matrix.GetLength(0)] = 0;
                    }
                }
            }

            //tworzymy jedynki na głównej przekątnej i zerujemy "dół" macierzy
            for (int i=0;i<matrix.GetLength(0);i++)
            {
                DivRow(outputMatrix, i, outputMatrix[i, i]);
                for (int j=i+1;j<matrix.GetLength(0);j++)
                {
                    SubDivRow(outputMatrix, j, outputMatrix[j, i], i);
                }
                //podgląd macierzy po każdej zmianie
                PrintMatrix(outputMatrix);
            }

            //zerujemy "górę" macierzy
            for (int i=matrix.GetLength(0)-1;i>-1;i--)
            {
                DivRow(outputMatrix, i, outputMatrix[i, i]);
                for (int j=i-1;j>-1;j--)
                {
                    SubDivRow(outputMatrix, j, outputMatrix[j, i], i);
                }
                //podgląd macierzy po każdej zmianie
                //PrintMatrix(outputMatrix);
            }

            //wypisujemy macierz odwróconą
            Console.WriteLine("Macierz odwrócona podanej macierzy to:");
            PrintMatrix(outputMatrix);

        }
        

        static void Main(string[] args)
        {
            //przykładowa macierz do odwrócenia
            double[,] sampleMatrix =
            {
                {1, 1, 2, 3 },
                {1, 2, 3, 1 },
                {2, 6, 5, 2 },
                {5, 4, 4, 2 }
            };
            InverseMatrix(sampleMatrix);
        }
    }
}
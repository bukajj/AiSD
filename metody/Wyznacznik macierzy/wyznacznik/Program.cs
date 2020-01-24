using System;

namespace Liczenie_Wyznacznika_Macierzy
{
    class Program
    {
        //zmniejszanie macierzy
        static int[,] GetSubMatrix(int[,] matrix, int n, int size)
        {
            int[,] subMatrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j < n)
                    {
                        subMatrix[i, j] = matrix[i + 1, j];
                    }
                    else
                    {
                        subMatrix[i, j] = matrix[i + 1, j + 1];
                    }
                }
            }
            return subMatrix;
        }

        // liczenie wyznaczika
        static int DeterminantOfMatrix(int[,] matrix)
        {
            int result = 0;
            int sign = 1;
            int matrixSize = matrix.GetLength(0);

            //dla wielkości macierzy mniejszej lub równej 3 obliczmy wyznacznik
            if (matrixSize <= 3)
            {
                if (matrixSize == 3)
                {
                    result = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                                 matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                                 matrix[0, 2] * matrix[1, 0] * matrix[2, 1] -
                                 matrix[2, 0] * matrix[1, 1] * matrix[0, 2] -
                                 matrix[2, 1] * matrix[1, 2] * matrix[0, 0] -
                                 matrix[2, 2] * matrix[1, 0] * matrix[0, 1];
                }
                else if (matrixSize == 2)
                {

                    result = matrix[0, 0] * matrix[1, 1] -
                             matrix[0, 1] * matrix[1, 0];
                }
                else if (matrixSize == 1)
                {
                    result = matrix[0, 0];
                }
                return result;
            }

            //dla większych zmniejszamy macierz do momentu otrzymania macierzy 3x3
            for (int i = 0; i < matrixSize; i++)
            {
                int[,] subMatrix;
                subMatrix = GetSubMatrix(matrix, i, matrixSize - 1);
                result += sign * matrix[0, i] * DeterminantOfMatrix(subMatrix);
                sign = -sign;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //generowanie macierzy
            int size = 10;
            int[,] sampleMatrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sampleMatrix[i, j] = rnd.Next(0, 10);
                    Console.Write(sampleMatrix[i, j] + " ");
                }
                Console.WriteLine("\t");
            }
            //liczenie wyznacznika macierzy
            Console.WriteLine(DeterminantOfMatrix(sampleMatrix));

        }
    }
}
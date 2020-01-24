using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metody3
{
    class Program
    {
        public delegate double DelegatFunkcji(double x);

        public static double Function1(double x)
        {
            return Math.Pow(x, 0.5) + 2;
        }
        public static double Function2(double x)
        {
            return Math.Pow(x, 3) + 3;
        }

        //-- Metoda Prostokatow ----------------------------------------------------------------------------------------
        public static double MetodaProstokatow(double start, double end, int ilosc, DelegatFunkcji funkcja)
        {
            double calka = 0;
            double h = (end - start) / ilosc;
            for (int i = 1; i <= ilosc; i++)
            {
                calka += funkcja(start + i * h);
            }
            calka *= h;
            return calka;

        }

        //-- Metoda Trapezów -------------------------------------------------------------------------------------------
        public static double MetodaTrapezow(double start, double end, int ilosc, DelegatFunkcji funkcja)
        {
            double A = 0;
            double B = 0;
            double calka = 0;
            double h = (end - start) / ilosc;

            for (int i = 0; i <= ilosc - 1; i++)
            {
                A = funkcja(start + i * h);
                B = funkcja(start + (i + 1) * h);
                calka += (((A + B) *h)/ 2);
        }
            return calka;
        }

        //-- Metoda Simpsona -------------------------------------------------------------------------------------------
        public static double MetodaSimpsona(double start, double end, int ilosc, DelegatFunkcji funkcja)
        {
            double calka = 0;
            double sumaSrodek = 0;
            double punkPodzialowy;
            double h = (end - start) / ilosc;

            for (int i = 1; i <= ilosc; i++)
            {
                punkPodzialowy = start + i * h;
                sumaSrodek += funkcja(punkPodzialowy - h / 2);
                if (i < ilosc)
                    calka += funkcja(punkPodzialowy);
            }
            calka = h / 6 * (funkcja(start) + funkcja(end) + 2 * calka + 4 * sumaSrodek);
            return calka;
        }

        //-- Metoda Własna ---------------------------------------------------------------------------------------------
        public static double MetodaWlasna(double start, double end, double ilosc, double blad, DelegatFunkcji funkcja)
        {
            double A;
            double B;
            double middle;
            double calka = 0;
            double h_poczatkowe = ((end - start) / ilosc);
            double h = h_poczatkowe;

            do
            {
                A = funkcja(start);
                B = funkcja(start + h);
                middle = start + (h / 2);

                while (Math.Abs((funkcja(middle) - ((B + A)) / 2)) > blad)
                {
                    h = h / 2;
                    B = funkcja(start + h);
                    middle = start + (h / 2);
                }

                calka += (((A + B) * h) / 2);
                start = start + h;
                h = h_poczatkowe;
            } while (start <= end);

            calka = calka - (((funkcja(start) + funkcja(end)) * (start - end)) / 2);
            return calka;
        }

        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
        double start;
        double end;
        double blad;
        int ilosc;
        

        Console.Write("Poczatek zakresu: ");
        start = double.Parse(Console.ReadLine());
        Console.Write("Koniec zakresu: ");
        end = double.Parse(Console.ReadLine());
        Console.Write("Ilosc przedzialow: ");
        ilosc = int.Parse(Console.ReadLine());
        Console.Write("Maksymalny błąd (metoda własna): ");
        blad = double.Parse(Console.ReadLine());

        Console.WriteLine("________________________________________________");
        Console.WriteLine();

        Console.WriteLine("Funkcja: x^(1/2) + 2:");
        Console.WriteLine("Metoda prostokatow od strony prawej : " + MetodaProstokatow(start, end, ilosc, Function1));
        Console.WriteLine("Metoda trapezow : " + MetodaTrapezow(start, end, ilosc, Function1));
        Console.WriteLine("Metoda simpsona : " + MetodaSimpsona(start, end, ilosc, Function1));
        Console.WriteLine("Metoda własna : " + MetodaWlasna(start, end, ilosc, blad, Function1));
        Console.WriteLine();

        Console.WriteLine("Funkcja: x^3 + 3:");
        Console.WriteLine("Metoda prostokatow od strony prawej : " + MetodaProstokatow(start, end, ilosc, Function2));
        Console.WriteLine("Metoda trapezow2 : " + MetodaTrapezow(start, end, ilosc, Function2));
        Console.WriteLine("Metoda simpsona : " + MetodaSimpsona(start, end, ilosc, Function2));
        Console.WriteLine("Metoda własna : " + MetodaWlasna(start, end, ilosc, blad, Function2));
        Console.WriteLine();

        Console.ReadLine();
        }
    }
}
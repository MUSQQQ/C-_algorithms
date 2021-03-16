using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poczwornykopiec
{
    
    
    class Program
    {
        public static void Napraw(int[] kopiec, int indeks)
        {
            int n = kopiec.Length;
            int d1 = 4 * indeks + 1;    //indeksy poszczegolnych dzieci
            int d2 = 4 * indeks + 2;
            int d3 = 4 * indeks + 3;
            int d4 = 4 * indeks + 4;

            if(d1<n)    //jezeli jest chociaz jedno dziecko
            {
                int maksymalny = indeks;
                if (kopiec[d1] < kopiec[maksymalny])
                    maksymalny = d1;    //jesli dziecko d1 ma wartosc mniejsza to zamiana
                
                if (d2 < n && kopiec[d2] < kopiec[maksymalny])
                    maksymalny = d2;
                
                if (d3 < n && kopiec[d3] < kopiec[maksymalny])
                    maksymalny = d3;
                
                if (d4 < n && kopiec[d4] < kopiec[maksymalny])
                    maksymalny = d4;
                if(maksymalny!=indeks)
                {
                    int tmp = kopiec[indeks];
                    kopiec[indeks] = kopiec[maksymalny];
                    kopiec[maksymalny] = tmp;
                    Napraw(kopiec, maksymalny);
                }
                
            }
        }

        public static void Buduj(int [] kopiec)
        {
            int rozmiar = kopiec.Length;
            for (int i = rozmiar / 4 - 1; i >= 0; i--)
                Napraw(kopiec, i);
        }
        static void Main(string[] args)
        {
            int[] kopiec = new int[] { 5, 3, 15, 2, 60, 52, 41, 7, 9, 17, 1, 31, 22,6 };
            Console.WriteLine("to poczatkowa tablica:");
            for(int i=0;i<kopiec.Length;i++)
            {
                Console.Write(kopiec[i] + "   ");
            }
            Console.WriteLine();

            Buduj(kopiec);
            
            Console.WriteLine("to zbudowany kopiec:");
            for (int i = 0; i < kopiec.Length; i++)
            {
                Console.Write(kopiec[i] + "   ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

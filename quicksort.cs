using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static int Podzial(int[] T, int l, int p)
        {
            int i, j, klucz, tmp, index;
            
            index = p; // element prawy
                       
            klucz = T[index];
            i = l;  // na lewo od indeksu i elementy <= klucz
            for (j = l; j < p; j++)
            {
                if (T[j] <= klucz)
                { tmp = T[i]; T[i] = T[j]; T[j] = tmp; i++; }
            }
            // element centralny na swoje miejsce
            tmp = T[i];
            T[i] = T[p];
            T[p] = tmp;
            return i;
        }
        static void QuickSort(int[] T, int l, int p)
        {
            
            if (l >= p) return;
            int i = Podzial(T, l, p);
            QuickSort(T, l, i - 1);
            QuickSort(T, i + 1, p);
        }
        static void Main(string[] args)
        {
            int[] tab1 = { 9, 1, -1, 5, 7, 3, 6 };
            

            QuickSort(tab1, 0, tab1.Length - 1);
            Console.ReadKey();
        }
    }
}

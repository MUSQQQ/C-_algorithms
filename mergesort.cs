using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Scalaj(int[] T, int p, int mid, int k, int[] T2)
        
        
        {
            int p1 = p, k1 = mid; // podtablica 1
            int p2 = mid + 1, k2 = k; // podtablica 2
                                      
            int i = p1;
            while ((p1 <= k1) && (p2 <= k2))
            {
                if (T[p1] < T[p2])
                { T2[i] = T[p1]; p1++; }
                else
                { T2[i] = T[p2]; p2++; }
                i++;
            }
            while (p1 <= k1)
            {
                T2[i] = T[p1]; p1++; i++;
            }
            while (p2 <= k2)
            {
                T2[i] = T[p2]; p2++; i++;
            }
            
            for (i = p; i <= k; i++) T[i] = T2[i];
        }
        
        static void MergeSort(int[] T, int p, int k, int[] T2)
        {
            
            if (p < k)
            {
                int mid = (p + k) / 2; 
                MergeSort(T, p, mid, T2);
                MergeSort(T, mid + 1, k, T2);
                Scalaj(T, p, mid, k, T2); // scalanie
            }
        }
        static void Main(string[] args)
        {
            int[] tab1 = { 9, 1, -1, 5, 7, 3};
            int[] tab2 = { 0, 0, 0, 0, 0, 0};

            MergeSort(tab1, 0, tab1.Length - 1, tab2);
            Console.ReadKey();
        }
    }
}

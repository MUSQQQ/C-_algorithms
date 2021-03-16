using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    
    class Program
    {
        

        static string  Podciag2(string a, string b)
        {
            string wynik = "";
            int[,] lista = new int[a.Length, b.Length];
            for (int p = 0; p < a.Length; p++)
                lista[p, 0] = 0;
            for (int p = 0; p < b.Length; p++)
                lista[0, p] = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            for (int p = 0; p < a.Length-1; p++)
                for (int k = 0; k < b.Length-1; k++)
                    if (a[p] == b[k])
                        lista[p+1, k+1] = lista[p , k ] + 1;
                    else
                    {
                        if (lista[p + 1, k] > lista[p, k + 1])
                            lista[p+1, k+1] = lista[p + 1, k];
                        else
                            lista[p+1, k+1] = lista[p, k + 1];
                    }
            i--;
            j--;
            if (a[i + 1] == b[j + 1])
                wynik += a[i + 1];
            while (i>=0&&j>=0)
            {
                if(a[i]==b[j])
                {
                    wynik = a[i] + wynik;
                    i--;
                    j--;
                }
                else
                {
                    if (lista[i+1 , j] > lista[i, j +1])
                        j--;
                    else
                        i--;
                }
            }
            return wynik;
        }
        static void Main(string[] args)
        {
            string a = "Paratrechina", b = "Pseudomyrmex";
            Console.WriteLine(a+"   "+b);
            Console.WriteLine(Podciag2(a,b));
            Console.ReadKey();
        }
    }
}

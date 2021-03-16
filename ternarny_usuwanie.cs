using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternarny
{
    
    class Program
    {
        public static bool CzyMaks(int[] kopiec, int ilosc)
        {
            
            
            for(int i=0;i<ilosc;i++)
            {
                if (3 * i + 1 < ilosc)//teoretycznie nie musze sprawdzac bo tablica wypelniona zerami do konca ale moge zmienic wartosci w kopcu na ujemne
                    if (kopiec[i] < kopiec[3*i + 1])
                        return false;
                if (3 * i + 2 < ilosc)
                    if (kopiec[i] < kopiec[3 * i + 2])
                        return false;
                if (3 * i + 3 < ilosc)
                    if (kopiec[i] < kopiec[3 * i + 3])
                        return false;
            }

            return true;

        }
        public static void UsunMaks(int[] kopiec, ref int ilosc)
        {
            kopiec[0] = kopiec[ilosc - 1];//pozbycie sie korzenia, nadpisanie korzenia wartoscia ostatniego elementu
            ilosc--;
            int i = 0;
            int tmp;
            int indeksPom = 0;  //zapisywany indeks najwiekszego dizecka wiekszego od rodzica
            int p = 1;  //wartosc uzywana do przechodzenia przez dzieci danego wezla
            bool czyZam = true;
            while(i<ilosc&&czyZam){ 
                p = 1;
                indeksPom = i;
                czyZam = false;
                while(3*i+p<ilosc&&p<=3)
                {
                    if(kopiec[i]<kopiec[3*i+p])
                    {
                        if (kopiec[3 * i + p] > kopiec[indeksPom])//jesli znajdzie dziecko o wartosci wiekszej niz rodzic to sprawdza czy dziecko jest wieksze niz wczesniejsze uzywajac indeksu pomocniczego
                        {
                            indeksPom = 3 * i + p;
                            czyZam = true;  //jesli dojdzei do zamiany to czyzam=true i petla while wykona sie kolejny raz
                        }
                    }
                    p++;
                }
                tmp = kopiec[i];        //zamiana
                kopiec[i] = kopiec[indeksPom];
                kopiec[indeksPom] = tmp;
                i = indeksPom;
                
            }

        }
        static void Main(string[] args)
        {
            int[] kopiec = new int[30];
            int ilosc = 0;
            kopiec[0] = 20;
            kopiec[1] = 17;
            kopiec[2] = 10;
            kopiec[3] = 15;
            kopiec[4] = 9;
            kopiec[5] = 4;
            kopiec[6] = 12;
            kopiec[7] = 8;
            kopiec[8] = 1;
            ilosc = 9;
            
            for (int i = 0; i < ilosc; i++)
                Console.Write(kopiec[i] + " ");
            Console.WriteLine();
            Console.WriteLine("czy maksymalny ternarny:");
            Console.WriteLine(CzyMaks(kopiec,ilosc));
            UsunMaks(kopiec, ref ilosc);
            Console.WriteLine("kopiec po ususnieciu maks wartosci:");
            for (int i = 0; i < ilosc; i++)
                Console.Write(kopiec[i] + " ");
            Console.WriteLine();
            Console.WriteLine("czy maksymalny ternarny:");
            Console.WriteLine(CzyMaks(kopiec, ilosc));
            Console.ReadKey();
        }
    }
}

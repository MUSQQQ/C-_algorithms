using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preorder
{
    public class Wezel
    {
        public int klucz;
        public Wezel lewy;
        public Wezel prawy;
        public Wezel(int a)
        {
            klucz = a;
        }

        public void Dodaj(Wezel w)
        {
            if (w.klucz > klucz)
                if (prawy == null)
                    prawy = w;
                else
                    prawy.Dodaj(w);
            else
                if (lewy == null)
                lewy = w;
                else
                lewy.Dodaj(w);
        }
    }

    class Program
    {
        
        public static Wezel Odtworz(int[] tab)
        {


            for (int k = 0; k < tab.Length; k++)        //dla kazdego poddrzewa sprawdzam czy spelnione sa warunki abyu tablica reprezentowala wypisywanie preorder (jesli wartosci mniejsze i wieksze od "korzenia" sa ze soba wymieszane to wtedy to nie moze byc preorder
            {
                int indeks = k;     //indeks potencjalnego ostatniego elementu w lewym poddrzewie korzenia
                for (int i = k; i < tab.Length; i++)
                {
                    if (tab[i] < tab[k])
                        indeks = i;

                }
                for (int i = k; i < tab.Length; i++)
                {
                    if (tab[i] > tab[k] && i < indeks)
                        return null;

                }

                for (int i = tab.Length - 1; i >= k; i--)
                {
                    if (tab[i] > tab[k])
                        indeks = i;


                }
                for (int i = tab.Length - 1; i >= k; i--)
                {
                    if (tab[i] < tab[k] && i > indeks)
                        return null;

                }
            }

            Wezel korzen = new Wezel(tab[0]);
            for (int i = 1; i < tab.Length; i++)
                korzen.Dodaj(new Wezel(tab[i]));

            return korzen;

        }
        // pre-order
        static void WypisujPre(Wezel węzeł)
        {
            if (węzeł == null) return;
            Console.Write(węzeł.klucz + " ");
            WypisujPre((Wezel)węzeł.lewy);
            WypisujPre((Wezel)węzeł.prawy);
        }

        // post-order
        static void WypisujPost(Wezel węzeł)
        {
            if (węzeł == null) return;
            WypisujPost((Wezel)węzeł.lewy);
            WypisujPost((Wezel)węzeł.prawy);
            Console.Write(węzeł.klucz + " ");
        }

        
        static void Main(string[] args)
        {
            int[] tab = new int[] { 6, 3, 1, 2, 4, 5, 7 };

            Wezel w = Odtworz(tab);

            Console.WriteLine("preorder:");
            WypisujPre(w);
            Console.WriteLine();
            Console.WriteLine("postorder:");
            WypisujPost(w);
            Console.ReadKey();

        }
    }
}

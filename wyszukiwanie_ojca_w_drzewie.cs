using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wyszukiwanieojca
{
    
    class Węzeł
    {
        public String wartość;
        public Węzeł lewy;
        public Węzeł prawy;
    }

    
    class Drzewo
    {
        public Węzeł korzeń;
    }

    class Program
    {
        static Węzeł UtwórzWęzeł(String wartość)
        {
            Węzeł węzeł = new Węzeł();
            węzeł.wartość = wartość;
            return węzeł;
        }

        static void InicjujWęzeł(Węzeł węzeł, String wartość)
        {
            węzeł.wartość = wartość;
        }

        static void DodajLewy(Węzeł węzeł, Węzeł dziecko)
        {
            węzeł.lewy = dziecko;
        }
        static void DodajPrawy(Węzeł węzeł, Węzeł dziecko)
        {
            węzeł.prawy = dziecko;
        }

        
        static void WypisujPre(Węzeł węzeł)
        {
            if (węzeł == null) return;
            Console.Write(węzeł.wartość + " ");
            WypisujPre((Węzeł)węzeł.lewy);
            WypisujPre((Węzeł)węzeł.prawy);
        }

        
        // Zaczynam sprawdzanie od korzenia drzewa, a referencje do poszukiwanego węzła przechowuje w drugiej zmiennej.
        static void SzukajRodzica(Węzeł nibyKorzeń, Węzeł węzeł)
        {
            if (nibyKorzeń == null) return; //przypadek jeśli węzeł nie został dodany do drezwa, bądź jest korzeniem
            if (nibyKorzeń.prawy == węzeł)
                Console.WriteLine("Ojcem węzła " + węzeł.wartość + " jest " + nibyKorzeń.wartość);
            if (nibyKorzeń.lewy == węzeł)
                Console.WriteLine("Ojcem węzła " + węzeł.wartość + " jest " + nibyKorzeń.wartość);
            SzukajRodzica(nibyKorzeń.prawy, węzeł);
            SzukajRodzica(nibyKorzeń.lewy, węzeł);
            
        }
        static void Main()
        {
            Drzewo drzewo = new Drzewo();

            drzewo.korzeń = UtwórzWęzeł("1");
            Węzeł w2 = UtwórzWęzeł("2");
            Węzeł w3 = UtwórzWęzeł("3");
            Węzeł w4 = UtwórzWęzeł("4");
            Węzeł w5 = UtwórzWęzeł("5");
            Węzeł w6 = UtwórzWęzeł("6");
            Węzeł w7 = UtwórzWęzeł("7");
            Węzeł w8 = UtwórzWęzeł("8");
            Węzeł w9 = UtwórzWęzeł("9");

            DodajLewy(w2, w4);
            DodajPrawy(w2, w5);
            DodajLewy(w3, w6);
            DodajPrawy(w3, w7);

            DodajLewy(w7, w8);
            DodajPrawy(w7, w9);

            DodajLewy(drzewo.korzeń, w2);
            DodajPrawy(drzewo.korzeń, w3);

            WypisujPre(drzewo.korzeń);
            Console.WriteLine();
            

            Console.WriteLine();

            SzukajRodzica(drzewo.korzeń, w2);
            SzukajRodzica(drzewo.korzeń, w8);
            SzukajRodzica(drzewo.korzeń, drzewo.korzeń);
            Console.ReadKey();
        }
    }

}

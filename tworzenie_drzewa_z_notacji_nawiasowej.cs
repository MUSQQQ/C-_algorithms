using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace zad2
{

    public class Węzeł
    {
        public String wartość;
        public ArrayList dzieci;
    }


    public class Drzewo
    {
        public Węzeł korzeń;
    }

    class Program
    {
        static Węzeł UtwórzWęzeł(String wartość)
        {
            Węzeł węzeł = new Węzeł();
            węzeł.wartość = wartość;
            węzeł.dzieci = new ArrayList();
            return węzeł;
        }

        static void InicjujWęzeł(Węzeł węzeł, String wartość)
        {
            węzeł.wartość = wartość;
            węzeł.dzieci = new ArrayList();
        }

        static void DodajWęzeł(Węzeł węzeł, Węzeł dziecko)
        {
            węzeł.dzieci.Add(dziecko);
        }


        
        
        static void WypisujPre(Węzeł węzeł)
        {
            Console.Write(" " + węzeł.wartość);
            if (węzeł.dzieci.Count > 0)
            {
                for (int i = 0; i < węzeł.dzieci.Count; i++)
                {
                    WypisujPre((Węzeł)węzeł.dzieci[i]);
                }
            }
        }

        static void WypisujPost(Węzeł węzeł)
        {
            if (węzeł.dzieci.Count > 0)
            {
                for (int i = 0; i < węzeł.dzieci.Count; i++)
                {
                    WypisujPost((Węzeł)węzeł.dzieci[i]);
                }
            }
            Console.Write(" " + węzeł.wartość);
        }
        
        
        


        static void TworzenieDrzewa(Drzewo drzewo, string nawiasowa)
        {
            int licznikLewy = 0; //licza nawiasy
            int licznikPrawy = 0;
            int dlugosc = 0;
            nawiasowa = nawiasowa.Substring(1, nawiasowa.Length - 2);
            drzewo.korzeń = UtwórzWęzeł(Convert.ToString(nawiasowa[0]));
            for (int i = 1; i < nawiasowa.Length; i++)
            {
                if (nawiasowa[i] != '(' && nawiasowa[i] != ')')
                    dlugosc++;
            }
            string[] litery = new string[dlugosc];
            int[] wartosci = new int[dlugosc];
            int licznik2 = 0;
            for (int i = 1; i < nawiasowa.Length; i++) //tutaj uzupelniam obie tablice literami i wartosciami
            {
                if (nawiasowa[i] == '(')
                    licznikLewy++;
                else if (nawiasowa[i] == ')')
                    licznikPrawy++;
                else
                {
                    litery[licznik2] = Convert.ToString(nawiasowa[i]);
                    wartosci[licznik2] = licznikLewy - licznikPrawy;
                    licznik2++;
                }
            }
            
            Węzeł[] wezly = new Węzeł[dlugosc]; //inicjuje tablice wezlow
            for (int i = 0; i < dlugosc; i++)
                wezly[i] = UtwórzWęzeł(litery[i]); //uzupelniam ją
            for (int i = 0; i < dlugosc; i++) // uzalezniam wezly od siebie
            {
                int k = i + 1;
                while (k < dlugosc && wartosci[k] > wartosci[i]) //sprawdzam dopoki nie skonczy sie tablica lub natrafie na identyczna wartosc
                {
                    if (wartosci[k] == wartosci[i] + 1) //jesli wartosc odpowiada wartosci dziecka danego wezla
                        DodajWęzeł(wezly[i], wezly[k]);

                    k++;

                }
            }
            for (int i = 0; i < dlugosc; i++) //lacze wczesniejsze wezly z korzeniem
            {
                if (wartosci[i] == 1)
                    DodajWęzeł(drzewo.korzeń, wezly[i]);
            }
        }

        static void Main()         
        {
            Drzewo drzewo = new Drzewo();
            string nawias = "(8(6(3(9)))(2(4(1))(5)(0)(7)))";
            TworzenieDrzewa(drzewo, nawias);
            
            Console.WriteLine(nawias);
            Console.WriteLine();

            Console.WriteLine("Preorder:");
            Console.WriteLine();
            WypisujPre(drzewo.korzeń);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Postorder:");
            Console.WriteLine();
            WypisujPost(drzewo.korzeń);


            Console.ReadKey();
        }
    }
}

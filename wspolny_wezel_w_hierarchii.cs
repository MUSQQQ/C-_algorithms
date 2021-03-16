using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    public class Wezel      //implementacja klasy wezel
    {
        public int klucz;
        public Wezel lewy;
        public Wezel prawy;
        public Wezel(int a)
        {
            klucz = a;
        }
        public void Dodaj(Wezel w)      //dodawanie nowego wezla
        {
            if (w.klucz > klucz)
            {
                if (prawy == null)
                    prawy = w;
                else
                    prawy.Dodaj(w);

            }
            else
                if (lewy == null)
                lewy = w;
            else
                lewy.Dodaj(w);
        }
    }
    public class Drzewo
    {
        public Wezel korzen;
        public Drzewo(Wezel w)
        {
            korzen = w;
        }

        public Wezel Znajdz(Wezel w1, Wezel w2)     //glowna funkcja
        {
            List<Wezel> lista1 = new List<Wezel>();     // tworze listy "drog" prowadzacych od korzenia do kazdego z szukanych wezlow
            List<Wezel> lista2 = new List<Wezel>();
            Wezel tmp1 = korzen;
            Wezel tmp2 = korzen;

            while(tmp1!=null)       //oddzielne while dla kazdego z wezlow
            {
                
                lista1.Add(tmp1);       //kazdy odwiedzony wierzcholek dodwanay do odpowiedniej listy
                if (w1.klucz<tmp1.klucz)        //standardowe porownanie ktore wynzacza czy koncze petle czy przechodze do lewego/prawego dziecka
                {
                    if (tmp1.lewy != null)
                        tmp1 = tmp1.lewy;
                    else
                        tmp1 = null;
                }
                else
                    if (tmp1.prawy != null)
                    tmp1 = tmp1.prawy;
                else
                    tmp1 = null;
                
            }
            while (tmp2 != null)
            {
                
                lista2.Add(tmp2);
                if (w2.klucz<tmp2.klucz)
                {
                    if (tmp2.lewy != null)
                        tmp2 = tmp2.lewy;
                    else
                        tmp2 = null;
                }
                else
                    if (tmp2.prawy != null)
                    tmp2 = tmp2.prawy;
                else
                    tmp2 = null;
                
            }

            
            if (lista1[lista1.Count -1].klucz != w1.klucz || lista2[lista2.Count -1].klucz != w2.klucz)       //jezeli ktoras z list nie konczy sie szukanym wezlem to nie ma go w drzewie wiec wynik null
                return null;
            for(int i=lista1.Count-1;i>=0;i--)      //przechodze obie listy od konca i gdy natradfie na pierwszy taki sam wezel to jest on wynikiem
            {
                
                for (int k = lista2.Count-1; k >= 0; k--)
                    if (lista1[i] == lista2[k])
                        return lista2[i];
            }
            return null;
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            Wezel korzen = new Wezel(10);

            Drzewo drzewo = new Drzewo(korzen);
            korzen.Dodaj(new Wezel(5));
            korzen.Dodaj(new Wezel(7));
            korzen.Dodaj(new Wezel(12));
            korzen.Dodaj(new Wezel(11));
            korzen.Dodaj(new Wezel(15));
            korzen.Dodaj(new Wezel(6));
            Console.WriteLine("Szukam wspolny wezel w  hierarchii dla wezlow o kluczach 11 oraz 15");
            Console.WriteLine("ten wezel ma klucz:");
            Wezel wynik = drzewo.Znajdz(new Wezel(11), new Wezel(15));
            if(wynik!=null)
            Console.WriteLine(wynik.klucz);
            else
                Console.WriteLine("ktorys z wezlow nie nalezy do drzewa");
            Console.ReadKey();
        }
    }
}

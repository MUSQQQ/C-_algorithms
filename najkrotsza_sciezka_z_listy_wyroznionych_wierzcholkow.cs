using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najkrotszasciezka
{
    
    class Program
    {
        public static int Dijkstra(List<List<int>> graf, int w1, int w2)
        {
            int licznik = 1;    //licznik ile pol tablicy wag ma nadal "maksymalna wartosc"

            bool[] czyOdwiedzony = new bool[graf.Count()];  //tablica odnosnie odwiedzonych wierzcholko0w
            for (int i = 0; i < graf.Count(); i++)
                czyOdwiedzony[i] = false;
            czyOdwiedzony[w1] = true;   //wierzcholek poczatkowy oczywiscie jest odwiedzony

            int[] wagi = new int[graf.Count()];     //tabvlica na aktualne wagi dojazdu do danego wierczholka
            for (int i = 0; i < graf.Count(); i++)
            {
                wagi[i] = 1000;
            }
            wagi[w1] = 0;       //waga poczatkowego wierczholka oczywiscie zero

            
            int p = w1;     //indeks wierczholka od ktorego zaczynam w while
            int minIndeksBliski = w2;       //indeks sasiedniego wierzcholka, ktory jeszcze nie zostal odwiedzony i ma mozliwie najmniejsza wage do niego laczaca
            while (licznik<=graf.Count())
            {
                
                //Console.WriteLine(licznik);
                czyOdwiedzony[p] = true;    //aktualny wierzcholek automatycznie staje sie wierzcholkiem odwiedzonym
                for (int k = 0; k < graf.Count(); k++)
                {
                    if (graf[p][k] != 0 && graf[p][k] < graf[p][minIndeksBliski]&&!czyOdwiedzony[k])  //sszukanie najmniejszej wagi stykajacej sie z danymi wierzcholkiem ktora laczy z jeszcze nie odwiedzonym wierzcholkiem
                        minIndeksBliski = k;

                    if (wagi[p] + graf[p][k] < wagi[k]) //jesli waga mniejsza niz dotychczasowa to zamien
                    {
                        wagi[k] = wagi[p] + graf[p][k];
                        
                    }
                }
                p = minIndeksBliski;    //kolejnym sprawdzanym wierzchokiem bedzie ten jeszcze nie sprawdzany ktory ma anjmniejsza wage pomiedzy soba a aktualnym wierzcholkiem
                //Console.WriteLine(minIndeksBliski);
                minIndeksBliski = w2;   
                licznik++;
            }
            return wagi[w2];
        }
        static void Main(string[] args)
        {
            List<List<int>> graf = new List<List<int>>();       //lista grafu z wagami. 1000 = "infinity"
            graf.Add(new List<int> { 0,1000,3,1000,1000,1000});
            graf.Add(new List<int> { 1000, 0, 1, 1, 1000, 1000 });
            graf.Add(new List<int> { 3, 1, 0, 4, 11, 1000 });
            graf.Add(new List<int> { 1000, 1, 4, 0, 1000, 2 });
            graf.Add(new List<int> { 1000, 1000, 11, 1000, 1000, 12 });
            graf.Add(new List<int> { 1000, 1000, 1000, 2, 12, 0 });

            int numer = 4;
            Console.WriteLine("zalozmy ze skrzyzowan jet 6, od zera do piatego");
            Console.WriteLine("posterunki znajduja sie na skrzyzowaniu 0 oraz 3");
            Console.WriteLine("do zdarzenia doszlo na skrzyzowaniu "+numer);
            Console.WriteLine("waga najkrotszej drogi z wierzcholka 0 do wierzcholka {0}:",numer);
            Console.WriteLine(Dijkstra(graf, 0, numer));
            Console.WriteLine("waga najkrotszej drogi z wierzcholka 3 do wierzcholka {0}:",numer);
            Console.WriteLine(Dijkstra(graf, 3, numer) );
            int a = 1000;
            if (Dijkstra(graf, 0, numer) < Dijkstra(graf, 3, numer))
                a = 0;
            else
                a = 3;
            Console.WriteLine("Nalezy wybrac posterunek numer: "+ a);
            Console.ReadKey();
        }
    }
}

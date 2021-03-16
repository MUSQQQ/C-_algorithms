using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimumsciezekwgrafie
{
    class Program
    {
        public static void MinDrog(List<List<int>> graf)
        {
            Stack<int> stos = new Stack<int>();
            stos.Push(0);   //pierwszy wiezrcholek
            int a = 0;
            bool[] tab =new bool[graf.Count()]; //tablica dzieki ktorej sprawdzam czy odwiedzilem juz dany wiezrcholek
            for (int i = 0; i < graf.Count(); i++)
                tab[i] = false;
            tab[0] = true;  //pierwszy wierzcholek juz nalezy do tej nowej sieci drog
            while(stos.Count!=0)
            {
                a=stos.Pop();
                for(int i=0;i<graf[a].Count();i++)
                {
                    if(!tab[graf[a][i]])    //jesli jeszcze nie odwiedzilem wierzcholka to wypisuje to polaczenie oraz wrzucam ten wierzcholek na stos
                    {
                        Console.WriteLine(a+"---"+graf[a][i]);
                        stos.Push(graf[a][i]);
                        tab[graf[a][i]] = true;
                    }
                }

            }
        }
        public static void WypiszGraf(List<List<int>> graf)
        {
            
            for(int i=0;i<graf.Count();i++)
            {
                for(int k=0;k<graf[i].Count();k++)
                {
                    if(i<graf[i][k])
                    Console.WriteLine(i+"---"+graf[i][k]);
                }
            }
        }
        static void Main(string[] args)
        {
            List<List<int>> graf = new List<List<int>>();
            graf.Add(new List<int> { 2 });
            graf.Add(new List<int> { 2,3 });
            graf.Add(new List<int> { 0,1,3,4 });
            graf.Add(new List<int> { 1,2,5 });
            graf.Add(new List<int> { 2,5 });
            graf.Add(new List<int> { 3,4 });
            
            Console.WriteLine("drogi w grafie wygladaja tak: ");
            WypiszGraf(graf);
            Console.WriteLine();
            Console.WriteLine("takie drogi sa wymagane: ");
            MinDrog(graf);

            Console.ReadKey();

        }
    }
}

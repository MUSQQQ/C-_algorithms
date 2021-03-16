using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Program
    {
        static void Sortowanie(string[] tab)
        {
            string[] wynik = new string[tab.Length];
            int maks = 0;
            
            int dlugosc = tab[0].Length - 1;
            string tmp = "";
            for(;dlugosc>=0;dlugosc--)
            for(int i=0;i<tab.Length;i++)
            {
                    
                   
                for (int k=i;k<tab.Length-1;k++)
                {
                        
                    if (tab[k].Length - 1 < dlugosc || tab[k + 1].Length - 1 < dlugosc)
                        if(tab[k+1].Length<tab[k].Length )
                        {
                               
                                tmp = tab[k];
                                tab[k] = tab[k + 1];
                                tab[k + 1] = tmp;
                        }
                            
                        if(tab[k].Length-1>=dlugosc&&tab[k+1].Length-1>=dlugosc)
                        if (tab[k][dlugosc] > tab[k + 1][dlugosc])
                        {
                                
                                tmp = tab[k];
                                tab[k] = tab[k + 1];
                                tab[k + 1] = tmp;
                        }
                        
                        
                }
            }
        }
        static void Main(string[] args)
        {
            string[] tab = { "zotd", "aksb", "oprs","aabc","zaaa","akz","oaazz" };
            for(int i=0;i<tab.Length;i++)
                Console.WriteLine(tab[i]);
            Console.WriteLine();
            Sortowanie(tab);
            Console.WriteLine(  );
            for(int i=0;i<tab.Length;i++)
                Console.WriteLine(tab[i]);

            Console.ReadKey();
        }
    }
}

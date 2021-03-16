using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boyer_Moore
{
    class Program
    {
        public const int k = 6;// znaki 0 do 5
        public static int[] P = new int[k];
        public static int indeks(char c)
        {
            return c - '0';
        }
        public static void inicjuj(string w)
        {
            int i, m = w.Length;
            for (i = 0; i < k; i++) P[i] = m;
            for (i = 0; i < m; i++)
                P[indeks(w[i])] = m - i - 1;
        }
        

        static void Main(string[] args)
        {
            inicjuj("1231");
            for (int i = 0; i < k; i++)
            {
                Console.Write(P[i] + " ");
            }
           
            Console.ReadKey();
        }
    }
}

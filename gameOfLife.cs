using System;
using System.Threading;
namespace GameOfLife
{
    class Program
    {
        static void NextGeneration(ref char[,] board)
        {
            int x = board.GetLength(0);
            int y = board.GetLength(1);
            char[,] temp = new char[x, y];

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    temp[i, j] = ' ';

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                   
                        int numOfNeighbours = 0;

                        if(i - 1 >= 0)
                        {
                            if (board[i - 1, j] == 'X')
                                numOfNeighbours++;

                            if (j - 1 >= 0)
                                if (board[i - 1, j - 1] == 'X')
                                    numOfNeighbours++;
                            if (j + 1 < y)
                                if (board[i - 1, j + 1] == 'X')
                                    numOfNeighbours++;
                        }
                        if (i + 1 < x)
                        {
                            if (board[i + 1, j] == 'X')
                                numOfNeighbours++;

                            if (j - 1 >= 0)
                                if (board[i + 1, j - 1] == 'X')
                                    numOfNeighbours++;
                            if (j + 1 < y)
                                if (board[i + 1, j + 1] == 'X')
                                    numOfNeighbours++;
                        }
                        if (j - 1 >= 0)
                            if (board[i, j - 1] == 'X')
                                numOfNeighbours++;
                        if (j + 1 < y)
                            if (board[i, j + 1] == 'X')
                                numOfNeighbours++;


                    if (board[i, j] == 'X')
                    {
                        if (numOfNeighbours == 2 || numOfNeighbours == 3)
                            temp[i, j] = 'X';
                    }
                    else
                        if(numOfNeighbours == 3)
                            temp[i, j] = 'X';
                    
                }
            board = temp;
            Thread.Sleep(200);
            Console.Clear();

        }

        static void Display(char[,] board)
        {
            int x = board.GetLength(0);
            int y = board.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                    Console.Write(board[i, j]);
                if(i != x - 1)
                Console.WriteLine();
            }

        }
        static void Life(ref char[,] board, int numOfGenerations)
        {

            int i = 0;
            while (i < numOfGenerations)
            {
                Display(board);
                NextGeneration(ref board);
                i++;
                
            }
        }
        static void Initialize(ref char[,] board)
        {
            Console.WriteLine("Hello in this game of life console app");
            Console.WriteLine("Choose starting setup of cells");
            Console.WriteLine("For symmetric madness that leads to a pulsar, enter 1");
            Console.WriteLine("For symmetric madness no. 2, enter 2");
            Console.WriteLine("For blinker, enter 3");
            Console.WriteLine("For glider, enter 4");
            Console.WriteLine("For pulsar, enter 5");
            Console.WriteLine("To exit enter anything else");
            char c = Convert.ToChar(Console.Read());

            if (c == '1')
            {
                board[24, 50] = 'X';
                board[23, 50] = 'X';
                board[22, 50] = 'X';
                board[21, 50] = 'X';
                board[20, 50] = 'X';
                board[26, 50] = 'X';
                board[27, 50] = 'X';
                board[28, 50] = 'X';
                board[29, 50] = 'X';
                board[30, 50] = 'X';

                Console.Clear();
                Life(ref board, 100);
            }
            else if (c == '2')
            {
                board[24, 50] = 'X';
                board[23, 50] = 'X';
                board[22, 50] = 'X';
                
                board[20, 50] = 'X';
                board[25, 50] = 'X';
                board[26, 50] = 'X';
                board[27, 50] = 'X';
                board[28, 50] = 'X';
                
                board[30, 50] = 'X';

                Console.Clear();
                Life(ref board, 100);
            }
            else if (c == '3')
            {
                board[24, 50] = 'X';
                board[23, 50] = 'X';
                board[22, 50] = 'X';

                Console.Clear();
                Life(ref board, 100);
            }
            else if (c == '4')
            {
                board[24, 50] = 'X';
                board[24, 48] = 'X';
                board[25, 50] = 'X';
                board[25, 49] = 'X';
                board[23, 50] = 'X';

                Console.Clear();
                Life(ref board, 100);
            }
            else if (c == '5')
            {
                int[] arr1 = new int[]{30, 35, 37, 42};
                for (int i = 0; i < arr1.Length; i++)
                {
                    board[18, arr1[i]] = 'X';
                    board[19, arr1[i]] = 'X';
                    board[20, arr1[i]] = 'X';
                    board[24, arr1[i]] = 'X';
                    board[25, arr1[i]] = 'X';
                    board[26, arr1[i]] = 'X';
                }

                int[] arr2 = new int[] { 16, 21, 23, 28 };
                for (int i = 0; i < arr2.Length; i++)
                {
                    board[arr2[i], 32] = 'X';
                    board[arr2[i], 33] = 'X';
                    board[arr2[i], 34] = 'X';
                    board[arr2[i], 38] = 'X';
                    board[arr2[i], 39] = 'X';
                    board[arr2[i], 40] = 'X';
                }


                Console.Clear();
                Life(ref board, 100);
            }

        }

        static void Main(string[] args)
        {
            
            int x = 100;
            int y = 50;
            Console.SetWindowSize(x, y+1);
            char[,] board = new char[y, x];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    board[j, i] = ' ';


            Initialize(ref board);

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}

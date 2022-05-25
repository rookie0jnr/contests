using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace YouCanGoYourOwnWay
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int tcIndex = 0; tcIndex < testCases; tcIndex++)
            {
                string currentTestResult = $"Case #{tcIndex + 1}: ";

                int N = Convert.ToInt32(Console.ReadLine());
                string LyndaPath = Console.ReadLine();

                char[,] maze = new char[N, N];
                for(int k = 0; k < N; k++)
                {
                    for (int l = 0; l < N; l++)
                    {
                        maze[k, l] = ' ';
                    }
                }

                bool shouldReachLastColumn = false;
                if (LyndaPath[LyndaPath.Length - 1] == 'E')
                {
                    shouldReachLastColumn = true;
                }

                int i = 0, j = 0, lp = 0;
                while (lp < LyndaPath.Length)
                {
                    maze[i, j] = LyndaPath[lp];
                    if (LyndaPath[lp] == 'E')
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                    }
                    lp++;
                }

                for (int k = 0; k < N; k++)
                {
                    for (int l = 0; l < N; l++)
                    {
                        Console.Write(maze[k, l].ToString() + ' ');
                    }
                    Console.WriteLine();
                }

                string myWay = string.Empty;
                i = 0;
                j = 0;
                lp = 0;
                if (shouldReachLastColumn)
                {
                    while (j <= N - 1)
                    {
                        if (maze[i, j] == 'S')
                        {
                            maze[i, j] = 'R';
                            myWay += 'E';
                            j++;
                        }
                        else if (maze[i, j] == 'E')
                        {
                            maze[i, j] = 'D';
                            myWay += 'S';
                            i++;
                        }
                    }
                    while (i <= N -1)
                    {
                        myWay += 'S';
                        maze[i, j] = 'D';
                        i++;
                    }

                }

                //currentTestResult += counter;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
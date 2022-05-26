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

                //char[,] maze = new char[N, N];
                //for(int k = 0; k < N; k++)
                //{
                //    for (int l = 0; l < N; l++)
                //    {
                //        maze[k, l] = ' ';
                //    }
                //}

                bool shouldReachLastColumn = false;
                if (LyndaPath[LyndaPath.Length - 1] == 'E')
                {
                    shouldReachLastColumn = true;
                }

                HashSet<(int, int)> forbidden = new HashSet<(int, int)> ();

                int i = 0, j = 0, lp = 0;
                while (lp < LyndaPath.Length)
                {
                    //maze[i, j] = LyndaPath[lp];
                    if (LyndaPath[lp] == 'E')
                    {
                        if (shouldReachLastColumn)
                        {
                            forbidden.Add((i, j));
                        }
                        j++;
                    }
                    else
                    {
                        if (!shouldReachLastColumn)
                        {
                            forbidden.Add((i, j));
                        }
                        i++;
                    }
                    lp++;
                }

                //for (int k = 0; k < N; k++)
                //{
                //    for (int l = 0; l < N; l++)
                //    {
                //        Console.Write(maze[k, l].ToString() + ' ');
                //    }
                //    Console.WriteLine();
                //}

                string myWay = string.Empty;
                i = 0;
                j = 0;
                lp = 0;
                if (shouldReachLastColumn)
                {
                    while (j < N - 1)
                    {
                        if (forbidden.Contains((i, j)))
                        {
                            //maze[i, j] = 'D';
                            forbidden.Remove((i, j));
                            myWay += 'S';
                            i++;
                        }
                        else
                        {
                            //maze[i, j] = 'R';
                            myWay += 'E';
                            j++;
                        }
                    }
                    while (i < N -1)
                    {
                        myWay += 'S';
                        //maze[i, j] = 'D';
                        i++;
                    }
                }
                else
                {
                    while (i < N - 1)
                    {
                        if (forbidden.Contains((i, j)))
                        {
                            //maze[i, j] = 'L';
                            forbidden.Remove((i, j));
                            myWay += 'E';
                            j++;
                        }
                        else
                        {
                            //maze[i, j] = 'D';
                            myWay += 'S';
                            i++;
                        }
                    }
                    while (j < N - 1)
                    {
                        myWay += 'E';
                        //maze[i, j] = 'L';
                        j++;
                    }

                }


                currentTestResult += myWay;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
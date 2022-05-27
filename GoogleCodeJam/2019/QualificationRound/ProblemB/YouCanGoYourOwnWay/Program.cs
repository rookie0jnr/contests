using System;
using System.Collections.Generic;
using System.Text;

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

                bool shouldReachLastColumn = false;
                if (LyndaPath[LyndaPath.Length - 1] == 'E')
                {
                    shouldReachLastColumn = true;
                }

                HashSet<(int, int)> forbidden = new HashSet<(int, int)> ();

                int i = 0, j = 0, lp = 0;
                while (lp < LyndaPath.Length)
                {
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

                StringBuilder myWay = new StringBuilder();
                i = 0;
                j = 0;
                if (shouldReachLastColumn)
                {
                    while (j < N - 1)
                    {
                        if (forbidden.Contains((i, j)))
                        {
                            forbidden.Remove((i, j));
                            myWay.Append('S');
                            i++;
                        }
                        else
                        {
                            myWay.Append('E');
                            j++;
                        }
                    }
                    while (i < N -1)
                    {
                        myWay.Append('S');
                        i++;
                    }
                }
                else
                {
                    while (i < N - 1)
                    {
                        if (forbidden.Contains((i, j)))
                        {
                            forbidden.Remove((i, j));
                            myWay.Append('E');
                            j++;
                        }
                        else
                        {
                            myWay.Append('S');
                            i++;
                        }
                    }
                    while (j < N - 1)
                    {
                        myWay.Append('E');
                        j++;
                    }
                }

                currentTestResult += myWay.ToString();
                results.Add(currentTestResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
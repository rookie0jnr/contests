using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static int[] list;

        static void Reverse(int start, int length)
        {
            int[] original = new int[length];
            Array.Copy(list, start, original, 0, length);

            for (int i = start, j = original.Length - 1; i < length + start; i++, j--)
            {
                list[i] = original[j];
            }
        }


        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";

                var inputs = Console.ReadLine().Split(' ');
                int N = Convert.ToInt32(inputs[0]);
                int C = Convert.ToInt32(inputs[1]);

                int a1 = 2;
                int an = a1 + N - 2;
                int Sn = (a1 + an) * (N - 1) / 2;
                if ((C < N - 1) || (C > Sn))
                {
                    currentTestResult += "IMPOSSIBLE";
                    results.Add(currentTestResult);
                    continue;
                }
                else
                {
                    int n = N - 1;
                    int currentSum = C;
                    bool[] revs = new bool[n];

                    for (int j = an, k = 0; j >= 2; j--, k++)
                    {
                        if (j + (n - k - 1) > currentSum)
                        {
                            currentSum--;
                        }
                        else if (j + (n - k - 1) < currentSum)
                        {
                            revs[k] = true;
                            currentSum -= j;
                        }
                        else // (j + (n - k - 1) == currentSum)
                        {
                            revs[k] = true;
                            break;
                        }
                    }

                    list = new int[N];
                    for (int j = 0; j < N; j++)
                    {
                        list[j] = j + 1;
                    }

                    for (int j = N - 2; j >= 0; j--)
                    {
                        if (revs[j])
                        {
                            Reverse(j, n - j + 1);
                        }
                    }

                }

                for (int j = 0; j < list.Length - 1; j++)
                {
                    currentTestResult += list[j];
                    currentTestResult += " ";
                }
                currentTestResult += list[list.Length - 1];

                //currentTestResult += cost;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }

        }
    }
}

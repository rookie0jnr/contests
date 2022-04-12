using System;
using System.Collections.Generic;
using System.Linq;

namespace PunchedCards
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: {Environment.NewLine}";
                var input = Console.ReadLine().Split(' ');
                int totalR = Convert.ToInt32(input[0]) * 2 + 1;
                int totalC = Convert.ToInt32(input[1]) * 2 + 1;

                char[,] result = new char[totalR, totalC];

                result[0, 0] = result[0, 1] = result[1, 0] = result[1, 1] = '.';

                for (int j = 0; j < 2; j++)
                {
                    for (int k = 2; k < totalC; k++)
                    {
                        if (j % 2 == 0)
                        {
                            if (k % 2 == 0)
                            {
                                result[j, k] = '+';
                            }
                            else
                            {
                                result[j, k] = '-';
                            }
                        }
                        else
                        {
                            if (k % 2 == 0)
                            {
                                result[j, k] = '|';
                            }
                            else
                            {
                                result[j, k] = '.';
                            }
                        }
                    }
                }


                for (int j = 2; j < totalR; j++)
                {
                    for (int k = 0; k < totalC; k++)
                    {
                        if (j % 2 == 0)
                        {
                            if (k % 2 == 0)
                            {
                                result[j, k] = '+';
                            }
                            else
                            {
                                result[j, k] = '-';
                            }
                        }
                        else
                        {
                            if (k % 2 == 0)
                            {
                                result[j, k] = '|';
                            }
                            else
                            {
                                result[j, k] = '.';
                            }
                        }
                    }
                }

                
                for (int j = 0; j < totalR; j++)
                {
                    for (int k = 0; k < totalC; k++)
                    {
                        currentTestResult += result[j, k];
                    }
                    currentTestResult += Environment.NewLine;
                }
                results.Add(currentTestResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
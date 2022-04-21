using System;
using System.Collections.Generic;
using System.Linq;

namespace _3DPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: ";

                var p1Inks = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                var p2Inks = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                var p3Inks = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

                int[] availableInk = new int[4];
                availableInk[0] = Math.Min(Math.Min(p1Inks[0], p2Inks[0]), p3Inks[0]); 
                availableInk[1] = Math.Min(Math.Min(p1Inks[1], p2Inks[1]), p3Inks[1]); 
                availableInk[2] = Math.Min(Math.Min(p1Inks[2], p2Inks[2]), p3Inks[2]); 
                availableInk[3] = Math.Min(Math.Min(p1Inks[3], p2Inks[3]), p3Inks[3]); 

                if (availableInk.Sum() < 1000000)
                {
                    currentTestResult += "IMPOSSIBLE";
                }
                else
                {
                    int remainingInk = 1000000;
                    foreach (var ink in availableInk)
                    {
                        if (remainingInk - ink > 0)
                        {
                            remainingInk -= ink;
                            currentTestResult += ink + " ";
                        }
                        else
                        {
                            currentTestResult += remainingInk + " ";
                            remainingInk = 0;
                        }
                    }
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
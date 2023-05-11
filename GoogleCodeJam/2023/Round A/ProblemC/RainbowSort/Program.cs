using System;
using System.Collections.Generic;

namespace RainbowSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: ";
                Console.ReadLine();
                var input = Console.ReadLine().Split(' ');

                HashSet<string> colors = new HashSet<string>();
                string previousColor = input[0];
                colors.Add(previousColor);
                string currentSequence = previousColor;

                for (int j = 1; j < input.Length; j++)
                {
                    string currentColor = input[j];
                    if (!currentColor.Equals(previousColor))
                    {
                        if (colors.Contains(currentColor))
                        {
                            currentSequence = "IMPOSSIBLE";
                            break;
                        }
                        else
                        {
                            colors.Add(currentColor);
                            currentSequence += $" {currentColor}";
                            previousColor = currentColor;
                        }

                    }
                }

                currentTestResult += currentSequence;
                results.Add(currentTestResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
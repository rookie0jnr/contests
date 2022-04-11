using System;
using System.Collections.Generic;

namespace d1000000
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

                Console.ReadLine(); // Just read (and discard) the N supplied
                var inputNumbers = Console.ReadLine().Split(' ');
                List<int> dices = new List<int>();
                for (int j = 0; j < inputNumbers.Length; j++)
                {
                    dices.Add(Convert.ToInt32(inputNumbers[j]));
                }

                int straight = 0;
                dices.Sort();
                for (int j = 0; j < dices.Count; j++)
                {
                    if (straight < dices[j])
                    {
                        straight++;
                    }
                }

                currentTestResult += straight;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
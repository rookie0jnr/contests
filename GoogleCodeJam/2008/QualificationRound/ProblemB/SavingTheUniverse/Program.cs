using System;
using System.Collections.Generic;

namespace SavingTheUniverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());

            List<string> results = new List<string>();
            
            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";

                int numberOfSearchEngines = Convert.ToInt32(Console.ReadLine());
                List<string> originalSearchEngines = new List<string>();
                for (int j = 0; j < numberOfSearchEngines; j++)
                {
                    originalSearchEngines.Add(Console.ReadLine());
                }
                List<string> currentSearchEngines = new List<string>(originalSearchEngines);


                int numberOfIncomingQueries = Convert.ToInt32(Console.ReadLine());
                string[] incomingQueries = new string[numberOfIncomingQueries];
                for (int j = 0; j < numberOfIncomingQueries; j++)
                {
                    incomingQueries[j] = Console.ReadLine();
                }

                int switches = 0;
                for (int j = 0; j < numberOfIncomingQueries; j++)
                {
                    if (currentSearchEngines.Count == 1 && incomingQueries[j].Equals(currentSearchEngines[0]))
                    {
                        switches++;
                        currentSearchEngines = new List<string>(originalSearchEngines);
                    }
                    if (currentSearchEngines.Contains(incomingQueries[j]))
                    {
                        currentSearchEngines.Remove(incomingQueries[j]);
                    }
                }

                currentTestResult += switches;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

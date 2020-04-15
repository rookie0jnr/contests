using System;
using System.Collections.Generic;

namespace Cryptopangrams
{
    class Solution
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();
            List<string> inputs = new List<string>();

            // Getting all the input
            for (int i = 0; i < testCases; i++)
            {
                inputs.Add(Console.ReadLine());
            }

            // Solve
            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";


                results.Add(currentTestResult);
            }

            // Writing results
            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace NestingDepth
{
    class Solution
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();
            List<string> inputs = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                inputs.Add(Console.ReadLine());
            }

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";
                results.Add(currentTestResult + inputs[i]);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

    }
}

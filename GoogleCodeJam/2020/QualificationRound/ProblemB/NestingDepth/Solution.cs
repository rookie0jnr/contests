using System;
using System.Collections.Generic;
using System.Text;

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
                string currentTestCase = inputs[i];

                bool isParentisisOpened = false;
                StringBuilder result = new StringBuilder();
                for (int j = 0; j < currentTestCase.Length; j++)
                {
                }

                results.Add(currentTestResult + result.ToString());
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

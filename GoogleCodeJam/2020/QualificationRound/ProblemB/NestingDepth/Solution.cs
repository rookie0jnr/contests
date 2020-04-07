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

                StringBuilder result = new StringBuilder();
                for (int j = 0; j < currentTestCase.Length; j++)
                {
                    result.Append(ANumberWithAllnecessaryParentesis(
                        Convert.ToInt32(Char.GetNumericValue(currentTestCase[j]))));
                }

                var stringResult = result.ToString();
                while (stringResult.Contains(")("))
                {
                    stringResult = stringResult.Replace(")(", string.Empty);
                }

                results.Add(currentTestResult + stringResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

        static string ANumberWithAllnecessaryParentesis(int number)
        {
            string result = string.Empty;

            for (int i = 0; i < number; i++)
            {
                result += '(';
            }
            result += number;
            for (int i = 0; i < number; i++)
            {
                result += ')';
            }

            return result;
        }
    }
}

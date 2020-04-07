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
                    if (currentTestCase[j] == '0')
                    {
                        if (isParentisisOpened)
                        {
                            result.Append(')');
                            isParentisisOpened = false;
                        }
                        result.Append('0');
                    }
                    else if (currentTestCase[j] == '1')
                    {
                        if (!isParentisisOpened)
                        {
                            result.Append('(');
                        }
                        result.Append('1');
                        isParentisisOpened = true;
                    }
                    else
                    {
                        if (isParentisisOpened)
                        {
                            result.Append(")");
                            isParentisisOpened = false;
                        }
                        result.Append(currentTestCase[j]);
                    }
                }
                if (isParentisisOpened)
                {
                    result.Append(')');
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

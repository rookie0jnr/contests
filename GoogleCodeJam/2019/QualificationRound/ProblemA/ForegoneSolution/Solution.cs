using System;
using System.Collections.Generic;

namespace ForegoneSolution
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
                string currentJamcoinsAmount = inputs[i];
                int jamcoinsLength = currentJamcoinsAmount.Length;
                int first4 = currentJamcoinsAmount.IndexOf('4');
                char[] firstCheck = currentJamcoinsAmount.ToCharArray();
                char[] secondCheck = new char[jamcoinsLength - first4];

                for (int j = 0; j < secondCheck.Length; j++)
                {
                    secondCheck[j] = '0';
                }

                for (int j = first4, k = 0; j < currentJamcoinsAmount.Length; j++, k++)
                {
                    if (currentJamcoinsAmount[j] == '4')
                    {
                        firstCheck[j] = '3';
                        secondCheck[k] = '1';
                    }
                    
                }
                results.Add(currentTestResult + new string(firstCheck) + " " + new string(secondCheck));
            }

            // Writing results
            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

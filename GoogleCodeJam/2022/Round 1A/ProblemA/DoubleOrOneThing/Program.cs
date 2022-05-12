using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace DoubleOrOneThing
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{i + 1}: ";

                string S = Console.ReadLine();
                string result = S[S.Length - 1].ToString();

                int charPosition = S.Length - 2;
                while (charPosition >= 0)
                {
                    string one = S[charPosition] + result;
                    string two = S[charPosition].ToString() + S[charPosition] + result;
                    if (String.Compare(one, two) < 0)
                    {
                        result = one;
                    }
                    else
                    {
                        result = two;
                    }
                    charPosition--;
                }

                currentTestResult += result;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
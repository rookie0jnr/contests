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
                string result = S;


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
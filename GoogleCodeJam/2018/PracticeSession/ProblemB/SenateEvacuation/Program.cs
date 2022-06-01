using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SenateEvacuation
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int tcIndex = 0; tcIndex < testCases; tcIndex++)
            {
                string currentTestResult = $"Case #{tcIndex + 1}: ";
                var dn = Console.ReadLine().Split(' ');

                //currentTestResult += (D / times.Max()).ToString("F6");
                results.Add(currentTestResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
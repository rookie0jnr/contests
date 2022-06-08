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
                int N = Convert.ToInt32(Console.ReadLine());
                int[] senatorsRaw = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                SortedSet<(int numberOfSenators, string partyName)> senators =
                    new SortedSet<(int numberOfSenators, string partyName)>();

                char partyName = 'A';
                for (int i = 0; i < senatorsRaw.Length; i++)
                {
                    senators.Add((senatorsRaw[i], partyName.ToString()));
                    partyName++;
                }

                while (senators.Count > 0)
                {
                    if (senators.Max.numberOfSenators >= 2)
                    {

                    }
                    else
                    {

                    }
                }

                string currentTestResult = $"Case #{tcIndex + 1}: ";
                //currentTestResult += (D / times.Max()).ToString("F6");
                results.Add(currentTestResult);
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
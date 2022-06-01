using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Steed2CruiseControl
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
                int D = Convert.ToInt32(dn[0]);
                int N = Convert.ToInt32(dn[1]);
                
                List<double> times = new List<double>();
                for (int i = 0; i < N; i++)
                {
                    var ks = Console.ReadLine().Split(' ');
                    int K = Convert.ToInt32(ks[0]);
                    int S = Convert.ToInt32(ks[1]);

                    times.Add((D - K) / (double)S);
                }

                currentTestResult += (D / times.Max()).ToString("F6");
                results.Add(currentTestResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
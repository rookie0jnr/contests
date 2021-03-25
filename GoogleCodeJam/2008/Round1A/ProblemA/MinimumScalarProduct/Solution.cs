using System;
using System.Collections.Generic;

namespace MinimumScalarProduct
{
    class Solution
    {
        static void Main(string[] args)
        {
            int numberOfTestCases;
            int outputLineNumber = 1;
            numberOfTestCases = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < numberOfTestCases; i++)
            {
                int numberOfElements = Convert.ToInt32(Console.ReadLine());

                string firstVector = Console.ReadLine();
                string secondVector = Console.ReadLine();

                List<long> x = new List<long>();
                List<long> y = new List<long>();

                foreach (string numberX in firstVector.Split(' '))
                {
                    x.Add(Convert.ToInt32(numberX));
                }

                foreach (string numberY in secondVector.Split(' '))
                {
                    y.Add(Convert.ToInt32(numberY));
                }

                x.Sort();
                y.Sort();
                y.Reverse();

                long sum = 0;
                for (int j = 0; j < numberOfElements; j++)
                {
                    sum += x[j] * y[j];
                }

                Console.WriteLine("Case #" + outputLineNumber++ + ": " + sum);
            }
        }
    }
}

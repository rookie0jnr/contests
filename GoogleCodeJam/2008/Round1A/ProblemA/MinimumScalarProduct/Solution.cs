using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MinimumScalarProduct
{
    class Solution
    {
        static void Main(string[] args)
        {
            int numberOfTestCases;
            int outputLineNumber = 1;

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
                //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
                using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
                {

                    for (int i = 0; i < numberOfTestCases; i++)
                    {
                        int numberOfElements = Convert.ToInt32(inputFile.ReadLine());

                        string firstVector = inputFile.ReadLine();
                        string secondVector = inputFile.ReadLine();

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

                        //Console.WriteLine(sum);
                        outputFile.WriteLine("Case #" + outputLineNumber++ + ": " + sum);
                    }
                }
            }
        }
    }
}

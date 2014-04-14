using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pB
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<double> results = new List<double>();
            char[,] targets = new char[10, 4];

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\B-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\B-small-attempt0.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\B-large.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    string[] numbers = inputFile.ReadLine().Split(' ');
                    double C = Convert.ToDouble(numbers[0]);
                    double F = Convert.ToDouble(numbers[1]);
                    double X = Convert.ToDouble(numbers[2]);

                    int globalIndex = 0;
                    double previousTime = X / 2;
                    double currentTime = previousTime;

                    do
                    {
                        previousTime = currentTime;
                        double currentTimeSum = 0.0d;
                        for (int j = 0; j <= globalIndex; j++)
                        {
                            currentTimeSum += C / (2 + j * F);
                        }
                        globalIndex++;
                        currentTime = currentTimeSum + (X / (2 + globalIndex * F)) ;

                    }
                    while (previousTime >= currentTime);

                    results.Add(previousTime);
                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\B-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\B-small-attempt0.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\B-large.out"))
            {
                //Console.WriteLine(numberOfIntersectionPoints);
                int i = 1;
                foreach (double result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }
    }
}

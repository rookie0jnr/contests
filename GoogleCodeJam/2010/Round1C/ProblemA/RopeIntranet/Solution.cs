using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RopeIntranet
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<int> results = new List<int>();
            
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    int numberOfWires = Convert.ToInt32(inputFile.ReadLine());
                    int[,] wires = new int[numberOfWires, 2];

                    for (int j = 0; j < numberOfWires; j++)
                    {
                        string[] wireEndPoints = inputFile.ReadLine().Split(' ');
                        wires[j, 0] = Convert.ToInt32(wireEndPoints[0]);
                        wires[j, 1] = Convert.ToInt32(wireEndPoints[1]);
                    }

                    int numberOfIntersectionPoints = 0;
                    for (int j = 0; j < (numberOfWires - 1); j++)
                    {
                        for (int k = j; k < numberOfWires; k++)
                        {
                            if ( ((wires[j,0] - wires[k,0]) * (wires[j,1] - wires[k,1])) < 0 )
                            {
                                numberOfIntersectionPoints++;
                            }
                        }
                    }

                    results.Add(numberOfIntersectionPoints);
                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            {
                //Console.WriteLine(numberOfIntersectionPoints);
                int i = 1;
                foreach (int result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }
    }
}
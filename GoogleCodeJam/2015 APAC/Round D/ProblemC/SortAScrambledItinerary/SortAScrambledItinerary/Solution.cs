using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAScrambledItinerary
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    int N = Convert.ToInt32(inputFile.ReadLine());

                    string[] gBuses = inputFile.ReadLine().Split(' ');

                    List<Tuple<int, int>> gBusesList = new List<Tuple<int, int>>();
                    for (int i = 0; i < (2 * N); i = i + 2)
                    {
                        gBusesList.Add(new Tuple<int, int>(Convert.ToInt32(gBuses[i]), Convert.ToInt32(gBuses[i + 1])));
                    }
                    gBusesList.Sort((a, b) => a.Item1.CompareTo(b.Item1));

                    int P = Convert.ToInt32(inputFile.ReadLine());
                    int[] sities = new int[P];

                    for (int i = 0; i < P; i++)
                    {
                        sities[i] = Convert.ToInt32(inputFile.ReadLine());
                    }

                    int[] resultArray = new int[P];
                    for (int i = 0; i < P; i++)
                    {
                        int gBusesCoverCityCount = 0;
                        foreach (Tuple<int, int> bus in gBusesList)
                        {
                            if (bus.Item1 > sities[i])
                            {
                                break;
                            }
                            else if ((bus.Item1 <= sities[i]) && (bus.Item2 >= sities[i]))
                            {
                                gBusesCoverCityCount++;
                            }
                        }

                        resultArray[i] = gBusesCoverCityCount;
                    }

                    string testCaseResult = string.Empty;
                    int res = 0;
                    for (; res < P - 1; res++)
                    {
                        testCaseResult += resultArray[res] + " ";
                    }
                    testCaseResult += resultArray[res];
                    results.Add(testCaseResult);

                    inputFile.ReadLine();
                }
            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-large-practice.out"))
            {

                int i = 1;
                foreach (string result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }
    }
}

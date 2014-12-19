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

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    int numberOfTickets = Convert.ToInt32(inputFile.ReadLine());

                    List<string> sources = new List<string>();
                    List<string> destinations = new List<string>();

                    for (int i = 0; i < (numberOfTickets * 2); i = i + 2)
                    {
                        sources.Add(inputFile.ReadLine());
                        destinations.Add(inputFile.ReadLine());
                    }

                    string ticketSource = string.Empty;
                    foreach (var source in sources)
                    {
                        if (!destinations.Contains(source))
                        {
                            ticketSource = source;
                            break;
                        }
                    }

                    string testCaseResult = string.Empty;
                    for (int i = 0; i < sources.Count; i++)
                    {
                        if (sources[i] == ticketSource)
                        {
                            testCaseResult += sources[i] + "-";
                            testCaseResult += destinations[i] + " ";
                            ticketSource = destinations[i];
                            sources.RemoveAt(i);
                            destinations.RemoveAt(i);
                            i = -1;
                        }
                    }

                    testCaseResult = testCaseResult.Remove(testCaseResult.Length - 1);
                    results.Add(testCaseResult);
                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-small-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-large-practice.out"))
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

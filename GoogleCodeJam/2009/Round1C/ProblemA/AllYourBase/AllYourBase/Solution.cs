using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllYourBase
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    int credit = Convert.ToInt32(inputFile.ReadLine());

                    int numberOfItems = Convert.ToInt32(inputFile.ReadLine());

                    string[] itemPricesAsStrings = inputFile.ReadLine().Split(' ');

                    int[] itemPrices = new int[numberOfItems];

                    for (int i = 0; i < numberOfItems; i++)
                    {
                        itemPrices[i] = Convert.ToInt32(itemPricesAsStrings[i]);
                    }

                    bool arePricesFound = false;
                    for (int i = 0; i < numberOfItems - 1; i++)
                    {
                        for (int j = i + 1; j < numberOfItems; j++)
                        {
                            if (credit == itemPrices[i] + itemPrices[j])
                            {
                                results.Add((i + 1) + " " + (j + 1));
                                arePricesFound = true;
                                break;
                            }
                        }

                        if (arePricesFound)
                        {
                            break;
                        }
                    }
                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_IV
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    string[] inputString = inputFile.ReadLine().Split(' ');

                    int wordsCount = inputString.Length;
                    string result = string.Empty;

                    for (int i = wordsCount - 1; i > 0; i--)
                    {
                        result += inputString[i] + ' ';
                    }
                    result += inputString[0];

                    results.Add(result);
                }

            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
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

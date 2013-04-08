using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlienLanguage
{
    class Solution
    {
        static void Main(string[] args)
        {
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                string inputNumbers = inputFile.ReadLine();
                string[] numbers = inputNumbers.Split(' ');
                int numberOfLetters = Convert.ToInt16(numbers[0]);
                int numberOfKnownWords = Convert.ToInt16(numbers[1]);
                int numberOfTestCases = Convert.ToInt16(numbers[2]);

                List<string> knownWords = new List<string>();
                for (int i = 0; i < numberOfKnownWords; i++)
                {
                    knownWords.Add(inputFile.ReadLine());
                }

                List<List<string>> testCases = new List<List<string>>();
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    string currentTestCase = inputFile.ReadLine();
                    int lengthOfTestCase = currentTestCase.Length;

                    for (int j = 0; j < lengthOfTestCase; j++)
                    {
 
                    }

                }

                

                using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
                {
                        //outputFile.WriteLine("Case #" + outputLineNumber++ + ": " + sum);
                }
            }
        }
    }
}

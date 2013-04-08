using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlienLanguage
{
    class Solution
    {
        static void Main(string[] args)
        {
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
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

                    List<string> currentPattern = new List<string>();
                    for (int j = 0; j < lengthOfTestCase; j++)
                    {

                        if (currentTestCase[j] != '(')
                        {
                            currentPattern.Add(currentTestCase[j].ToString());
                        }
                        else
                        {
                            j++;
                            string current = string.Empty;
                            while (currentTestCase[j] != ')')
                            {
                                current += currentTestCase[j++];
                            }
                            currentPattern.Add(current);
                        }
                    }

                    testCases.Add(currentPattern);
                }

                //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
                //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
                using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
                {
                    for (int i = 0; i < numberOfTestCases; i++)
                    {
                        int numberOfPossibleMatches = 0;

                        foreach (string knownWord in knownWords)
                        {
                            bool canMatch = true;
                            for (int j = 0; j < numberOfLetters; j++)
                            {
                                if (!testCases[i][j].Contains(knownWord[j]))
                                {
                                    canMatch = false;
                                    break;
                                }
                            }

                            if (true == canMatch)
                            {
                                numberOfPossibleMatches++;
                            }
                        }

                        //Console.WriteLine(numberOfPossibleMatches);
                        outputFile.WriteLine("Case #{0}: {1}",i + 1, numberOfPossibleMatches);
                    }
                }
            }
        }
    }
}

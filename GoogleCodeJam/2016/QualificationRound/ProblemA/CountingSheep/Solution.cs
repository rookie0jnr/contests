using System;
using System.Collections.Generic;
using System.IO;

namespace CountingSheep
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
                    string pickedNumberString = inputFile.ReadLine();
                    long pickedNumber = Convert.ToInt64(pickedNumberString);

                    if (pickedNumber == 0)
                    {
                        results.Add("INSOMNIA");
                        continue;
                    }

                    List<string> digits = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                    for (int i = 1; i < 20000; i++)
                    {
                        long currentNumber = pickedNumber * i;
                        string currentNumberString = currentNumber.ToString();
                        foreach (string digit in digits.ToArray())
                        {
                            if (currentNumberString.Contains(digit))
                            {
                                digits.Remove(digit);
                            }
                        }

                        if (digits.Count == 0)
                        {
                            results.Add(currentNumberString);
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

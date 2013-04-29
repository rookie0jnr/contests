using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FairAndSquare
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<ulong> results = new List<ulong>();

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-small-attempt0.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\C-large-1.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    string[] interval = inputFile.ReadLine().Split(' ');
                    ulong numberOfFairs = 0;

                    ulong start = Convert.ToUInt64(interval[0]);
                    ulong end = Convert.ToUInt64(interval[1]);

                    for (ulong j = start; j <= end; j++)
                    {
                        if (isPalindrome(j))
                        {
                            double squareRoot = Math.Sqrt(j);

                            if (squareRoot % 1 == 0)
                            {
                                if (isPalindrome(Convert.ToUInt64(squareRoot)))
                                {
                                    numberOfFairs++;
                                }
                            }
                        }
                    }


                    results.Add(numberOfFairs);
                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-small-attempt0.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\C-large-1.out"))
            {
                int i = 1;
                foreach (int result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        static bool isPalindrome(ulong number)
        {
            bool result = true;

            string theNumber = number.ToString();
            int numberOfDigits = theNumber.Length;
            int half = numberOfDigits / 2;

            for (int i = 0; i <= half; i++)
            {
                if (theNumber[i] != theNumber[numberOfDigits - i - 1])
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}

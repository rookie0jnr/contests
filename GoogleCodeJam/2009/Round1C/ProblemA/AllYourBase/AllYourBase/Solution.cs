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

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    Dictionary<char, short> digitsMapping = new Dictionary<char, short>();

                    char[] digits = inputFile.ReadLine().ToCharArray();

                    foreach (char digit in digits)
                    {
                        if (!digitsMapping.ContainsKey(digit))
                        {
                            digitsMapping.Add(digit, -1);
                        }
                    }

                    int targetBase = digitsMapping.Keys.Count;

                    digitsMapping[digits[0]] = 1;
                    int digitsCount = digits.Length;

                    for (int i = 1; i < digitsCount; i++)
                    { 

                    }
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

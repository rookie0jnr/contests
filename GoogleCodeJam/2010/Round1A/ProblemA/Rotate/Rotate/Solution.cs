using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<ulong> results = new List<ulong>();

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practiceROTATED.in"))
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
                    if (1 == targetBase)
                    {
                        targetBase = 2;
                    }

                    //digitsMapping[digits[0]] = 1;
                    int digitsCount = digits.Length;
                    short[] mappedDigits = new short[targetBase];

                    for (short i = 0; i < targetBase; i++)
                    {
                        if (i == 0)
                        {
                            mappedDigits[i] = 1;
                            continue;
                        }
                        if (i == 1)
                        {
                            mappedDigits[i] = 0;
                            continue;
                        }
                        mappedDigits[i] = i;
                    }

                    int j = 0;
                    for (int i = 0; i < digitsCount; i++)
                    {
                        if (digitsMapping[digits[i]] == -1)
                        {
                            digitsMapping[digits[i]] = mappedDigits[j++];
                        }
                    }

                    // calculate the seconds
                    ulong result = 0;
                    int k = 0;
                    for (int i = digitsCount - 1; i >= 0; i--)
                    {
                        result += power(targetBase, k++) * (ulong)digitsMapping[digits[i]];
                    }

                    results.Add(result);

                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practiceROTATED.out"))
            {

                int i = 1;
                foreach (ulong result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        private static ulong power(int number, int power)
        {
            ulong result = 1;

            if (power == 0)
            {
                return 1;
            }

            if (number == 0)
            {
                return 0;
            }

            for (int i = 0; i < power; i++)
            {
                result *= (ulong)number;
            }

            return result;
        }
    }
}

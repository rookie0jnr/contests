using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";

                string[] input = Console.ReadLine().Split(' ');
                int CJcost = Convert.ToInt32(input[0]);
                int JCcost = Convert.ToInt32(input[1]);

                StringBuilder mural = new StringBuilder(input[2]);
                string muralString = mural.ToString();
                if (CJcost > 0 && JCcost > 0)
                {
                    if (muralString.StartsWith('?'))
                    {
                        char startChar = 'C';
                        if (muralString.IndexOf('C') > -1 && muralString.IndexOf('J') > -1 && muralString.IndexOf('J') < muralString.IndexOf('C')
                            || (muralString.IndexOf('C') == -1 && muralString.IndexOf('J') > -1))
                        {
                            startChar = 'J';
                        }
                        mural[0] = startChar;
                    }
                    int currentQMIndex = 1;
                    while (mural.ToString().Contains('?'))
                    {
                        if (mural[currentQMIndex] == '?')
                            mural[currentQMIndex] = mural[currentQMIndex - 1];
                        currentQMIndex++;
                    }

                }
                else
                { // negative cost
                    if (muralString.StartsWith('?'))
                    {
                        char startChar = 'C';
                        if (muralString.IndexOf('C') > -1 && muralString.IndexOf('J') > -1 && muralString.IndexOf('J') < muralString.IndexOf('C')
                            || (muralString.IndexOf('C') == -1 && muralString.IndexOf('J') > -1))
                        {
                            startChar = 'J';
                        }
                        mural[0] = startChar;
                    }
                    int currentQMIndex = 1;
                    while (mural.ToString().Contains('?'))
                    {
                        if (mural[currentQMIndex] == '?')
                            mural[currentQMIndex] = mural[currentQMIndex - 1];
                        currentQMIndex++;
                    }

                }


                int total = 0;
                total += Regex.Matches(mural.ToString(), "CJ").Count() * CJcost;
                total += Regex.Matches(mural.ToString(), "JC").Count() * JCcost;



                currentTestResult += total;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
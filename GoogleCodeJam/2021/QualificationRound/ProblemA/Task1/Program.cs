using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static StringBuilder list;
        //static void Main(string[] args)
        //{
        //    list = new StringBuilder("1243");
        //    Reverse(2, 3 - 2 +1);
        //}

        static void Reverse(int start, int length)
        {
            string original = list.ToString().Substring(start, length);
            for (int i = start, j = original.Length - 1; i < length + start; i++, j--)
            {
                list[i] = original[j];
            }
            
        }

        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";

                int N = Convert.ToInt32(Console.ReadLine());
                list = new StringBuilder(Console.ReadLine().Replace(" ", string.Empty));

                int cost = 0;
                for (int j = 0;  j < list.Length - 1;  j++)
                {
                    string listString = list.ToString();
                    int minE = listString.IndexOf(listString.Substring(j, listString.Length - j).Min());

                    if(minE == j)
                    {
                        cost++;
                        continue;
                    }

                    cost += minE - j + 1;
                    Reverse(j, minE - j + 1);
                    
                }

                currentTestResult += cost;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

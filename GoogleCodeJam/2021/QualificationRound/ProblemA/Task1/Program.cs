using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static int[] list;

        static void Reverse(int start, int length)
        {
            int[] original = new int[length];
            Array.Copy(list, start, original, 0, length);

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

                Console.ReadLine(); // Just read (and discard) the N supplied
                var inputNumbers = Console.ReadLine().Split(' ');
                list = new int[inputNumbers.Length];
                for (int j = 0; j < inputNumbers.Length; j++)
                {
                    list[j] = Convert.ToInt32(inputNumbers[j]);
                }

                int cost = 0;
                for (int j = 0;  j < list.Length - 1;  j++)
                {
                    int[] subArray = new int[list.Length - j];
                    Array.Copy(list, j, subArray, 0, list.Length - j);

                    int minE = Array.IndexOf(subArray, subArray.Min());

                    if (minE == 0)
                    {
                        cost++;
                        continue;
                    }

                    cost += minE + 1;
                    Reverse(j, minE + 1);
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

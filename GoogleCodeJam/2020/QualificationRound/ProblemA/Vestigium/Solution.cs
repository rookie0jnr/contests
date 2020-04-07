using System;
using System.Collections.Generic;

namespace Vestigium
{
    class Solution
    {

        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();
            Dictionary<int, int[,]> inputs = new Dictionary<int, int[,]>();

            for (int i = 0; i < testCases; i++)
            {
                int matrixDimensions = Convert.ToInt32(Console.ReadLine());
                int[,] currentMatrix = new int[matrixDimensions, matrixDimensions];
                for (int j = 0; j < matrixDimensions; j++)
                {
                    string matrixRow = Console.ReadLine();
                    var col = matrixRow.Split(' ');
                    for (int k = 0; k < matrixDimensions; k++)
                    {
                        currentMatrix[j, k] = Convert.ToInt32(col[k]);
                    }
                }

                inputs.Add(i, currentMatrix);
            }

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";

                var currentMatrix = inputs[i];
                int matrixDimension = currentMatrix.GetLength(0);
                int trace = 0;

                for (int j = 0; j < matrixDimension; j++)
                {
                    trace += currentMatrix[j, j];
                }

                currentTestResult += trace;

                int duplicatedRows = 0;

                for (int j = 0; j < matrixDimension; j++)
                {
                    List<int> rowElements = new List<int>();
                    for (int k = 0; k < matrixDimension; k++)
                    {
                        if (!rowElements.Contains(currentMatrix[j, k]))
                        {
                            rowElements.Add(currentMatrix[j, k]);
                        }
                    }
                    if (rowElements.Count != matrixDimension)
                    {
                        duplicatedRows++;
                    }
                }


                int duplicatedColumns = 0;

                for (int j = 0; j < matrixDimension; j++)
                {
                    List<int> columnElements = new List<int>();
                    for (int k = 0; k < matrixDimension; k++)
                    {
                        if (!columnElements.Contains(currentMatrix[k, j]))
                        {
                            columnElements.Add(currentMatrix[k, j]);
                        }
                    }
                    if (columnElements.Count != matrixDimension)
                    {
                        duplicatedColumns++;
                    }
                }

                currentTestResult += " " + duplicatedRows + " " + duplicatedColumns;
                results.Add(currentTestResult);
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
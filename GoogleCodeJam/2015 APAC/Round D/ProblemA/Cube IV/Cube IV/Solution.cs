using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube_IV
{
    class Solution
    {
        private static int[,] rooms;
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                inputFile.ReadLine();

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    int S = Convert.ToInt32(inputFile.ReadLine());

                    int upperBound = S + 1;

                    rooms = new int[S + 2, S + 2];
                    for (int i = 0; i < S + 2; i++)
                    {
                        rooms[0, i] = -1;
                        rooms[upperBound, i] = -1;
                    }
                    for (int i = 0; i < S + 2; i++)
                    {
                        rooms[i, 0] = -1;
                        rooms[i, upperBound] = -1;
                    }


                    for (int i = 1; i < upperBound; i++)
                    {
                        string[] rows = inputFile.ReadLine().Split(' ');
                        for (int j = 1; j < upperBound; j++)
                        {
                            rooms[i, j] = Convert.ToInt32(rows[j - 1]);
                        }
                    }

                    int minimalStartCellNumber = S * S;
                    int maximumPathLength = 0;

                    for (int i = 1; i < upperBound; i++)
                    {
                        for (int j = 1; j < upperBound; j++)
                        {
                            int startX = i;
                            int startY = j;
                            while (canGoBack(ref startX, ref startY, rooms[startX, startY]))
                            {
                                
                            }

                            // at this point - startX and startY contains the coordinates of the first cell
                            int firstCellNumber = rooms[startX, startY];
                            int counter = 1;
                            while (canGoForward(ref startX, ref startY, rooms[startX, startY]))
                            {
                                counter++;
                            }

                            if (maximumPathLength < counter)
                            {
                                maximumPathLength = counter;
                                minimalStartCellNumber = firstCellNumber;
                            }
                            else if ((maximumPathLength == counter) && (minimalStartCellNumber > firstCellNumber))
                            {
                                minimalStartCellNumber = firstCellNumber;
                            }

                        }
                    }

                    results.Add(minimalStartCellNumber + " " + maximumPathLength);
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

        private static bool canGoBack(ref int x, ref int y, int currentValue)
        {

            if (rooms[x - 1, y] == currentValue - 1)
            {
                x = x - 1;
                return true;
            }

            if (rooms[x, y - 1] == currentValue - 1)
            {
                y = y - 1;
                return true;
            }

            if (rooms[x + 1, y] == currentValue - 1)
            {
                x = x + 1;
                return true;
            }

            if (rooms[x, y + 1] == currentValue - 1)
            {
                y = y + 1;
                return true;
            }

            return false;
        }

        private static bool canGoForward(ref int x, ref int y, int currentValue)
        {

            if (rooms[x - 1, y] == currentValue + 1)
            {
                x = x - 1;
                return true;
            }

            if (rooms[x, y - 1] == currentValue + 1)
            {
                y = y - 1;
                return true;
            }

            if (rooms[x + 1, y] == currentValue + 1)
            {
                x = x + 1;
                return true;
            }

            if (rooms[x, y + 1] == currentValue + 1)
            {
                y = y + 1;
                return true;
            }

            return false;
        }
    }
}

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
        static char[,] rotatedArray;
        static int k = 0;
        static int n = 0;

        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practiceROTATED.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int t = 0; t < numberOfTestCases; t++)
                {
                    string[] nAndK = inputFile.ReadLine().Split(' ');
                    n = Convert.ToInt32(nAndK[0]);
                    k = Convert.ToInt32(nAndK[1]);

                    rotatedArray = new char[n, n];

                    // once rotated input is solved
                    // change this!
                    for (int i = 0; i < n; i++)
                    {
                        string matrixRow = inputFile.ReadLine();
                        for (int j = 0; j < n; j++)
                        {
                            rotatedArray[i,j] = matrixRow[j];
                        }
                    }

                    bool RisAWinner = false;
                    bool BisAWinner = false;
                    for (int i = n - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if ('.'.Equals(rotatedArray[i, j]))
                            {
                                continue;
                            }

                            if (RisAWinner && BisAWinner)
                            {
                                // both players are winners, so there is no point to continue.
                                break;
                            }

                            char currentElement = rotatedArray[i, j];

                            if ('R'.Equals(currentElement) && RisAWinner)
                            {
                                continue;
                            }

                            if ('B'.Equals(currentElement) && BisAWinner)
                            {
                                continue;
                            }

                            if (checkDirectionRIGHT(i, j, currentElement) ||
                                checkDirectionUP_RIGHT(i, j, currentElement) ||
                                checkDirectionUP(i, j, currentElement) ||
                                checkDirectionUP_LEFT(i, j, currentElement))
                            {
                                if ('R'.Equals(currentElement))
                                {
                                    RisAWinner = true;
                                }
                                if ('B'.Equals(currentElement))
                                {
                                    BisAWinner = true;
                                }
                            }
                        }
                    }

                    if (!(RisAWinner || BisAWinner))
                    {
                        results.Add("Neither");
                    }
                    else if (RisAWinner && BisAWinner)
                    {
                        results.Add("Both");
                    }
                    else if (RisAWinner)
                    {
                        results.Add("Red");
                    }
                    else
                    {
                        results.Add("Blue");
                    }
                }
            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practiceROTATED.out"))
            {

                int i = 1;
                foreach (string result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        static bool checkDirectionRIGHT(int x, int y, char element)
        {
            if ((x + k < n) && (element.Equals(rotatedArray[x + k - 1, y])))
            {
                for (int i = x; i < (x+k - 2); i++)
                {
                    if (!element.Equals(rotatedArray[i, y]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        static bool checkDirectionUP_RIGHT(int x, int y, char element)
        {
            if ((x + k < n) && (y + k < n) && (element.Equals(rotatedArray[x + k - 1, y + k - 1])))
            {
                for (int i = x; i < (x + k - 2); i++)
                {
                    for (int j = y; j < (y + k - 2); j++)
                    {
                        if (!element.Equals(rotatedArray[i, j]))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        static bool checkDirectionUP(int x, int y, char element)
        {
            if ((y - k >= 0) && (element.Equals(rotatedArray[x, y - k + 1])))
            {
                for (int i = y; i > (y - k + 2); i--)
                {
                    if (!element.Equals(rotatedArray[x, i]))
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        static bool checkDirectionUP_LEFT(int x, int y, char element)
        {
            return false;
        }
    }
}

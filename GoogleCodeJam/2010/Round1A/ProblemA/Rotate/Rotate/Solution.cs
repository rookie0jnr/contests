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
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practiceROTATED.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int t = 0; t < numberOfTestCases; t++)
                {
                    string[] nAndK = inputFile.ReadLine().Split(' ');
                    n = Convert.ToInt32(nAndK[0]);
                    k = Convert.ToInt32(nAndK[1]);

                    char[,] originalArray = new char[n, n];
                    for (int i = 0; i < n; i++)
                    {
                        string matrixRow = inputFile.ReadLine();
                        for (int j = 0; j < n; j++)
                        {
                            originalArray[i, j] = matrixRow[j];
                        }
                    }

                    rotate(originalArray);

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

                            int rightLIMIT = j + k - 1;
                            int upLIMIT = i - k + 1;

                            if (checkDirectionRIGHT(j, i, currentElement, rightLIMIT) ||
                                checkDirectionUP(j, i, currentElement, upLIMIT) ||
                                checkDirectionUP_RIGHT(j, i, currentElement, upLIMIT, rightLIMIT) ||
                                checkDirectionUP_LEFT(j, i, currentElement, upLIMIT))
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
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practiceROTATED.out"))
            {

                int i = 1;
                foreach (string result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        static void rotate(char[,] originalArray)
        {
            rotatedArray = new char[n, n];

            int rRow = n - 1;
            int rCol = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (!'.'.Equals(originalArray[i, j]))
                    {
                        rotatedArray[rRow--, rCol] = originalArray[i, j];
                    }
                }

                for (int emptyCells = rRow; emptyCells >= 0; emptyCells--)
                {
                    rotatedArray[emptyCells, rCol] = '.';
                }

                rCol++;
                rRow = n - 1;
            }

        }

        static bool checkDirectionRIGHT(int x, int y, char element, int rightLIMIT)
        {
            if ((rightLIMIT < n) && (element.Equals(rotatedArray[y, rightLIMIT])))
            {
                for (int i = x + 1; i < rightLIMIT; i++)
                {
                    if (!element.Equals(rotatedArray[y, i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        static bool checkDirectionUP_RIGHT(int x, int y, char element, int upLIMIT, int rightLIMIT)
        {
            if ( rightLIMIT < n && upLIMIT >= 0 && element.Equals(rotatedArray[upLIMIT, rightLIMIT]) )
            {
                for (int i = y - 1, j = x + 1; i >= upLIMIT; i--, j++)
                {
                    if (!element.Equals(rotatedArray[i, j]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        static bool checkDirectionUP(int x, int y, char element, int upLIMIT)
        {
            if ((upLIMIT >= 0) && (element.Equals(rotatedArray[upLIMIT, x])))
            {
                for (int i = y - 1; i > upLIMIT; i--)
                {
                    if (!element.Equals(rotatedArray[i, x]))
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        static bool checkDirectionUP_LEFT(int x, int y, char element, int upLIMIT)
        {
            int leftLIMIT = x - k + 1;

            if ((leftLIMIT >= 0) && (upLIMIT >= 0) && (element.Equals(rotatedArray[upLIMIT, leftLIMIT])))
            {
                for (int i = y - 1, j = x - 1; i >= upLIMIT; i--, j--)
                {
                    if (!element.Equals(rotatedArray[i, j]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}

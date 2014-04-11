using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pA
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();
            char[,] targets = new char[10, 4];

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-attempt0.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    string line1 = inputFile.ReadLine();
                    string line2 = inputFile.ReadLine();
                    string line3 = inputFile.ReadLine();
                    string line4 = inputFile.ReadLine();
                    inputFile.ReadLine();

                    targets = null;
                    targets = new char[10, 4];

                    targets[0, 0] = line1[0];
                    targets[0, 1] = line1[1];
                    targets[0, 2] = line1[2];
                    targets[0, 3] = line1[3];

                    targets[1, 0] = line2[0];
                    targets[1, 1] = line2[1];
                    targets[1, 2] = line2[2];
                    targets[1, 3] = line2[3];

                    targets[2, 0] = line3[0];
                    targets[2, 1] = line3[1];
                    targets[2, 2] = line3[2];
                    targets[2, 3] = line3[3];

                    targets[3, 0] = line4[0];
                    targets[3, 1] = line4[1];
                    targets[3, 2] = line4[2];
                    targets[3, 3] = line4[3];

                    targets[4, 0] = line1[0];
                    targets[4, 1] = line2[0];
                    targets[4, 2] = line3[0];
                    targets[4, 3] = line4[0];

                    targets[5, 0] = line1[1];
                    targets[5, 1] = line2[1];
                    targets[5, 2] = line3[1];
                    targets[5, 3] = line4[1];

                    targets[6, 0] = line1[2];
                    targets[6, 1] = line2[2];
                    targets[6, 2] = line3[2];
                    targets[6, 3] = line4[2];

                    targets[7, 0] = line1[3];
                    targets[7, 1] = line2[3];
                    targets[7, 2] = line3[3];
                    targets[7, 3] = line4[3];

                    targets[8, 0] = line1[0];
                    targets[8, 1] = line2[1];
                    targets[8, 2] = line3[2];
                    targets[8, 3] = line4[3];

                    targets[9, 0] = line1[3];
                    targets[9, 1] = line2[2];
                    targets[9, 2] = line3[1];
                    targets[9, 3] = line4[0];


                    bool isSolved = false;
                    for (int j = 0; j < 10; j++)
                    {
                        int countOfX = 0;
                        int countOfO = 0;
                        int countOfT = 0;

                        for (int k = 0; k < 4; k++)
                        {
                            char currentChar = targets[j, k];
                            if ('X'.Equals(currentChar))
                            {
                                countOfX++;
                            }
                            else if ('O'.Equals(currentChar))
                            {
                                countOfO++;
                            }
                            else if ('T'.Equals(currentChar))
                            {
                                countOfT++;
                            }
                        }

                        if ((4 == countOfX) || ((3 == countOfX) && (1 == countOfT)))
                        {
                            results.Add("X won");
                            isSolved = true;
                            break;
                        }
                        else if ((4 == countOfO) || ((3 == countOfO) && (1 == countOfT)))
                        {
                            results.Add("O won");
                            isSolved = true;
                            break;
                        }
                    }

                    if (!isSolved)
                    {
                        bool isEnded = ((line1.Contains<char>('.')) || (line2.Contains<char>('.')) || (line3.Contains<char>('.')) || (line4.Contains<char>('.')));

                        if (isEnded)
                        {
                            results.Add("Game has not completed");
                        }
                        else
                        {
                            results.Add("Draw");
                        }
                    }
                }
            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-attempt0.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large.out"))
            {
                //Console.WriteLine(numberOfIntersectionPoints);
                int i = 1;
                foreach (string result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }
    }
}

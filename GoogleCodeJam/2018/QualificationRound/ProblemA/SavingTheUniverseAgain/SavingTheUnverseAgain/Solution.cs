using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SavingTheUnverseAgain
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            using (StreamReader inputFile = new StreamReader(@"..\..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    string[] input = inputFile.ReadLine().Split(' ');
                    int maximumDamage = Convert.ToInt32(input[0]);
                    string instructions = input[1];

                    int countOfShoots = 0;
                    foreach (char shootingChar in instructions)
                    {
                        if (shootingChar == 'S')
                        {
                            countOfShoots++;
                        }
                    }
                    if (countOfShoots > maximumDamage)
                    {
                        results.Add("IMPOSSIBLE");
                        continue;
                    }

                    int totalNumberOfHacks = 0;
                    while (currentDamage(instructions) > maximumDamage )
                    {
                        StringBuilder currentInstructions = new StringBuilder(instructions);
                        for (int i = instructions.Length - 1; i > 0; i--)
                        {
                            if (instructions[i] == 'S' && instructions[i - 1] == 'C')
                            {
                                currentInstructions[i] = 'C';
                                currentInstructions[i - 1] = 'S';
                                totalNumberOfHacks++;
                                instructions = currentInstructions.ToString();
                                break;
                            }
                        }
                    }
                    results.Add(totalNumberOfHacks.ToString());

                }
            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\..\outputs\A-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\..\outputs\A-large-practice.out"))
            {

                int i = 1;
                foreach (string result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        static int currentDamage(string instructions)
        {
            int currentPower = 1;
            int totalDamage = 0;

            foreach (char command in instructions)
            {
                if (command == 'S')
                {
                    totalDamage += currentPower;
                }
                else if (command == 'C')
                {
                    currentPower *= 2;
                }
                else
                {
                    throw new InvalidDataException("Encountered char " + command);
                }
            }
            return totalDamage;
        }

    }
}

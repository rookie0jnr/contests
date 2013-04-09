using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileFix_it
{
    class Solution
    {
        static void Main(string[] args)
        {
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    string[] numberOfDirectories = inputFile.ReadLine().Split(' ');
                    int numberOfExistingDirectories = Convert.ToInt32(numberOfDirectories[0]);
                    int numberOfDirectoriesToCreate = Convert.ToInt32(numberOfDirectories[1]);

                    List<List<string>> existingDirectories = new List<List<string>>();
                    for (int i = 0; i < numberOfExistingDirectories; i++)
                    {
                        string fullPathOfExistingDirectory = inputFile.ReadLine();
                        string[] existingSubDirectories = fullPathOfExistingDirectory.Split('/');

                        int numberOfExistingSubDirectories = existingSubDirectories.Length;

                        // check if we have created all the necessary directory levels as Lists in the main List 'existingDirectories'
                        // if we don't have all the needed levels, add them now
                        if (existingDirectories.Count < numberOfExistingSubDirectories)
                        {
                            int numberOfNeededExistingDirectoryLevels = numberOfExistingSubDirectories - existingDirectories.Count;
                            for (int j = 0; j < numberOfNeededExistingDirectoryLevels; j++)
                            {
                                existingDirectories.Add(new List<string>());
                            }
                        }

                        for (int j = 0; j < numberOfExistingSubDirectories; j++)
                        {
                            if (!existingDirectories[j].Contains(existingSubDirectories[j]))
                            {
                                existingDirectories[j].Add(existingSubDirectories[j]);
                            }
                        }
                    }

                    for (int i = 0; i < numberOfDirectoriesToCreate; i++)
                    {
                        string fullPathOfDirectoryToCreate = inputFile.ReadLine();
                        string[] subDirectoriesToCreate = fullPathOfDirectoryToCreate.Split('/');

                        int numberOfSubDirectoriesToCreate = subDirectoriesToCreate.Length;

                        for (int j = 0; j < numberOfDirectoriesToCreate; j++)
                        {
                            if (j < existingDirectories.Count)
                            {
 
                            }
                        }
                    }

                    int p = 5;
                }

            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            {
                //Console.WriteLine(numberOfIntersectionPoints);
                //outputFile.WriteLine("Case #{0}: {1}", i++, result);
            }
        }
    }
}

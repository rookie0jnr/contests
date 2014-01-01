using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileFix_it
{
    class Solution
    {
        static void Main_Version1(string[] args)
        {
            List<int> results = new List<int>();
            
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
                        fullPathOfExistingDirectory = fullPathOfExistingDirectory.Substring(1);

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

                    List<List<string>> existingAndCreatedDirectories = new List<List<string>>(existingDirectories);
                    int numberOfmkdirs = 0;
                    for (int i = 0; i < numberOfDirectoriesToCreate; i++)
                    {
                        
                        int existingAndCreatedDirectoriesCount = existingAndCreatedDirectories.Count;
                        string fullPathOfDirectoryToCreate = inputFile.ReadLine();
                        fullPathOfDirectoryToCreate = fullPathOfDirectoryToCreate.Substring(1);
                        string[] subDirectoriesToCreate = fullPathOfDirectoryToCreate.Split('/');

                        int numberOfSubDirectoriesToCreate = subDirectoriesToCreate.Length;

                        for (int j = 0; j < numberOfSubDirectoriesToCreate; j++)
                        {
                            if (j < existingAndCreatedDirectoriesCount)
                            {
                                if (!existingAndCreatedDirectories[j].Contains(subDirectoriesToCreate[j]))
                                {
                                    existingAndCreatedDirectories[j].Add(subDirectoriesToCreate[j]);
                                    numberOfmkdirs++;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < (numberOfSubDirectoriesToCreate - j); k++)
                                {
                                    List<string> currentSubDirectory = new List<string>();
                                    currentSubDirectory.Add(subDirectoriesToCreate[j + k]);
                                    existingAndCreatedDirectories.Add(currentSubDirectory);
                                    numberOfmkdirs++;
                                }
                                break;
                            }
                        }
                    }
                    results.Add(numberOfmkdirs);

                    int p = 5;
                }

            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            {

                int i = 1;
                foreach (int result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> results = new List<int>();

            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-practice.in"))
            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    string[] numberOfDirectories = inputFile.ReadLine().Split(' ');
                    int numberOfExistingDirectories = Convert.ToInt32(numberOfDirectories[0]);
                    int numberOfDirectoriesToCreate = Convert.ToInt32(numberOfDirectories[1]);

                    Folder root = new Folder("root");

                    for (int i = 0; i < numberOfExistingDirectories; i++)
                    {
                        Folder currentFolder = root;

                        string fullPathOfExistingDirectory = inputFile.ReadLine();
                        fullPathOfExistingDirectory = fullPathOfExistingDirectory.Substring(1);

                        string[] existingSubDirectories = fullPathOfExistingDirectory.Split('/');
                        int numberOfExistingSubDirectories = existingSubDirectories.Length;

                        for (int j = 0; j < numberOfExistingSubDirectories; j++)
                        {
                            string currentSubFolder = existingSubDirectories[j];

                            Folder targetFolder = currentFolder.subFolders.Where(x => x.folderName.Equals(currentSubFolder)).FirstOrDefault();

                            if (null == targetFolder)
                            {
                                targetFolder = new Folder(currentSubFolder);
                                currentFolder.subFolders.Add(targetFolder);
                            }

                            currentFolder = targetFolder;
                        }
                    }

                    // directories to create
                    int numberOfmkdirs = 0;
                    for (int i = 0; i < numberOfDirectoriesToCreate; i++)
                    {
                        Folder currentFolder = root;

                        string fullPathOfDirectoryToCreate = inputFile.ReadLine();
                        fullPathOfDirectoryToCreate = fullPathOfDirectoryToCreate.Substring(1);
                        string[] subDirectoriesToCreate = fullPathOfDirectoryToCreate.Split('/');

                        int numberOfSubDirectoriesToCreate = subDirectoriesToCreate.Length;

                        for (int j = 0; j < numberOfSubDirectoriesToCreate; j++)
                        {
                            string currentSubFolder = subDirectoriesToCreate[j];

                            Folder targetFolder = currentFolder.subFolders.Where(x => x.folderName.Equals(currentSubFolder)).FirstOrDefault();

                            if (null == targetFolder)
                            {
                                targetFolder = new Folder(currentSubFolder);
                                currentFolder.subFolders.Add(targetFolder);
                                numberOfmkdirs++;
                            }

                            currentFolder = targetFolder;
                        }
                    }
                    results.Add(numberOfmkdirs);
                }

            }

            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-practice.out"))
            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-large-practice.out"))
            {

                int i = 1;
                foreach (int result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }
    }

    class Folder
    {

        public string folderName;

        public List<Folder> subFolders;

        public Folder(string name)
        {
            this.folderName = name;
            subFolders = new List<Folder>();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWords
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<int> results = new List<int>();

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\B-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\B-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\B-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());

                for (int l = 0; l < numberOfTestCases; l++)
                {
                    string[] numberOfDirectories = inputFile.ReadLine().Split(' ');
                    int numberOfExistingDirectories = Convert.ToInt32(numberOfDirectories[0]);
                    int numberOfDirectoriesToCreate = Convert.ToInt32(numberOfDirectories[1]);
                }

            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\B-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\B-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\B-large-practice.out"))
            {

                int i = 1;
                foreach (int result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }
    }
}

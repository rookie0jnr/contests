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

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-small-attempt1.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\A-large.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    int answer1 = Convert.ToInt32(inputFile.ReadLine());
                    string[] rows1 = new string[4];
                    rows1[0] = inputFile.ReadLine();
                    rows1[1] = inputFile.ReadLine();
                    rows1[2] = inputFile.ReadLine();
                    rows1[3] = inputFile.ReadLine();

                    List<int> targetRow1Numbers = new List<int>();
                    string[] targetRow1 = rows1[answer1 - 1].Split(' ');
                    foreach (string number in targetRow1)
                    {
                        targetRow1Numbers.Add(Convert.ToInt32(number));
                    }


                    int answer2 = Convert.ToInt32(inputFile.ReadLine());
                    string[] rows2 = new string[4];
                    rows2[0] = inputFile.ReadLine();
                    rows2[1] = inputFile.ReadLine();
                    rows2[2] = inputFile.ReadLine();
                    rows2[3] = inputFile.ReadLine();

                    List<int> targetRow2Numbers = new List<int>();
                    string[] targetRow2 = rows2[answer2 - 1].Split(' ');
                    foreach (string number in targetRow2)
                    {
                        targetRow2Numbers.Add(Convert.ToInt32(number));
                    }

                    List<int> result = targetRow1Numbers.Intersect(targetRow2Numbers).ToList<int>();

                    if (1 == result.Count)
                    {
                        results.Add(result.FirstOrDefault().ToString());
                    }
                    else if (result.Count > 1)
                    {
                        results.Add("Bad magician!");
                    }
                    else
                    {
                        results.Add("Volunteer cheated!");
                    }

                }
            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\A-small-attempt1.out"))
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

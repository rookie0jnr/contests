using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treasure
{
    class Solution
    {
        static void Main(string[] args)
        {
            List<ulong> results = new List<ulong>();

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\D-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\D-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\D-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {



                    //results.Add(numberOfFairs);
                }
            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\D-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\D-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\D-large-practice.out"))
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

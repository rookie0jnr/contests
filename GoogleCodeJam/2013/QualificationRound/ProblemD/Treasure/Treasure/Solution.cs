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
        static List<string> foundPath = new List<string>();

        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            using (StreamReader inputFile = new StreamReader(@"..\..\inputs\D-example-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\D-small-practice.in"))
            //using (StreamReader inputFile = new StreamReader(@"..\..\inputs\D-large-practice.in"))
            {
                int numberOfTestCases = Convert.ToInt32(inputFile.ReadLine());
                for (int i = 0; i < numberOfTestCases; i++)
                {
                    foundPath.Clear();

                    uint chestsToOpenCount = Convert.ToUInt32(inputFile.ReadLine().Split(' ')[1]);
                    List<Chest> chestsToOpen = new List<Chest>();

                    List<uint> availableKeys = Array.ConvertAll(inputFile.ReadLine().Split(' '), Convert.ToUInt32).ToList<uint>();
                    for (uint j = 0; j < chestsToOpenCount; j++ )
                    {
                        string[] chestInfo = inputFile.ReadLine().Split(' ');
                        uint keyForThisChest = Convert.ToUInt32(chestInfo[0]);
                        uint numberOfKeysInsideChest = Convert.ToUInt32(chestInfo[1]);

                        List<uint> keysInsideThisChest = new List<uint>();
                        for (int k = 0; k < numberOfKeysInsideChest; k++)
                        {
                            keysInsideThisChest.Add(Convert.ToUInt32(chestInfo[2 + k]));
                        }

                        chestsToOpen.Add(new Chest(j + 1, keyForThisChest, keysInsideThisChest));
                    }

                    // There is the actual solution, by invoking tryOpenAChest for the first time
                    // If it returns false - this means that it is not possible to open all chests
                    // If it returns true then we just - add the foundPath to results
                    if (!tryOpenAChest(availableKeys, chestsToOpen))
                    {
                        results.Add("IMPOSSIBLE");
                    }
                    else
                    {

                        results.Add(String.Join(" ", foundPath));
                        //string resultPath = string.Empty;
                        //foreach (string chestNumber in foundPath)
                        //{
                        //    resultPath += chestNumber;
                        //}

                        //results.Add(resultPath);
                    }
                }
            }

            using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\D-example-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\D-small-practice.out"))
            //using (StreamWriter outputFile = new StreamWriter(@"..\..\outputs\D-large-practice.out"))
            {
                int i = 1;
                foreach (string result in results)
                {
                    outputFile.WriteLine("Case #{0}: {1}", i++, result);
                }
            }
        }

        private static bool tryOpenAChest(List<uint> currentlyAvailableKeys, List<Chest> remainingChestsToOpen)
        {
            if (0.Equals(remainingChestsToOpen.Count))
            {
                return true;
            }

            //bool isSolutionFound = false;
            for (int i = 0; i < remainingChestsToOpen.Count; i++)
            {
                uint keyForChest = remainingChestsToOpen[i].requiredKey;
                if (currentlyAvailableKeys.Contains<uint>(keyForChest))
                {
                    currentlyAvailableKeys.Remove(keyForChest);
                    foreach (uint key in remainingChestsToOpen[i].availableKeys)
                    {
                        currentlyAvailableKeys.Add(key);
                    }
                    foundPath.Add(remainingChestsToOpen[i].chestNumber.ToString());
                    remainingChestsToOpen.RemoveAt(i);
                    i--;


                    if (!tryOpenAChest(currentlyAvailableKeys, remainingChestsToOpen))
                    {
                        foundPath.RemoveAt(foundPath.Count - 1);
                    }
                    else
                    {
                        //isSolutionFound = true;
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public class Chest
    {
        public uint chestNumber;
        public uint requiredKey;
        public List<uint> availableKeys;

        public Chest(uint chestNumber, uint requiredKeyNumber, List<uint> keysInside)
        {
            this.chestNumber = chestNumber;
            this.requiredKey = requiredKeyNumber;
            this.availableKeys = keysInside;
        }
    }
}

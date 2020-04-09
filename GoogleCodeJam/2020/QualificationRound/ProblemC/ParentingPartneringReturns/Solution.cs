using System;
using System.Collections.Generic;
using System.Linq;

namespace ParentingPartneringReturns
{
    class Solution
    {
        static int[] cameronAvailabilty;
        static int[] jamieAvailabilty;

        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();
            Dictionary<int, List<List<int>>> inputs = new Dictionary<int, List<List<int>>>();

            for (int i = 0; i < testCases; i++)
            {
                int activitiesCount = Convert.ToInt32(Console.ReadLine());
                List<List<int>> current = new List<List<int>>();
                
                for (int j = 0; j < activitiesCount; j++)
                {
                    string[] times = Console.ReadLine().Split(' ');
                    List<int> currentActivity = times.Select(n => Convert.ToInt32(n)).ToList();
                    currentActivity.Add(j);
                    current.Add(currentActivity);
                }
                inputs.Add(i, current);
            }

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";
                cameronAvailabilty = new int[1440];
                jamieAvailabilty = new int[1440];
                

                var currentActivitiesList = inputs[i];
                int activitiesCount = currentActivitiesList.Count;
                char[] result = new char[activitiesCount];
                var sorted = currentActivitiesList
                    .OrderBy(st => st[0])
                    .ToList();

                for (int j = 0; j < activitiesCount; j++)
                {
                    int activityStart = sorted[j][0];
                    int activityEnd = sorted[j][1];

                    if (CameronAvailable(activityStart, activityEnd))
                    {
                        for (int k = activityStart; k < activityEnd; k++)
                        {
                            cameronAvailabilty[k] = 1;
                            continue;
                        }
                        result[sorted[j][2]] = 'C';
                    }
                    else if (JamieAvailable(activityStart, activityEnd))
                    {
                        for (int k = activityStart; k < activityEnd; k++)
                        {
                            jamieAvailabilty[k] = 1;
                            continue;
                        }
                        result[sorted[j][2]] = 'J'; 
                    }
                    else
                    {
                        currentTestResult = "Case #" + (i + 1) + ": IMPOSSIBLE";
                        break;
                    }

                }

                if (!currentTestResult.Contains("IMPOSSIBLE"))
                {
                    results.Add(currentTestResult + new string(result));
                }
                else
                {
                    results.Add(currentTestResult);
                }
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

        static bool CameronAvailable(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (cameronAvailabilty[i] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        static bool JamieAvailable(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (jamieAvailabilty[i] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

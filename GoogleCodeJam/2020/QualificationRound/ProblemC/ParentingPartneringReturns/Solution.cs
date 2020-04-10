using System;
using System.Collections.Generic;
using System.Linq;

namespace ParentingPartneringReturns
{
    class Solution
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();
            Dictionary<int, List<List<int>>> inputs = new Dictionary<int, List<List<int>>>();

            // Getting all the input
            for (int i = 0; i < testCases; i++)
            {
                int activitiesCount = Convert.ToInt32(Console.ReadLine());
                List<List<int>> activitiesForATestCase = new List<List<int>>();
                
                for (int j = 0; j < activitiesCount; j++)
                {
                    string[] activitiesTimes = Console.ReadLine().Split(' ');
                    List<int> currentActivity = 
                        activitiesTimes
                        .Select(n => Convert.ToInt32(n))
                        .ToList();

                    currentActivity.Add(j);
                    activitiesForATestCase.Add(currentActivity);
                }
                inputs.Add(i, activitiesForATestCase);
            }

            // Solve
            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";
                
                var currentActivitiesList = inputs[i];
                int activitiesCount = currentActivitiesList.Count;
                char[] result = new char[activitiesCount];
                var activitiesSortedByStartTime = currentActivitiesList
                    .OrderBy(st => st[0])
                    .ToList();

                int cameronAvailableFrom = 0;
                int jamieAvailableFrom = 0;
                for (int j = 0; j < activitiesCount; j++)
                {
                    int activityStart = activitiesSortedByStartTime[j][0];
                    int activityEnd = activitiesSortedByStartTime[j][1];

                    // If Cameron is available - assign it to her
                    // and adjust its "available from" time
                    if (cameronAvailableFrom <= activityStart)
                    {
                        cameronAvailableFrom = activityEnd;
                        result[activitiesSortedByStartTime[j][2]] = 'C';
                    }
                    else if (jamieAvailableFrom <= activityStart)
                    {
                        jamieAvailableFrom = activityEnd;
                        result[activitiesSortedByStartTime[j][2]] = 'J'; 
                    }
                    else
                    {
                        result = "IMPOSSIBLE".ToCharArray();
                        break;
                    }
                }

                results.Add(currentTestResult + new string(result));
            }

            // Writing results
            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

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
            Dictionary<int, List<string>> inputs = new Dictionary<int, List<string>>();

            for (int i = 0; i < testCases; i++)
            {
                int activitiesCount = Convert.ToInt32(Console.ReadLine());
                List<string> current = new List<string>();

                for (int j = 0; j < activitiesCount; j++)
                {
                    current.Add(Console.ReadLine());
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
                var sorted = currentActivitiesList
                    .OrderBy(st => Convert.ToInt32(st.Split(' ')[0]))
                    .ToList();

                for (int j = 0; j < activitiesCount; j++)
                {
                    var activity = sorted[j].Split(' ');
                    int activityStart = Convert.ToInt32(activity[0]);
                    int activityEnd = Convert.ToInt32(activity[1]);

                    if (CameronAvailable(activityStart, activityEnd))
                    {
                        for (int k = activityStart; k < activityEnd; k++)
                        {
                            cameronAvailabilty[k] = 1;
                            continue;
                        }
                        currentTestResult += "C";
                    }
                    else if (JamieAvailable(activityStart, activityEnd))
                    {
                        for (int k = activityStart; k < activityEnd; k++)
                        {
                            jamieAvailabilty[k] = 1;
                            continue;
                        }
                        currentTestResult += "J";
                    }
                    else
                    {
                        currentTestResult = "Case #" + (i + 1) + ": IMPOSSIBLE";
                        break;
                    }

                }

                results.Add(currentTestResult);
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

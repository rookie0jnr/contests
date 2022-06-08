namespace Parenting
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            string[] results = new string[testCases];

            for (int tc = 0; tc < testCases; tc++)
            {
                int CameronSTime = 0;
                int JamieSTime = 0;
                List<(int startTime, int endTime, int originalIndex)> allActivities =
                    new List<(int, int, int)>();

                int activities = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < activities; i++)
                {
                    int[] activity = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                    allActivities.Add((activity[0], activity[1], i));
                }

                allActivities.Sort();
                char[] result = new char[allActivities.Count];
                for (int i = 0; i < allActivities.Count; i++)
                {
                    var currentActivity = allActivities[i];
                    if (CameronSTime > currentActivity.startTime && JamieSTime > currentActivity.startTime)
                    {
                        result = "IMPOSSIBLE".ToCharArray();
                        break;
                    }
                    else
                    {
                        if (CameronSTime <= currentActivity.startTime)
                        {
                            CameronSTime = currentActivity.endTime;
                            result[currentActivity.originalIndex] = 'C';
                        }
                        else
                        {
                            JamieSTime = currentActivity.endTime;
                            result[currentActivity.originalIndex] = 'J';
                        }
                    }
                }

                results[tc] = $"Case #{tc + 1}: {new string(result)}";
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}

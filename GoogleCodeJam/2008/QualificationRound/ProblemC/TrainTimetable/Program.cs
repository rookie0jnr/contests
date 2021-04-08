using System;
using System.Collections.Generic;

namespace TrainTimetable
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());

            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";

                TimeSpan T = new TimeSpan(0, Convert.ToInt32(Console.ReadLine()), 0);
                var NANB = Console.ReadLine().Split(' ');
                int NA = Convert.ToInt32(NANB[0]);
                int NB = Convert.ToInt32(NANB[1]);
                List<Tuple<TimeSpan, TimeSpan, string>> allTrips = new List<Tuple<TimeSpan, TimeSpan, string>>();

                string currentTrip;

                for (int j = 0; j < NA; j++)
                {
                    currentTrip = Console.ReadLine();
                    var startEnd = currentTrip.Split(' ');

                    Tuple<TimeSpan, TimeSpan, string> trip =
                        new Tuple<TimeSpan, TimeSpan, string>
                        (
                            new TimeSpan(Convert.ToInt32(startEnd[0].Split(':')[0]), Convert.ToInt32(startEnd[0].Split(':')[1]),0),
                            new TimeSpan(Convert.ToInt32(startEnd[1].Split(':')[0]), Convert.ToInt32(startEnd[1].Split(':')[1]), 0),
                            "A"                          
                        );
                    allTrips.Add(trip);
                }

                for (int j = 0; j < NB; j++)
                {
                    currentTrip = Console.ReadLine();
                    var startEnd = currentTrip.Split(' ');

                    Tuple<TimeSpan, TimeSpan, string> trip =
                        new Tuple<TimeSpan, TimeSpan, string>
                        (
                            new TimeSpan(Convert.ToInt32(startEnd[0].Split(':')[0]), Convert.ToInt32(startEnd[0].Split(':')[1]), 0),
                            new TimeSpan(Convert.ToInt32(startEnd[1].Split(':')[0]), Convert.ToInt32(startEnd[1].Split(':')[1]), 0),
                            "B"
                        );
                    allTrips.Add(trip);
                }


                //currentTestResult += switches;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

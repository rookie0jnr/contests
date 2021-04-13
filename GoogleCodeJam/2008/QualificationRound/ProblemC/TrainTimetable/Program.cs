using System;
using System.Collections.Generic;
using System.Linq;

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

                TimeSpan T = TimeSpan.FromMinutes(Convert.ToDouble(Console.ReadLine()));
                var NAandNB = Console.ReadLine().Split(' ');
                int NA = Convert.ToInt32(NAandNB[0]);
                int NB = Convert.ToInt32(NAandNB[1]);
                List<Tuple<TimeSpan, TimeSpan, string>> allTrips = new List<Tuple<TimeSpan, TimeSpan, string>>();

                string currentTrip;

                for (int j = 0; j < NA; j++)
                {
                    currentTrip = Console.ReadLine();
                    var startEnd = currentTrip.Split(' ');

                    Tuple<TimeSpan, TimeSpan, string> trip =
                        new Tuple<TimeSpan, TimeSpan, string>
                        (
                            new TimeSpan(Convert.ToInt32(startEnd[0].Split(':')[0]), Convert.ToInt32(startEnd[0].Split(':')[1]), 0),
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

                allTrips.Sort();

                List<TimeSpan> trainsFromA = new List<TimeSpan>();
                List<TimeSpan> trainsFromB = new List<TimeSpan>();
                int neededTrainsFromA = 0;
                int neededTrainsFromB = 0;

                for (int j = 0; j < allTrips.Count; j++)
                {
                    TimeSpan currentArrivalTimePlusTurnaround = allTrips[j].Item2 + T;
                    if (allTrips[j].Item3.Equals("A"))
                    {
                        var toReuse = trainsFromA.Where(train => train <= allTrips[j].Item1);
                        if (toReuse.Count() > 0)
                        {
                            trainsFromA.Remove(toReuse.First());
                            allTrips.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            neededTrainsFromA++;
                        }
                        trainsFromB.Add(currentArrivalTimePlusTurnaround);
                    }
                    else
                    {
                        var toReuse = trainsFromB.Where(train => train <= allTrips[j].Item1);
                        if (toReuse.Count() > 0)
                        {
                            trainsFromB.Remove(toReuse.First());
                            allTrips.RemoveAt(j);
                            j--;
                        }
                        else
                        {
                            neededTrainsFromB++;
                        }
                        trainsFromA.Add(currentArrivalTimePlusTurnaround);
                    }
                }

                currentTestResult += $"{neededTrainsFromA} {neededTrainsFromB}";
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}

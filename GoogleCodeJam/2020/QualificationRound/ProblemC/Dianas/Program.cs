
namespace Parenting

{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < testCases; t++)
            {
                int CameronSTime = 0;
                int JamieSTime = 0;
                List<Tuple<int, int, int>> listTuples = new List<Tuple<int, int, int>>();

                int activities = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < activities; i++)
                {
                    int[] line = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                    listTuples.Add(new Tuple<int, int, int>(line[0], line[1], i));
                }
                listTuples.Sort();
                string[] parents = new string[listTuples.Count];
                for (int i = 0; i < listTuples.Count; i++)
                {
                    if (CameronSTime > listTuples[i].Item1 && JamieSTime > listTuples[i].Item1)
                    {
                        parents = new string[] { "IMPOSSIBLE" };
                        break;
                    }
                    else
                    {
                      //  if (CameronStartTime <= listTuples[i].Item1 || JamieStartTime <= listTuples[i].Item1)
                        {
                            if (CameronSTime <= listTuples[i].Item1) // == Math.Min(CameronStartTime, JamieStartTime))
                            {
                                CameronSTime = listTuples[i].Item2;
                                parents[listTuples[i].Item3] = "C";
                            }
                            else
                            {
                                JamieSTime = listTuples[i].Item2;
                                parents[listTuples[i].Item3] = "J";
                            }
                        }
                    }
                }
                if (parents == null)
                {
                    Console.WriteLine("Case #" + (t + 1) + ": IMPOSSIBLE");
                }
                else
                {
                    Console.Write("Case #" + (t + 1) + ": ");
                    for (int i = 0; i < parents.Length; i++)
                    {
                        Console.Write(parents[i]);
                    }
                    if (t < testCases - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

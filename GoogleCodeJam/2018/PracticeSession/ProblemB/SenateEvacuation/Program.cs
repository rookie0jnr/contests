using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SenateEvacuation
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int tcIndex = 0; tcIndex < testCases; tcIndex++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                int[] senatorsRaw = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
                SortedSet<(int numberOfSenators, string partyName)> senators =
                    new SortedSet<(int numberOfSenators, string partyName)>();

                char partyName = 'A';
                for (int i = 0; i < senatorsRaw.Length; i++)
                {
                    senators.Add((senatorsRaw[i], partyName.ToString()));
                    partyName++;
                }


                int totalSenators = senatorsRaw.Sum();
                string currentTestResult = $"Case #{tcIndex + 1}: ";

                while (senators.Count > 0)
                {
                    // Can I remove 2 from the largest group?
                    int largestGroup = senators.ElementAt(senators.Count - 1).numberOfSenators;
                    int secondGroup = senators.ElementAt(senators.Count - 2).numberOfSenators;
                    int halfSenators = (totalSenators - 2) / 2;
                    
                    if (largestGroup - 2 <= halfSenators
                        && secondGroup <= halfSenators)
                    {
                        var largest = senators.ElementAt(senators.Count - 1);
                        senators.Remove(largest);
                        largest.numberOfSenators -= 2;
                        senators.Add(largest);

                        totalSenators -= 2;
                        currentTestResult += $"{largest.partyName}{largest.partyName} ";
                    }
                    // Can I remove 1 from the 2 biggest groups?
                    else if (senators.Count > 2
                        && (largestGroup - 1 <= halfSenators
                        && secondGroup - 1 <= halfSenators
                        && senators.ElementAt(senators.Count - 3).numberOfSenators <= halfSenators))
                    {
                        var second = senators.ElementAt(senators.Count - 2);
                        senators.Remove(second);
                        second.numberOfSenators--;
                        senators.Add(second);

                        var largest = senators.ElementAt(senators.Count - 1);
                        senators.Remove(largest);
                        largest.numberOfSenators--;
                        senators.Add(largest);


                        totalSenators -= 2;
                        currentTestResult += $"{largest.partyName}{second.partyName} ";

                    }
                    else if ( senators.Count == 2 
                        && (largestGroup - 1 <= halfSenators
                        && secondGroup - 1 <= halfSenators))
                    {
                        var second = senators.ElementAt(senators.Count - 2);
                        senators.Remove(second);
                        second.numberOfSenators--;
                        senators.Add(second);

                        var largest = senators.ElementAt(senators.Count - 1);
                        senators.Remove(largest);
                        largest.numberOfSenators--;
                        senators.Add(largest);


                        totalSenators -= 2;
                        currentTestResult += $"{largest.partyName}{second.partyName} ";
                    }

                    // I can remove only 1 from the largest group!
                    else
                    {
                        var largest = senators.ElementAt(senators.Count - 1);
                        senators.Remove(largest);
                        largest.numberOfSenators--;
                        senators.Add(largest);

                        totalSenators -= 1;
                        currentTestResult += $"{largest.partyName} ";
                    }

                    for (int i = 0; i < senators.Count; i++)
                    {
                        if (senators.ElementAt(i).numberOfSenators == 0)
                        {
                            senators.Remove(senators.ElementAt(i));
                            i--;
                        }
                    }
                }

                //currentTestResult += (D / times.Max()).ToString("F6");
                results.Add(currentTestResult);
            }

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
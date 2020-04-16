using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Cryptopangrams
{
    class Solution
    {
        private static List<int> primes;
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();
            List<Tuple<int, string>> inputs = new List<Tuple<int, string>>();

            // Getting all the input
            for (int i = 0; i < testCases; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine().Split(' ')[0]);
                inputs.Add(Tuple.Create(N, Console.ReadLine()));
            }

            primes = new List<int>();
            primes.Add(2);
            primes.Add(3);
            primes.Add(5);
            primes.Add(7);

            // Solve
            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = "Case #" + (i + 1) + ": ";
                var currentInput = inputs[i];
                var currentNumbersWithIndex = currentInput.Item2.Split(' ')
                    .Select(num => Convert.ToInt32(num))
                    .Select((n, i) => new { Value = n, Index = i })
                    .ToDictionary(o => o.Index, o => o.Value);
                //.Select((i, n) => new { Index = i, Number = n }).ToDictionary(key => key.Index, number => number.Number);
                var currentNumbers = currentNumbersWithIndex.Values.ToList();
                currentNumbers.Sort();
                int largestHalf = currentNumbers[currentNumbers.Count - 1] / 2;

                int largestPrimeIndex = FindIndexOfPrimesUpTo(largestHalf);
                List<int> usedPrimes = new List<int>();
                foreach (var item in currentNumbers)
                {
                    foreach (var item2 in primes)
                    {
                        if (item % item2 == 0)
                        {
                            if (!usedPrimes.Contains(item2))
                            {
                                usedPrimes.Add(item2);
                            }
                            if (!usedPrimes.Contains(item / item2))
                            {
                                usedPrimes.Add(item / item2);
                            }
                        }
                    }
                }

                results.Add(currentTestResult);
            }

            // Writing results
            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

        private static int FindIndexOfPrimesUpTo(int largestHalf)
        {
            if (largestHalf > primes[primes.Count - 1])
            {
                while (primes[primes.Count - 1] < largestHalf)
                {
                    int currentPrime = primes[primes.Count - 1];
                    primes.Add(NextPrime(currentPrime));
                }
                return primes.Count - 2;
            }
            else
            {
                for (int p = 0; p < primes.Count; p++)
                {
                    if (primes[p] > largestHalf)
                    {
                        return p - 1;
                    }
                }
            }

            return -1;
        }

        private static int NextPrime(int currentPrime)
        {
            bool isPrime = false;
            int nextPrime = currentPrime;
            while (!isPrime)
            {
                nextPrime += 2;
                isPrime = true;
                for (int i = 0; i < primes.Count; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            return nextPrime;
            
        }
    }
}

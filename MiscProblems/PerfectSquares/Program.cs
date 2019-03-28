using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PerfectSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task:
            // Find all numbers with the following properties lower than 1,000,000:
            // If we add 1 to it, we get a "perfect squre", i.e. a number whose square root is a whole number
            // If we divide this number by 2 and add 1, the resulting number is also a perfect square
            // An example number is 48; 48 + 1 = 49 = 7.7; 48:2 + 1 = 24 + 1 = 25 = 5.5

            //FindNumbersBruteForce();
            FindNumbersApproach2();
        }

        private static void FindNumbersApproach2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int currentSquare = 1;
            int currentNumber = 2;
            List<int> perfectSquares = new List<int>();
            while (currentSquare < 1000000)
            {
                currentSquare = currentNumber * currentNumber;
                perfectSquares.Add(currentSquare);
                currentNumber++;
            }
            foreach (int lowerNumber in perfectSquares)
            {
                int targetNumber = (lowerNumber - 1) * 2;

                if (perfectSquares.Contains(targetNumber + 1))
                {
                    Console.WriteLine("Found " + targetNumber);
                }
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }


        private static void FindNumbersBruteForce()
        {
            int targetNumber = 2;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (targetNumber < 1000000)
            {
                if (IsPerfectSquare(targetNumber + 1))
                {
                    if (IsPerfectSquare((targetNumber / 2) + 1))
                    {
                        Console.WriteLine("Found " + targetNumber);
                    }
                }

                targetNumber++;
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private static bool IsPerfectSquare(int number)
        {
            double squareRoot = Math.Sqrt(number);
            int truncatedSquareRoot = Convert.ToInt16(Math.Truncate(squareRoot));

            if (Math.Abs(squareRoot - truncatedSquareRoot) < 0.0001)
            {
                return true;
            }

            return false;
        }
    }
}

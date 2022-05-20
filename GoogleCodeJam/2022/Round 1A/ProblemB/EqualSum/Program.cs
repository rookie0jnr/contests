using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Error.WriteLine("ping");
            int testCases = Convert.ToInt32(Console.ReadLine());
            Console.Error.WriteLine(testCases);
            for (int i = 0; i < testCases; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                Console.Error.WriteLine(N);
                List<long> numbers = new List<long>();
                string myNumbers = string.Empty;
                for (int j = 1; j <= N; j++)
                {
                    myNumbers += j.ToString() + " ";
                    numbers.Add(j);
                }
                Console.WriteLine(myNumbers.TrimEnd());
                Console.Error.WriteLine(myNumbers.TrimEnd());

                string[] judgeNumbers = Console.ReadLine().Split(' ');
                foreach (var item in judgeNumbers)
                {
                    Console.Error.WriteLine(item);
                }
                for (int l = 0; l < N; l++)
                {
                    numbers.Add(Convert.ToInt64(judgeNumbers[l]));
                }

                numbers.Sort();
                long remaining = numbers.Sum() / 2;

                Stack<(long, int)> currentList = new Stack<(long, int)>();
                int indexPointer = numbers.Count - 1;

                while (true)
                {
                    if (indexPointer == -1)
                    {
                        var element = currentList.Pop();
                        indexPointer = element.Item2 - 1;
                        remaining += element.Item1;
                        continue;
                    }

                    if (numbers[indexPointer] == remaining)
                    {
                        currentList.Push((numbers[indexPointer], indexPointer));
                        break;
                    }
                    if (numbers[indexPointer] < remaining)
                    {
                        currentList.Push((numbers[indexPointer], indexPointer));
                        remaining -= numbers[indexPointer];
                    }

                    indexPointer--;
                }

                string result = string.Empty;
                foreach (var item in currentList)
                {
                    result += item.Item1.ToString() + " ";
                }
                Console.WriteLine(result.TrimEnd());
                Console.Error.WriteLine(result.TrimEnd());
            }
        }
    }
}
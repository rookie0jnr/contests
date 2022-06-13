namespace NestingDepth
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int t = 0; t < testCases; t++)
            {
                Console.Write("Case #" + (t + 1) + ": ");
                string line = Console.ReadLine();
                int[] numbers = new int[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(line[i].ToString());
                }
                int parenthesses = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    while (parenthesses < numbers[i])
                    {
                        Console.Write("(");
                        parenthesses++;
                    }
                    Console.Write(numbers[i]);
                    while (i < numbers.Length - 1
                        && parenthesses > numbers[i + 1]
                        && numbers[i] > 0
                        && numbers[i + 1] < numbers[i])
                    {
                        Console.Write(")");
                        parenthesses--;
                    }
                }
                while (parenthesses > 0)
                {
                    Console.Write(")");
                    parenthesses--;
                }
                Console.WriteLine();
            }
        }
    }
}

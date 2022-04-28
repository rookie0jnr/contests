using System;
using System.Collections.Generic;

namespace ChainReactions
{
    class Program
    {
        class Node
        {
            int next;
            int FF;
            bool isProcessed;
            List<int> prevs = new List<int>();

            public Node(int fF, int next)
            {
                this.next = next - 1;
                FF = fF;
            }
        }

        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: ";

                int N = Convert.ToInt32(Console.ReadLine());
                var fFactors = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                var pointers = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

                Node[] nodes = new Node[N];

                for (int j = 0; j < N; j++)
                {
                    nodes[j] = new Node(fFactors[j], pointers[j]);
                }

                //currentTestResult += straight;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
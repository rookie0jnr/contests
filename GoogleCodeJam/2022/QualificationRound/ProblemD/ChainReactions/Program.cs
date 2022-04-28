using System;
using System.Linq;
using System.Collections.Generic;

namespace ChainReactions
{
    class Program
    {
        static Node[] nodes;

        class Node
        {
            internal int next;
            internal int FF;
            internal bool isProcessed;
            internal List<int> prevs = new List<int>();

            public Node(int fF, int next)
            {
                this.next = next - 1;
                FF = fF;
            }
        }

        static void Main(string[] args)
        {
            //var p = Console.ReadLine();
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: ";

                int N = Convert.ToInt32(Console.ReadLine());
                var fFactors = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
                var pointers = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

                nodes = new Node[N];

                for (int j = 0; j < N; j++)
                {
                    nodes[j] = new Node(fFactors[j], pointers[j]);
                }
                for (int j = 0; j < N; j++)
                {
                    if (nodes[j].next > -1)
                    {
                        nodes[nodes[j].next].prevs.Add(j);
                    }
                }

                Stack<int> crossNodes = new Stack<int>();
                for (int j = 0; j < N; j++)
                {
                    if (nodes[j].prevs.Count > 1)
                    {
                        crossNodes.Push(j);
                    }
                }

                // start processing
                long totalFun = 0;
                while (crossNodes.Count > 0)
                {
                    var cross = nodes[crossNodes.Pop()];
                    List<long> maxes = new List<long>();

                    while (cross.prevs.Count > 0)
                    {
                        int branchMax = GoBack(nodes[cross.prevs[0]]);
                        maxes.Add(branchMax);
                        cross.prevs.RemoveAt(0);
                    }

                    int branchMin = (int)maxes[0];
                    int indexMin = 0;
                    for (int k = 0; k < maxes.Count; k++)
                    {
                        if (maxes[k] < branchMin)
                        {
                            indexMin = k;
                            branchMin = (int)maxes[k];
                        }
                    }

                    cross.FF = Math.Max(branchMin, cross.FF);
                    maxes.RemoveAt(indexMin);
                    totalFun += maxes.Sum();
                }

                for (int j = nodes.Length - 1; j >= 0; j--)
                {
                    if (!nodes[j].isProcessed)
                    {
                        totalFun += GoForward(nodes[j]);
                    }
                }

                currentTestResult += totalFun;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }

        private static int GoBack(Node node)
        {
            var currentNode = node;
            int max = 0;
            while (currentNode.prevs.Count > 0)
            {
                max = Math.Max(max, currentNode.FF);
                currentNode.isProcessed = true;
                currentNode = nodes[currentNode.prevs[0]];
            }
            max = Math.Max(max, currentNode.FF);
            currentNode.isProcessed = true;

            return max;
        }

        private static int GoForward(Node node)
        {
            var currentNode = node;
            int max = 0;
            while (currentNode.next != -1)
            {
                max = Math.Max(max, currentNode.FF);
                currentNode.isProcessed = true;
                currentNode = nodes[currentNode.next];
            }
            max = Math.Max(max, currentNode.FF);
            currentNode.isProcessed = true;

            return max;
        }

    }
}
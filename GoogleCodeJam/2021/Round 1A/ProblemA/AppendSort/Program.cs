using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace ChainReactions
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: ";

                Console.ReadLine();
                string[] inputs = Console.ReadLine().Split(' ');

                //Console.WriteLine();
                //Console.WriteLine("INITIAL:");
                //foreach (var item in inputs)
                //{
                //    Console.WriteLine(item);
                //}
                BigInteger prev, current;
                string p, c;

                int counter = 0;
                for (int j = 1; j < inputs.Length; j++)
                {
                    p = inputs[j - 1];
                    c = inputs[j];
                    int diff = p.Length - c.Length;
                    if (diff > 0)
                    {
                        for (int k = 0; k < diff; k++)
                        {
                            c += "0";
                        }
                    }
                    else
                    {
                        {
                            diff = 0;
                        }
                    }
                    //BigInteger.Parse
                    //prev = Convert.To   ToDouble(p);
                    //prev = Convert.ToDouble(p);
                    //current = Convert.ToDouble(c);
                    prev = BigInteger.Parse(p);
                    current = BigInteger.Parse(c);
                    counter += diff;

                    if (current > prev)
                    {
                        //counter += diff;
                    }
                    else
                    {
                        BigInteger temp = new BigInteger((Math.Pow(10, diff) - 1));
                        if ((diff > 0) && ((prev - current) < temp))
                        {
                            current += prev - current + 1;
                        }
                        else
                        {
                            current = BigInteger.Parse(c + "0");
                            counter++;
                        }
                    }

                    inputs[j] = current.ToString();
                }

                //Console.WriteLine();
                //Console.WriteLine("SORTED:");
                //foreach (var item in inputs)
                //{
                //    Console.WriteLine(item);
                //}

                currentTestResult += counter;
                results.Add(currentTestResult);
            }


            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
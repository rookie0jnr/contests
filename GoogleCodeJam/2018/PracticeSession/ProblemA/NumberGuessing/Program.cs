using System;

namespace NumberGuessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            for (int tcIndex = 0; tcIndex < testCases; tcIndex++)
            {
                var ab = Console.ReadLine().Split(' ');
                int A = Convert.ToInt32(ab[0]);
                int B = Convert.ToInt32(ab[1]) + 1;
                int N = Convert.ToInt32(Console.ReadLine());

                int GUESS = (B - A) / 2;
                Console.WriteLine(GUESS);
                string responce = Console.ReadLine();
                
                while (!responce.Equals("CORRECT"))
                {
                    if (responce.Equals("TOO_BIG"))
                    {
                        B = GUESS;
                    }
                    else if (responce.Equals("TOO_SMALL"))
                    {
                        A = GUESS;
                    }
                    else if (responce.Equals("WRONG_ANSWER"))
                    {
                        break;
                    }

                    GUESS = (B - A) / 2 + A;
                    Console.WriteLine(GUESS);
                    responce = Console.ReadLine();
                }
            }
        }
    }
}
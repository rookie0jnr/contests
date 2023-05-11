namespace RainbowSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testCases = Convert.ToInt32(Console.ReadLine());
            List<string> results = new List<string>();

            for (int i = 0; i < testCases; i++)
            {
                string currentTestResult = $"Case #{(i + 1)}: ";
                var input = Console.ReadLine().Split(' ');
            }

            for (int i = 0; i < testCases; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
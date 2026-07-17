namespace Loops.Library
{
    internal class ForLoop
    {
        internal static void Ex1_1()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"for line print: {i}");
            }
        }

        internal static void Ex1_4()
        {
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"current number: {i}");
                sum += 1;
            }
            
            Console.WriteLine($"total sum: {sum}");
        }
    }
}

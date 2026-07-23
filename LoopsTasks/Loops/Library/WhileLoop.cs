namespace Loops.Library
{
    internal class WhileLoop
    {
        internal static void Ex1_2()
        {
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine($"while print line: {i}");
                i++;
            }
        }

        internal static void Ex3_6()
        {
            long n = 1;
            int steps = 0;
            while (n <= 27)
            {
                if (n % 2 == 0)
                {
                    Console.Write("Even");
                }

                if (n % 2 != 0)
                {
                    Console.Write("Odd");
                }

                steps++;
            }
            
            Console.WriteLine($"Steps: {steps}");
        }
    }
}

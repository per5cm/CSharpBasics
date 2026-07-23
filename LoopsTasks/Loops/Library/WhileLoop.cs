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
            long n = 27;
            int steps = 0;
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n = (n / 2);
                    Console.WriteLine("Even");
                }

                if (n % 2 != 0)
                {
                    n = (3 * n + 1);
                    Console.WriteLine("Odd");
                }
                
                steps++;
            }
            
            Console.WriteLine($"Steps: {steps}");
        }
    }
}

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

        internal static void Ex2_1()
        {
            for (int i = 1; i <= 50; i++)
            {
                if (i > 40) break;
                if (i % 3 == 0) continue;
                
                Console.WriteLine($"result: {i}");
            }
        }

        internal static void Ex2_2()
        {
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0) Console.WriteLine("Fizz");
                if (i % 5 == 0) Console.WriteLine("Buzz");
                if (i % 15 == 0) Console.WriteLine("FizzBuzz");
            }
        }

        internal static void Ex2_3()
        {
            for (int row = 1; row <= 5; row++)
            {
                for (int col = 1; col <= 5; col++)
                {
                    Console.Write(row * col + ",");
                }
                
                Console.WriteLine();
            }
        }
    }
}

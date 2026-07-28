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
            long n = 81;
            int steps = 0;
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n = (n / 2);
                }

                else //(n % 2 != 0)
                {
                    n = n * 3 + 1;
                }
                
                steps++;
            }
            
            Console.WriteLine($"Steps: {steps}");
        }

        internal static void B_1()
        {
            int n = -9384;
            int sum = 0;

            n = Math.Abs(n);
            
            while (n != 0)
            {
                int temp = n % 10;
                
                sum += temp;
                
                n = (n / 10);
            }
            
            Console.WriteLine($"Total sum: {sum}");
        }

        internal static void B_2()
        {
            int value = 0;
            bool valid = false;

            while (!valid)
            {
                Console.Write("Enter 1-100: ");
                string? input = Console.ReadLine();

                // int.TryParse(input, out value);

                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Parse failed. You caught it without exception.");
                    continue;
                }
                
                if (int.TryParse(input, out value) && value < 0 || value > 100)
                {
                    Console.WriteLine("Parse is out of Range. Again!");
                }

                else
                {
                    valid = true;
                }
            }
            
            Console.WriteLine($"Your input was correct: {value}");
        }
    }
}

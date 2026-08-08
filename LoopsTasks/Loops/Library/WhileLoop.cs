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

        internal static void ExB_1()
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

        internal static void ExB_2()
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

        internal static void ExB_3()
        {
            int count = 0;
            int sum = 0;
            int input;

            while (true)
            {
                Console.Write("Number (-1 to finish): ");
                string? stringInput = Console.ReadLine();

                int.TryParse(stringInput, out input);

                if (input == -1) break;
                if (int.TryParse(stringInput, out input) || input != -1)
                {
                    sum += input;
                    count++;
                }
            }
            
            Console.WriteLine($"input count: {count}, total sum: {sum}");
        }

        internal static void ExB_6()
        {
            int a = 10000, b = 3;
            int iterationSubstraction = 0;
            int iterationModulo = 0;
            ;

            // Euclids GCD - substraction.
            while (a != b)
            {
                if (a > b) a -= b;
                if (a < b) b -= a;
                iterationSubstraction++;
            }

            // Shorthand Modulo variant - less steps than substraction.
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
                iterationModulo++;
            }
            
            Console.WriteLine($"Result: {a | b}, Iterations for substraction: {iterationSubstraction}, Iterations for Modulo: {iterationModulo}");
        }

        internal static void ExB_7()
        {
            var queue = new Queue<string>(new[] { "alpha", "beta", "gamma" });
            var rng = new Random(42);

            while (true)
            {
                string task = queue.Dequeue();
                int attempt = 0;
                bool success = false;

                while (!success && attempt < 5)
                {
                    attempt++;
                    
                }
            }
        }
    }
}

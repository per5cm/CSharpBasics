namespace Loops.Library
{
    internal class DoWhile
    {
        internal static void Ex1_3()
        {
            int n;
            do
            {
                Console.WriteLine("Enter a positive number: ");
                string? number = Console.ReadLine();
                if (!int.TryParse(number, out n) || n < 0)
                {
                    throw new ArgumentException("cant be null, negative or a letter.", nameof(number));
                }
            } while (n % 2 != 0);
            
            Console.WriteLine($"Thanks, number is even: {n}");
        }
        
        internal static void ExB_4()
        {
            string? choice;
            do
            {
                Console.WriteLine("\n1) Greet 2) Current Time 3) Quit");
                Console.Write("Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": Console.WriteLine("Hello there, we have no pizza!"); continue;
                    case "2": Console.WriteLine("Just no, im not a swiss watch!"); continue;
                    case "3": Console.WriteLine("Bye!"); continue;
                    
                    default: Console.WriteLine("No case match!"); continue;
                }

            } while (choice != "3");
        }

        internal static void ExB_5()
        {
            double guess = 1.0;
            double previous;
            int iterations = 0;

            do
            {
                previous = guess;
                guess = (guess + 2 / guess) / 2;
                iterations++;
                Console.WriteLine($"Iterations: {iterations}, Guess: {guess}");

            } while (Math.Abs(guess - previous) > 0.0000001);
            
            Console.WriteLine($"Final result: {guess}");
            Console.WriteLine($"Method of Math square: {Math.Sqrt(2)}");
        }
    }
}
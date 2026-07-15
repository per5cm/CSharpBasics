namespace Loops
{
    internal class WhileLoop
    {
        internal static void DivisibleNumber(int condition = 1)
        {
            Console.WriteLine("Enter the number to check divisible: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("Number cant be 0.");
            }

            while (condition <= number)
            {
                if (number % condition == 0)
                {
                    Console.WriteLine($"Divisible number of {number} are: {condition}");
                }
                condition++;
            }
        }

        internal static void AverageGrade(int total = 0, int count = 0)
        {
            int grades;
            do
            {
                Console.WriteLine("Noten eingeben: ");
                grades = Convert.ToInt32(Console.ReadLine());

                if (grades >= 1 && grades <= 6)
                {
                    total += grades;
                    count++;

                }
                else if (grades != 0)
                {
                    Console.WriteLine("Note ungültig!");
                }

            } while (grades != 0);

            Console.WriteLine($"Anzahl Noten {count}, Summe der Noten {total}");
            Console.WriteLine($"Durchschnitt - {total / count}");
        }

        internal static void EvenOrOddLoop()
        {
            Console.WriteLine("Enter a number between 0 and 100: ");
            string? number = Console.ReadLine();

            if (!int.TryParse(number, out int evenOrOdd) || evenOrOdd < 0)
            {
                throw new ArgumentNullException(nameof(evenOrOdd), "number cannot be negative");
            }

            while (true)
            {
                if (evenOrOdd % 2 == 0)
                {
                    Console.WriteLine("number is even");
                }
                else
                    Console.WriteLine("number is odd");

                break;
            }
        }
    }
}

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
    }
}
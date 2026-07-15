namespace Loops
{
    internal class ForEachLoop
    {
        internal static void EvenOrOddLoop()
        {
            Console.WriteLine("Enter a number between 0 and 100: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "number cannot be negative");
            }
            
            if (number % 2 == 0)
            {
                Console.WriteLine("number is even");
            }
            else
                Console.WriteLine("number is odd");
        }
    }
}

using System.Linq.Expressions;

namespace Loops
{
    internal class ForEachLoop
    {
        internal static void EvenOrOddLoop()
        {
            Console.WriteLine("Enter a number between 0 and 100: ");
            int number = int.Parse(Console.ReadLine());
            
            if (number % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
                Console.WriteLine("odd");
        }
    }
}

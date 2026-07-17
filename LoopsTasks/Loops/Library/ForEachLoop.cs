namespace Loops.Library
{
    internal class ForEachLoop
    {
        internal static void Ex1_5()
        {
            string[] fruits = { "apple", "banana", "cherry", "date" };
            int pos = 1;

            foreach (var fruit in fruits)
            {
                Console.WriteLine($"Position: {pos}, Fruit name: {fruit}");
                pos++;
            }
        }
    }
}


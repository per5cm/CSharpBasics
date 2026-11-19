namespace kata_loops.Library;

internal static class ForeachLoops
{
    internal static void Ex1_5()
    {
        string[] fruits = { "apple", "banana", "cherry", "date" };
        int pos = 1;
        
        fruits[0] = "kiwi";

        foreach (var fruit in fruits)
        {
            Console.WriteLine($"{pos}. {fruit}");
            pos++;
        }
    }
}
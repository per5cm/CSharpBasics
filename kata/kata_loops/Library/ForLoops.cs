namespace kata_loops.Library;

internal static class ForLoops
{
    internal static void Ex1_1()
    {
        for (var i = 0; i <= 10; i++) Console.WriteLine($"Step: {i}");
    }

    internal static void Ex1_4()
    {
        int sum = 0;
        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine($"Current Number: {i}");
            sum += i;
        }
        
        Console.WriteLine($"Current total Sum: {sum}");
    }
}
namespace kata_loops.Library;

internal static class ForLoops
{
    internal static void Ex1_1()
    {
        for (var i = 0; i <= 10; i++) Console.WriteLine($"Step: {i}");
    }

    internal static void Ex1_4()
    {
        var sum = 0;
        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine($"Current Number: {i}");
            sum += i;
        }
        
        Console.WriteLine($"Current total Sum: {sum}");
    }

    internal static void Ex2_1()
    {
        var sum = 0;
        for (int i = 1; i <= 50; i++)
        {
            if (i > 40) break;
            if (i % 3 == 0) continue;
            Console.Write($"{i}, ");
            sum++;
        }
        
        Console.WriteLine($"Total number count: {sum}");
    }
}
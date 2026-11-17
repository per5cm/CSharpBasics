namespace kata_loops.Library;

internal static class ForLoops
{
    internal static void Ex1_1()
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Felix Zählt: {i} .");
        }
    }

    internal static void Ex1_5()
    {
        int summe = 0;
        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine($"{i}");
            summe += i;
           
        }
        Console.WriteLine(summe);
    }
}
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

    internal static void Ex1_4()
    {
        int summe = 0;
        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine($"{i}");
            summe += i;
        }
        Console.WriteLine(summe);
    }

    internal static void Ex2_1()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i > 40) break;
            if (i % 3 == 0) continue;
            
            Console.WriteLine(i);
        }
    }

    internal static void Ex2_2()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 15 == 0) Console.WriteLine($"FizzBuzz");
            if (i % 5 == 0) Console.WriteLine($"Buzz");
            if (i % 3 == 0) Console.WriteLine($"Fizz");
        }
    }
}
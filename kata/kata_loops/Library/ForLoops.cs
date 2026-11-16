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

    internal static void Ex2_2()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 15 == 0) Console.WriteLine("FizzBuzz");
            if (i % 5 == 0) Console.WriteLine("Buzz");
            if (i % 3 == 0) Console.WriteLine("Fizz");
        }
    }

    internal static void Ex2_3()
    {
        for (int row = 1; row <= 5; row++)
        {
            for (int col = 1; col <= 5; col++)
            {
                Console.Write($"{row * col}, ");
            }
            
            Console.WriteLine();
        }
    }

    internal static void Ex2_4()
    {
        for (int row = 1; row <= 6; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    internal static void Ex2_5()
    {
        int[] data = { 4, 8, 15, 16, 23, 42 };
        int target = 4;
        int foundAt = -1;

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] == target) foundAt = i; break;
        }
        
        Console.WriteLine($"Found at position: {foundAt}.");
    }

    internal static void Ex2_6()
    {
        int[] squares = new int[10];
        // Stage A 
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i] = i * i;
        }

        var evens = new List<int>();
        // Stage B
        foreach (var s in squares)
        {
            if (evens.Contains(s))
            {
                evens.Add(s);
            }
        }
        
        // Stage c
        int running = 0;
        foreach (var e in evens)
        {
            running += e;
            Console.WriteLine($"{e} -> {running}");
        }
    }
}
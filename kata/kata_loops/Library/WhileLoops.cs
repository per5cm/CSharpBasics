namespace kata_loops.Library;

internal static class WhileLoops
{
    internal static void Ex1_2()
    {
        var i = 1;
        while (i <= 10)
        {
            Console.WriteLine($"Step: {i}");
            i++;
        }
    }

    internal static void Ex1_3()
    {
        int number;
        do
        {
            Console.Write("Enter a positive number: ");
            
            if (!int.TryParse(Console.ReadLine() ?? string.Empty, out number))
            {
                Console.WriteLine("Number is not positive or Input was empty or its a letter!");
            }
            
            
        } while (number % 2 != 0 || number <= 0);
        
        Console.WriteLine($"Number Was Positive: {number}");
    }
}
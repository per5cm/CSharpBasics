namespace Ternary_Coalescing_Training.Library;

internal class if_else
{
    internal static void Ex1_1()
    {
        int number = 7;

        // the long form:
        string resultIf;
        if (number % 2 == 0) resultIf = "even"; else resultIf = "odd";

        // short ternary form:
        var resultTernary = number % 2 == 0 ? "even" : "odd";
        
        Console.WriteLine($"{resultIf} / {resultTernary}");
    }

    internal static string Ex1_2(int a, int b)
    {
        return a < b ? "less than" : "greater than";
    }

    internal static void Ex1_3()
    {
        // int count = 3;
        
        Console.Write("Enter number of items: ");
        int count;
        while (!int.TryParse(Console.ReadLine() ?? string.Empty, out count))
        {
            Console.WriteLine("Should be a number.");
        }

        // var resultTernary = count <= 1 ? "item" : "items";
        
        Console.WriteLine($"You have {count} {(count <= 1 ? "item" : "items")}");
    }
}
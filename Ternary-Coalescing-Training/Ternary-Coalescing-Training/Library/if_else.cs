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
}
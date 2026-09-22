namespace kata_loops.Library;

internal class WhileLoops
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
}
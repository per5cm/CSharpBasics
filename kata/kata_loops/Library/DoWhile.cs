namespace kata_loops.Library;

public class DoWhile
{
    internal static void Ex1_3()
    {
        int n;
        do
        {
            Console.Write("Enter a positive number: ");
            if (!int.TryParse(Console.ReadLine(), out n))
            {
                throw new ArgumentException("cant be null, negative or a letter", nameof(n));
            }
        } while (n % 2 != 0);
        
        Console.WriteLine($"Thanks, number was even: {n}");
    }
}
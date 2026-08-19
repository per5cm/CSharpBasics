namespace OOPTasks.Library;

internal class Book
{
    // private readonly string _title;
    // private readonly int _pages;

    private string Title { get; set; }
    internal int Pages { get; private set; }

    internal Book(string title, int pages)
    {
        Title= title;
        Pages = pages;
    }

    internal void Describe()
    {
        Console.WriteLine($"Books title: {Title}, page count: {Pages}");
    }
}
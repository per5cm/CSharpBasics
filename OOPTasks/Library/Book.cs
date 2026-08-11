namespace OOPTasks.Library;

internal class Book
{
    private readonly string _title;
    private readonly int _pages;

    internal Book(string title, int pages)
    {
        _title = title;
        _pages = pages;
    }

    internal void Describe()
    {
        Console.WriteLine($"Books title: {_title}, page count: {_pages}");
    }
}
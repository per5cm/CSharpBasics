namespace OOPTasks.Library;

public class Report : IDescribable
{
    private string _text;

    public Report(string text)
    {
        _text = text;
    }

    public string ToText()
    {
        return _text;
    }
    
    static void PrintDescription(IDescribable item)
    {
        Console.WriteLine(item.ToText());
    }
}
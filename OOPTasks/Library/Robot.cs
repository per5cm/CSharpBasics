namespace OOPTasks.Library;

// IMovable, IDescribable

public class Robot : IMovable, IDescribable
{
    private int _x, _y;

    public void Move(int dx, int dy)
    {
        _x += dx;
        _y += dy;
    }

    public string ToText()
    {
        return Console.WriteLine($"Robot at: {Move(1, 1)}");
    }
}
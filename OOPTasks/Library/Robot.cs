namespace OOPTasks.Library;

// IMovable, IDescribable, Report

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
        return $"Robot X position at: {_x}, Robot Y position at: {_y}";
    }
}
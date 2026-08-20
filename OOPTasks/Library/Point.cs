namespace OOPTasks.Library;

public struct Point
{
    internal int X;
    internal int Y;

    internal Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    internal void Move(int dx, int dy)
    {
        X += dx;
        Y += dy;
    }
}
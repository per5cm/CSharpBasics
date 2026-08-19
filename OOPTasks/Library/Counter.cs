namespace OOPTasks.Library;

public class Counter
{
    private int _count;
    public int Value => _count;

    internal Counter(int count)
    {
        this._count = count;
    }

    internal void Increment()
    {
        this._count++;
    }

    internal void Reset()
    {
        this._count = 0;
    }
}
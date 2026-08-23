namespace OOPTasks.Library;

public static class MathUtils
{
    public static int CallCount;

    public static int Square(int n)
    {
        CallCount++;
        return n * n;
    }
}
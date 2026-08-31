namespace OOPTasks.Library;

abstract class Shape
{
    // Circle, Rectangle.
    protected abstract double Area();
    internal void Print() => Console.WriteLine($"Area = {Area():F2}");
}
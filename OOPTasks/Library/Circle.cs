namespace OOPTasks.Library;

class Circle : Shape
{
    private readonly double _radius;

    internal Circle(double radius)
    {
        this._radius = radius;
    }

    protected override double Area()
    {
        return Math.PI * _radius * _radius;
    }
}
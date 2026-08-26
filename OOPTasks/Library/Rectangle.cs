namespace OOPTasks.Library;

class Rectangle : Shape
{
    private readonly double _width, _height;

    public Rectangle(double width, double height)
    {
        this._width = width;
        this._height = height;
    }

    protected override double Area()
    {
        return _width * _height;
    }
}
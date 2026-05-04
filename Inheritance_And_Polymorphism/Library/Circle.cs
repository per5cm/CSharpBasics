namespace Inheritance_And_Polymorphism.Library;

internal class Circle : Shape
{
    private readonly double _radius;

    internal Circle(double radius)
    {
        _radius = radius;
    }
    
    public override double Area()
    {
        return Math.PI * _radius * _radius;
    }
}
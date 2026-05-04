using System;

namespace Inheritance_And_Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        // Expected usage:
        List<Abstract_Shape> shapes = new()
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Circle(3)
        };

        abstract class Abstract_Shape
        {
            public double Area();
        }

        // Circle: area = Math.PI * radius * radius
        // Rectangle: area = width * height

        foreach (var shape in shapes)
        Console.WriteLine($"{shape.GetType().Name}: {shape.Area():F2}");

        // Output:
        // Circle: 78.54
        // Rectangle: 24.00
        // Circle: 28.27
    }
}
using Inheritance_And_Polymorphism.Library;
using System;

namespace Inheritance_And_Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new()
            {
                new Circle(radius:5),
                new Rectangle(width:4,height:6),
                new Circle(radius:3),
            };
            
            foreach (var shape in shapes)
                Console.WriteLine($"{shape.GetType().Name}: {shape.Area():F2}");
        }
    }
}
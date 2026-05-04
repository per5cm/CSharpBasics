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
                new Circle(5),
                new Rectangle(4,6),
                new Circle(3),
            };
            
            foreach (var shape in shapes)
                Console.WriteLine($"{shape.GetType().Name}: {shape.Area():F2}");
        }
    }
}
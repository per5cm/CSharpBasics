using System;
using System.Collections.Generic;
using Interface.Library;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new()
            {
                new Dog("Rex"),
                new Cat("Whiskers"),
                new Dog("Buddy"),

            };

            foreach (var animal in animals)
            {
                animal.Speak();
                Console.WriteLine(animal.Describe());
            }
        }
    }
}
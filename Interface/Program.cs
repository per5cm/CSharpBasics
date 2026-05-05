using Interface.Library;

namespace Interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new()
            {
                new Dog(name:"Rex"),
                new Cat(name:"Whiskers"),
                new Dog(name:"Buddy"),
            };

            foreach (var animal in animals)
            {
                animal.Speak();
                Console.WriteLine(animal.Describe());
            }
        }
    }
}
namespace Interface.Library;

public class Dog : IAnimal
{
    public string Name { get; }

    public Dog(string name)
    {
        Name = name;
    }

    public void Speak()
    {
        Console.WriteLine("Woof!");
    }

    public string Describe()
    {
        return $"I am a Dog named {Name}";
    }
}
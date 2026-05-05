namespace Interface.Library;

public class Cat : IAnimal
{
    public string Name { get; }

    public Cat(string name)
    {
        Name = name;
    }
    
    public void Speak()
    {
        Console.WriteLine("Meow!");
    }

    public string Describe()
    {
        return $"I am a Cat named {Name}";
    }
}
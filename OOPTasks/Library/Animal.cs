namespace OOPTasks.Library;

public class Animal
{
    public string Name { get; init; }

    public Animal(string name)
    {
        Name = name;
    }

    public void Speak()
    {
        Console.WriteLine($"{Name} make a sound.");
    }
}
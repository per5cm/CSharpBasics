namespace OOPTasks.Library;

public class Animal
{
    protected string Name { get; init; }
    protected int Energy { get; set; }

    protected Animal(string name, int energy)
    {
        Name = name;
        Energy = energy;
    }

    public void Speak()
    {
        Console.WriteLine($"Dog named {Name}, makes a sound.");
    }
}
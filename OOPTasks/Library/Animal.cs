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
    public override string ToString()
    {
        return $"Animal named: {Name} was created, it has {Energy} energy.";
    }
    public void Speak()
    {
        Console.WriteLine($"Animal named {Name}, makes a sound.");
    }
}
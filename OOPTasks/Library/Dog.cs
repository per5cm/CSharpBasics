namespace OOPTasks.Library;

public class Dog : Animal
{
    public Dog(string name, int energy) : base(name, energy)
    {
        Name = name;
        Energy = energy;
    }
    public void Fetch(int reduce = 10 )
    {
        Energy -= reduce;
        Console.WriteLine($"Dog named {Name} fetches the ball and looses {reduce} energy now it has {Energy} left.");
    }
}
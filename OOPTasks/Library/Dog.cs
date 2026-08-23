namespace OOPTasks.Library;

public class Dog : Animal
{
    public Dog(string name) : base(name)
    {
        Name = name;
    }
    public void Fetch()
    {
        Console.WriteLine($" Dog named {Name} fetches the ball");
    }
}
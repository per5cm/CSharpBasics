namespace OOPTasks.Library;

public class Vehicle
{
    internal string Make { get; set; }

    protected Vehicle(string make)
    {
        Make = make;
    }
    // public override string ToString()
    // {
    //     return $"Car was created {Make}";
    // }
}
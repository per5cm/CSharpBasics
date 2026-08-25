namespace OOPTasks.Library;

public class Car : Vehicle
{
    public int Door { get; set; }
    public Car(string make, int door) : base(make)
    {
        Make = make;
        Door = door;
    }

    // public override string ToString()
    // {
    //     return $"Car was created, manufacturer is: {Make}. It has {Door} doors.";
    // }
}
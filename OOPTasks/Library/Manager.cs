namespace OOPTasks.Library;

public class Manager : Employee
{
    private readonly decimal _bonus;

    public Manager(decimal salary, decimal bonus) : base(salary)
    {
        _bonus = bonus;
    }

    public override decimal GrossPay()
    {
        return base.GrossPay() + _bonus;
    }
}
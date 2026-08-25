namespace OOPTasks.Library;

public class Employee
{
    private readonly decimal _baseSalary;

    public Employee(decimal salary)
    {
        _baseSalary = salary;
    }

    public virtual decimal GrossPay() => _baseSalary;
}
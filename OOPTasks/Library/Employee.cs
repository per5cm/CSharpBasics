namespace OOPTasks.Library;

public class Employee
{
    private readonly decimal _baseSalary;
    public decimal Salary => _baseSalary;

    protected Employee(decimal salary)
    {
        _baseSalary = salary;
    }

    public virtual decimal GrossPay() => _baseSalary;
}
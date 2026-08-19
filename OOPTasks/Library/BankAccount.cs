namespace OOPTasks.Library;

public class BankAccount
{
    private decimal _balance;

    internal decimal Balance => _balance;

    internal void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Not Positive Amount");
        _balance += amount;
    }

    internal bool Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Negative Amount");
        _balance -= amount;

        return true;
    }
}
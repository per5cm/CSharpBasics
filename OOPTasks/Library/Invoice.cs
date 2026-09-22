namespace OOPTasks.Library;

//3.6 | IPlayable | TaxedInvoice
public abstract class Invoice : IPayable
{
    protected decimal Amount;

    protected Invoice(decimal amount)
    {
        this.Amount = amount;
    }

    public abstract decimal AmountDue();
}
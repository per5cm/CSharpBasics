namespace OOPTasks.Library;

public class TaxedInvoice : Invoice
{
    private readonly decimal _taxRate;

    public TaxedInvoice(decimal amount, decimal taxRate) : base(amount)
    {
        this._taxRate = _taxRate;
    }

    public decimal AmountDue(decimal amount)
    {
       return amount * (1 + _taxRate);
    }
    
}
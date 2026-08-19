using OOPTasks.Library;

namespace OOPTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1.1, 1.2, 1.3
            Book alchemist = new Book("Alchemist", 300);
            alchemist.Describe();
            
            // 1.4
            BankAccount account = new BankAccount();
            account.Deposit(-500);
            account.Withdraw(-200);
        }
    }
}
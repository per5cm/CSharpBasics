using System;
using BankFundamentals.Library.Models;
using BankFundamentals.Library.Actions;

namespace BankFundamentals
{
    class Program
    {
        internal static void Main(string[] args)
        {
            //var account = new List<Account>();

            //account.Add(new Account("Karen Bottoms", 24, 150));
            //account.Add(new Account("Bob the Builder", 35, 250));

            //foreach (var accounts in account)
            //    accounts.GreetingUser();

            Account karen = new (owner:"Karen Bottoms", age: 24, balance: 150); 
            Account bob = new (owner:"Bob the Builder",age: 35, balance: 250);

            karen.DepositTo(50);
            bob.DepositTo(100);

            karen.WithdrawFrom(40);

            bob.TransferTo(karen, 100);

            karen.GreetingUser();
            bob.GreetingUser();
        }
    }
}

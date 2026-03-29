using BankFundamentals.Library.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankFundamentals.Library.Models
{
    internal class Account
    {
        private readonly string _accountNumber;

        internal string Owner { get; set; } = string.Empty;
        internal int Age { get; set; } = 0;
        internal decimal Balance { get; set; } = decimal.Zero;

        internal Account(string owner, int age, decimal balance)
        {
            Owner = owner;
            Age = age;
            Balance = balance;
            _accountNumber = "ACC-" + owner.ToUpper() + age + new Random().Next(100, 999).ToString("NEW");
        }

        internal void GreetingUser()
        {
            Console.WriteLine($"Account owner: {Owner}, age of {Age}, has balance of {Balance} in current Account number: {_accountNumber}. ");
        }

        internal void DepositTo(decimal depositAmountAdded)
        {
            Deposit deposit = new ();
            Balance = deposit.DepositAmount(Balance, depositAmountAdded);
            //Balance = newBalance;
            //Console.WriteLine($"Debug: new balance calculated = {newBalance}");
        }

        internal void WithdrawFrom(decimal amount)
        {
            Withdraw withdraw = new ();
            Balance = withdraw.WithdrawMoney(Balance, amount);
        }

        internal void TransferTo(Account reciever, decimal amount)
        {
            Transfer transferAction = new ();
            transferAction.TransferToAccount(this, reciever, amount);
        }
    }
}

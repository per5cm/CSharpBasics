//using BankFundamentals.Library.Actions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BankFundamentals.Library.Models
{
    internal class Account
    {
        private string _owner = string.Empty;
        private decimal _balance = decimal.Zero;
        private readonly string _accountNumber;

        internal string Owner
        {
            get => _owner;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Owner cant bet null or empty.");
                _owner = value;
            }
        }
        internal int Age { get; } 
        internal decimal Balance
        {
            get => _balance;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Balance cant bet negative.");
                _balance = value;
            }
        }

        internal Account(string owner, int age, decimal balance)
        {
            Owner = owner;
            Age = age;
            Balance = balance;
            _accountNumber = "ACC-" + owner.ToUpper() + age + new Random().Next(100, 999) + "NEWHUMAN";
        }

        internal void GreetingUser()
        {
            Console.WriteLine($"Account owner: {Owner}, age of {Age}, has balance of {Balance} in current Account number: {_accountNumber}. ");
        }

        internal void DepositTo(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cant be negative or null");
            Balance = Balance + amount;
        }

        internal void WithdrawFrom(decimal amount)
        {
            if (amount <= 0 || amount > Balance) throw new ArgumentOutOfRangeException(nameof(amount), "Invalid amount you wish to withdraw.");
            Balance = Balance - amount;
        }

        internal void TransferTo(Account receiver, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Transfer amount must be positive.");
            if (Balance < amount)
                throw new ArgumentOutOfRangeException(nameof(amount), "Not enough money to transfer.");

            Balance = Balance - amount;
            receiver.Balance = receiver.Balance + amount;
        }
    }

    #region Old Code
    //internal void DepositTo(decimal depositAmountAdded)
    //    {
    //        Deposit deposit = new();
    //        Balance = deposit.DepositAmount(Balance, depositAmountAdded);
    //        //decimal newBalance = deposit.DepositAmount(Balance, depositAmountAdded);
    //        //Balance = newBalance;
    //        //Console.WriteLine($"Debug: new balance calculated = {newBalance}");
    //    }

    //internal void WithdrawFrom(decimal amount)
    //    {
    //        Withdraw withdraw = new();
    //        Balance = withdraw.WithdrawMoney(Balance, amount);
    //    }

    //internal void TransferTo(Account reciever, decimal amount)
    //    {
    //        Transfer transferAction = new();
    //        transferAction.TransferToAccount(this, reciever, amount);
    //    }

        #endregion
    }

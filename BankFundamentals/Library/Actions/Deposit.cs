using System;
using System.Collections.Generic;
using System.Text;
using BankFundamentals.Library;
using BankFundamentals.Library.Models;

namespace BankFundamentals.Library.Actions
{
    internal class Deposit
    {
        //internal decimal Balance { get; private set; }
        internal decimal DepositAmount(decimal balance, decimal depositAmount)
        {
            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance), "Account balance is negative.");

            return balance + depositAmount;
        }
    }
}

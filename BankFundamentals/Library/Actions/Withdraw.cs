using System;
using System.Collections.Generic;
using System.Text;

namespace BankFundamentals.Library.Actions
{
    internal class Withdraw
    {
        internal decimal WithdrawMoney(decimal currentBalance, decimal amount)
        {
            if (amount <= 0 || amount > currentBalance) throw new ArgumentOutOfRangeException(nameof(amount), "Invalid amount you wish to withdraw.");

            return currentBalance - amount;
        }
    }
}

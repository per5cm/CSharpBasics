//using BankFundamentals.Library.Models;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BankFundamentals.Library.Actions
//{
//    internal class Transfer
//    {
//        internal void TransferToAccount(Account sender, Account reciever, decimal amount)
//        {
//            if (amount <= 0)
//                throw new ArgumentOutOfRangeException(nameof(amount), "Transfer amount must be positive.");
//            if (sender.Balance < amount)
//                throw new ArgumentOutOfRangeException(nameof(amount), "Not enough money to transfer.");

//            sender.Balance = sender.Balance - amount;
//            reciever.Balance = reciever.Balance + amount;
//        }
//    }
//}

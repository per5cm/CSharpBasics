using System;
using BankFundamentals.Library.Models;

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

            // Account karen = new(owner: "Karen Bottoms", age: 24, balance: 150);
            // Account bob = new(owner: "Bob the Builder", age: 35, balance: 250);
            //
            // karen.DepositTo(50);
            // bob.DepositTo(100);
            //
            // karen.WithdrawFrom(40);
            //
            // bob.TransferTo(karen, 100);
            //
            // karen.GreetingUser();
            // bob.GreetingUser();
            //
            // Console.WriteLine($"Owner: {karen.Owner}. Balance: {karen.Balance}.");
            // Console.WriteLine($"Owner: {bob.Owner}. Balance: {bob.Balance}.");
            //
            Account karen = new Account(owner: "Karen LongBottoms", age: 24, balance: 150);
            Account bob = new Account(owner: "Bob the Builder", age: 35, balance: 250);

            Account[] accounts = { karen, bob };

            var menu = new List<string>
            {
                "0: Exit",
                "1: Account Login ",
            };

            while (true)
            {
                foreach (var menuItem in menu)
                    Console.WriteLine(menuItem);

                Console.Write("\nPick a Option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) continue;

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye!");
                        return;
                    case 1:
                    {
                        Console.Write("Enter account name: ");
                        string? name = Console.ReadLine();
                        foreach (var found in accounts)
                        {
                            if (found.Owner == name)
                            {
                                found.GreetingUser();
                            }
                        }

                        Console.WriteLine("\nOptions:  1 - Deposit, 2 - Withdraw, 3 - Transfer, 4 - EXIT");

                        if (!int.TryParse(Console.ReadLine(), out int action)) continue;

                        switch (action)
                        {
                            case 1:
                                Console.WriteLine("Enter amount to deposit: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                                {
                                    karen.DepositTo(depositAmount);
                                    bob.DepositTo(depositAmount);
                                }

                                break;

                            case 2:
                                Console.WriteLine("Enter amount to withdraw: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                                {
                                    karen.WithdrawFrom(withdrawAmount);
                                    bob.WithdrawFrom(withdrawAmount);
                                }

                                break;

                            case 3:
                                Console.WriteLine("Enter amount to transfer to: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                {
                                    karen.TransferTo(bob, transferAmount);
                                    bob.TransferTo(karen, transferAmount);
                                }

                                break;

                            case 4:
                                Console.WriteLine("Bye!");
                                karen.GreetingUser();
                                bob.GreetingUser();
                                break;
                        }

                        break;
                    }
                }
            }
        }
    }
}

using BankApp_Models;
using BankApp_Models.Enum;
using BankApp_Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp_Service.Implementations
{


    public class AccountService : IAccountService
    {


        protected double balance;
        public AccountType AccountType { get; set; }


        public AccountService(double amount)
        {
            balance = amount;
        }
        public List<Account> Accounts { get; set; } = new List<Account>();

        // Method to add a bank account for the user
        public void AddBankAccount(Account account)
        {
            Accounts.Add(account);
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("The amount has been deposited.");
                return true;
            }
            return false;
        }


        public bool Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("The amount has been withdrawed.");
                return true;
            }
            return false;
        }
        public bool Transfer(IAccountService toAccount, double amount)
        {
            return (this.Deposit(amount) && toAccount.Withdraw(amount));
        }
        public double GetBalance()
        {
            return balance;
        }
    }



}


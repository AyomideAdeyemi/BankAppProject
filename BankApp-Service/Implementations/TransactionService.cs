using BankApp_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankApp_Service.Implementations
{
    public class TransactionService

    {
        public TransactionService() 
        {

        }
        public void CreateTransaction(System.Transactions.Transaction transaction)
        {
            // Assuming Transaction class has a property to store the associated bank account number
            var account = BankAccounts.Find(a => a.AccountNumber == transaction.AccountNumber);
            if (account != null)
            {
                // Add the transaction to the account's list of transactions
                account.Transactions.Add(transaction);
            }
            else
            {
                throw new ArgumentException("Invalid account number.");
            }
        }

        // Method to delete transactions
        public void DeleteTransactions(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                // Assuming Transaction class has a property to store the associated bank account number
                var account = BankAccounts.Find(a => a.AccountNumber == transaction.AccountNumber);
                if (account != null)
                {
                    account.Transactions.Remove(transaction);
                }
            }
        }

        // Method to search transactions by bank account
        public List<Transaction> SearchTransactionsByAccount(BankAccount account)
        {
            // Assuming Transaction class has a property to store the associated bank account number
            return account.Transactions;
        }

        // Method to search transactions by date/keywords
        public List<Transaction> SearchTransactionsByDateOrKeywords(DateTime date, string keywords)
        {
            // Assuming Transaction class has properties for Date and Description (for keywords)
            return BankAccounts
                .SelectMany(account => account.Transactions)
                .Where(transaction => transaction.Date == date || transaction.Description.Contains(keywords))
                .ToList();
        }
    }
}

using BankApp_Models;
using BankApp_Repository.Repository.UnitofWork.Abstraction;
using BankApp_Service.Abstractions;
using RepositoryPattern_Models.Enums;

namespace BankApp_Service.Implementations
{


    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(bool status, string error)> Transfer(string fromAccountNumber, string toAccountNumber, decimal amount, string description)
        {
            if (amount <= 0)
            {
                return (false, "Amount must be greater than zero.");
            }

            var fromAccount = await GetAccountByAccountNumber(fromAccountNumber);
            var toAccount = await GetAccountByAccountNumber(toAccountNumber);

            if (fromAccount == null || toAccount == null)
            {
                return (false, "Invalid account number.");
            }

            if (fromAccount.Balance - amount < fromAccount.MinBalance)
            {
                return (false, "Insufficient balance.");
            }

            // Perform the transfer
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            var transaction = new Transactions
            {
                AccountNumber = fromAccountNumber,
                Amount = amount,
                Status = Status.Successful,
                Description = description,
                ReceiverAccountNumber = toAccountNumber,
                TransactionDate = DateTime.UtcNow
            };

            await _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _unitOfWork.AccountRepository.Update(fromAccount);
            _unitOfWork.AccountRepository.Update(toAccount);
            await _unitOfWork.SaveAsync();

            return (true, "Transfer successful.");
        }

        public async Task<(bool status, string error)> Deposit(string accountNumber, decimal amount, string description)
        {
            if (amount <= 0)
            {
                return (false, "Amount must be greater than zero.");
            }

            var account = await GetAccountByAccountNumber(accountNumber);

            if (account == null)
            {
                return (false, "Invalid account number.");
            }

            // Perform the deposit
            account.Balance += amount;

            var transaction = new Transactions
            {
                AccountNumber = accountNumber,                
                Amount = amount,
                Status = Status.Successful,
                Description = description,
                TransactionDate = DateTime.UtcNow
            };

            await _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveAsync();

            return (true, "Deposit successful.");
        }

        public async Task<(bool status, string error)> Withdraw(string accountNumber, decimal amount, string description)
        {
            if (amount <= 0)
            {
                return (false, "Amount must be greater than zero.");
            }

            var account = await GetAccountByAccountNumber(accountNumber);

            if (account == null)
            {
                return (false, "Invalid account number.");
            }

            if (account.Balance - amount < account.MinBalance)
            {
                return (false, "Insufficient balance.");
            }

            // Perform the withdrawal
            account.Balance -= amount;

            var transaction = new Transactions
            {
                AccountNumber = accountNumber,
                Amount = amount,
                Status = Status.Successful,
                Description = description,
                TransactionDate = DateTime.UtcNow
            };

            await _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveAsync();

            return (true, "Withdrawal successful.");
        }

        public async Task<Account> GetAccountByAccountNumber(string accountNumber)
        {
            return await _unitOfWork.AccountRepository.GetAccountByAccountNumberAsync(accountNumber);
        }
    }
}


    
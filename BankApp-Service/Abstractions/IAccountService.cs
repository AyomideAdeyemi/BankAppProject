using BankApp_Models;

namespace BankApp_Service.Abstractions
{
    public interface IAccountService
    {
        Task<(bool status, string error)> Transfer(string fromAccountNumber, string toAccountNumber, decimal amount, string description);
        Task<(bool status, string error)> Deposit(string accountNumber, decimal amount, string description);
        Task<(bool status, string error)> Withdraw(string accountNumber, decimal amount, string description);
        Task<Account> GetAccountByAccountNumber(string accountNumber)



;

    }
}

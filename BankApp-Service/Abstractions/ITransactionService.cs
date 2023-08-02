using BankApp_Models;


namespace BankApp_Service.Abstractions
{
    public interface ITransactionService
    {
        Task DeleteTransactionById(int id);
        Task<IEnumerable<Transactions>> GetAllDailyTransactions(string date);
        Task<IEnumerable<Transactions>> GetAllTransactionsByAccountNumber(string accountNumber);
        Task<Transactions> GetTransactionById(int transactionId);
    }
}

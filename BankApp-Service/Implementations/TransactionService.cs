using BankApp_Models;
using BankApp_Repository.Repository.UnitofWork.Abstraction;
using BankApp_Service.Abstractions;

namespace BankApp_Service.Implementations
{

    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteTransactionById(int id)
        {
            Transactions transaction = await _unitOfWork.TransactionRepository
                .GetTransactionById(id);
            _unitOfWork.TransactionRepository.Delete(transaction);
            await _unitOfWork.SaveAsync();
            _unitOfWork.Dispose();
        }
      

        public async Task<IEnumerable<Transactions>> GetAllDailyTransactions(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dateTime))
            {
                return null;
            }

            DateOnly dateOnly = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
            DateTime dateWithoutTime = dateOnly.ToDateTime(TimeOnly.MinValue);

            return await _unitOfWork.TransactionRepository.GetDailyTransactions(dateWithoutTime);
        }





        public async Task<IEnumerable<Transactions>> GetAllTransactionsByAccountNumber(string accountNumber)
        {
            IEnumerable<Transactions> transactions = await _unitOfWork.TransactionRepository
                .GetAllTransactionsByAccountNumber(accountNumber);
            return transactions;
        }

        public async Task<Transactions> GetTransactionById(int transactionId)
        {
            Transactions transaction = await _unitOfWork.TransactionRepository
                .GetTransactionById(transactionId);
            return transaction;

        }

        
    }

}
    

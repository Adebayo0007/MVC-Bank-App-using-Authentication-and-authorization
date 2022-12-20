using MVC_MobileBankApp.Models;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction CreateTransfer(Transaction transfer);
        Transaction CreateTransaction(Transaction transaction);
       void DeleteTransactionUsingRefNum(Transaction refNum);
       Transaction GetTransactionByRefNum(string refNum);
       IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber);
       IList<Transaction> GetAllTransaction(); 
    }
}
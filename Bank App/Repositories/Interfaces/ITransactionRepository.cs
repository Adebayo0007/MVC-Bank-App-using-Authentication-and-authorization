using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction CreateTransfer(Transaction transfer);
        Transaction CreateTransaction(Transaction transaction);
        void DeleteTransactionUsingRefNum(Transaction refNum);
        Transaction GetTransactionByRefNum(string refNum);
        Transaction GetTransactionByAccountNumber(string accountNumber);
        IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber);
        IList<Transaction> GetAllTransaction(); 
    }
}
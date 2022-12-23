using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction CreateTransfer(Transaction transfer);
        Transaction CreateTransaction(Transaction transaction);
       void DeleteTransactionUsingRefNum(Transaction refNum);
       TransactionDTO GetTransactionByRefNum(string refNum);
       IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber);
       IList<TransactionDTO> GetAllTransaction(); 
    }
}
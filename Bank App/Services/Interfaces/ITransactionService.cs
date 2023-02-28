using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ITransactionService
    {
        TransactionDTO CreateTransaction(TransactionDTO transaction);
        void DeleteTransactionUsingRefNum(string refNum);
        TransactionRequestModel GetTransactionByRefNum(string refNum);
        TransactionRequestModel GetTransactionByAccount(string accountNumber);
        IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber);
        IList<TransactionDTO> GetAllTransaction(); 
         
    }
}
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction CreateTransaction(TransactionDTO transaction);
       void DeleteTransactionUsingRefNum(string refNum);
       TransactionRequestModel GetTransactionByRefNum(string refNum);
       IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber);
       IList<TransactionDTO> GetAllTransaction(); 
         
    }
}
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.TransactionDto;

namespace MVC_MobileBankApp.Services.Interfaces
{
    public interface ITransactionService
    {
        CreateTransactionRequestModel CreateTransaction(CreateTransactionRequestModel transaction);
        void DeleteTransactionUsingRefNum(string refNum);
        TransactionResponseModel GetTransactionByRefNum(string refNum);
        TransactionResponseModel GetTransactionByAccount(string accountNumber);
        IList<TransactionResponseModel> GetAllTransactionUsingAccountNumber(string accountNumber);
        IList<TransactionResponseModel> GetAllTransaction(); 
         
    }
}
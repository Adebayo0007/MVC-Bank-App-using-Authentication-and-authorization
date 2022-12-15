using Bank_App.Models;
using MVC_MobileBankApp.Models;

namespace Bank_App.Services.Interfaces
{
    public interface ITransactionService
    {
        Transaction CreateTransaction(Transaction transaction);
       void DeleteTransactionUsingRefNum(string refNum);
       Transaction GetTransactionByRefNum(string refNum);
       IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber);
       IList<Transaction> GetAllTransaction(); 
         
    }
}
using Microsoft.EntityFrameworkCore;
using MVC_MobileBankApp.ApplicationContext;
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Repositories.Interfaces;

namespace MVC_MobileBankApp.Repositories.Implementations
{
    public class TransactionRepository : ITransactionRepository 
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Transaction CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return transaction;

        }

        public Transaction CreateTransfer(Transaction transaction)
        {
             _context.Transactions.Add(transaction);
            var reciever = _context.Customers.Find(transaction.RecipientAccountNumber);
            _context.Customers.Update(reciever);
             _context.SaveChanges();
            return transaction;
        }
        

        public void DeleteTransactionUsingRefNum(Transaction refNum)
        {
             _context.Transactions.Remove(refNum);
             _context.SaveChanges();
        }

        public IList<Transaction> GetAllTransaction()
        {
               return  _context.Transactions.ToList();
        
        }

        public IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber)
        {
            return  _context.Transactions.Where(a => a.AccountNumber == accountNumber || a.RecipientAccountNumber == accountNumber).ToList();
            
        }

        public Transaction GetTransactionByRefNum(string refNum)
        {
             return _context.Transactions.SingleOrDefault(a => a.RefNum == refNum);

          
        
        }
        public Transaction GetTransactionByAccountNumber(string accountNumber)
        {
            return  _context.Transactions.OrderByDescending(a => a.DateCreated).FirstOrDefault(a => a.AccountNumber == accountNumber);

        

        }
    }
}
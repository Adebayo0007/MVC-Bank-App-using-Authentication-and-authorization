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

        public IList<TransactionDTO> GetAllTransaction()
        {
               return _context.Transactions.Select(a => new TransactionDTO
                            {
                                AccountBalance = a.AccountBalance,
                                AccountNumber = a.AccountNumber,
                                RefNum = a.RefNum,
                                Amount = a.Amount,
                                RecipientAccountNumber = a.RecipientAccountNumber,
                                Pin = a.Pin,
                                DateCreated = a.DateCreated,
                                Description = a.Description,
                                TransactType = a.TransactType
                              }).ToList();
        
        }

        public IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber)
        {
            return _context.Transactions.Where(a => a.AccountNumber == accountNumber || a.RecipientAccountNumber == accountNumber).ToList();
            
        }

        public TransactionDTO GetTransactionByRefNum(string refNum)
        {
             var transaction =_context.Transactions.SingleOrDefault(a => a.RefNum == refNum);

            return new TransactionDTO
            {
                                AccountBalance = transaction.AccountBalance,
                                AccountNumber = transaction.AccountNumber,
                                RefNum = transaction.RefNum,
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = transaction.DateCreated,
                                Description = transaction.Description,
                                TransactType = transaction.TransactType

            };
        
        }
        public TransactionDTO GetTransactionByAccountNumber(string accountNumber)
        {
            var transaction =_context.Transactions.OrderByDescending(a => a.DateCreated).FirstOrDefault(a => a.AccountNumber == accountNumber);

            return new TransactionDTO
            {
                                AccountBalance = transaction.AccountBalance,
                                AccountNumber = transaction.AccountNumber,
                                RefNum = transaction.RefNum,
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = transaction.DateCreated,
                                Description = transaction.Description,
                                TransactType = transaction.TransactType

            };

        }
    }
}
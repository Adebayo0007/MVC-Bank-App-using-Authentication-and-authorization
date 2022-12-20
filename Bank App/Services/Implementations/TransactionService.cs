
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Repositories.Interfaces;
using MVC_MobileBankApp.Services.Interfaces;

namespace MVC_MobileBankApp.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
         private readonly ITransactionRepository _transactionRepo;
         private readonly ICustomerRepository _customerRepo;
          private readonly IUserService _service;


        public TransactionService(ITransactionRepository transactionRepo, ICustomerRepository customerRepo,IUserService service)
        {
            _transactionRepo = transactionRepo;
             _customerRepo = customerRepo;
             _service = service;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            
            double charges;
            var reciever = _customerRepo.GetCustomerByAccountnumber(transaction.RecipientAccountNumber);
           var customer = _customerRepo.GetCustomerByAccountnumber(transaction.AccountNumber);
           object check = null;
             if((int)transaction.TransactType == 1)
            {
                customer.AccountBalance+=transaction.Amount;
                transaction.AccountBalance = customer.AccountBalance;
                string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                var i = new Random().Next(25);
                var j = new Random().Next(25);
                var k = new Random().Next(25,99);
                transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
               check =  _transactionRepo.CreateTransaction(transaction);   

            }
            else if((int)transaction.TransactType == 2)
            {
                if((int)customer.AccountType == 1)
                {
                    if(customer.AccountBalance <= 200000)
                    {
                        if(transaction.Amount <= customer.AccountBalance)
                        {
                            if(transaction.Amount >= 2000)
                            {
                                charges = transaction.Amount*0.005;
                                customer.AccountBalance-=charges;
                                
                            }
                             customer.AccountBalance-=transaction.Amount;
                             transaction.AccountBalance = customer.AccountBalance;
                            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                            var i = new Random().Next(25);
                            var j = new Random().Next(25);
                            var k = new Random().Next(25,99);
                            transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
                             check =  _transactionRepo.CreateTransaction(transaction); 

                        }
                           

                    }

                }
                else
                {
                    if(transaction.Amount < customer.AccountBalance && customer.AccountBalance >= 500 )
                    {
                        if(transaction.Amount >= 2000)
                        {
                                charges = transaction.Amount*0.005;
                                customer.AccountBalance-=charges;

                        }
                        customer.AccountBalance-=transaction.Amount;
                             transaction.AccountBalance = customer.AccountBalance;
                            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                            var i = new Random().Next(25);
                            var j = new Random().Next(25);
                            var k = new Random().Next(25,99);
                            transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
                             check =  _transactionRepo.CreateTransaction(transaction); 
                    }
                }

            }


            else if((int)transaction.TransactType == 3)

            {
                if((int)customer.AccountType == 1)
                {
                    if(customer.AccountBalance <= 200000)
                    {
                        if(transaction.Amount <= customer.AccountBalance)
                        {
                            if(transaction.Amount >= 2000)
                            {
                                charges = transaction.Amount*0.005;
                                customer.AccountBalance-=charges;
                                
                            }
                             customer.AccountBalance-=transaction.Amount;
                             reciever.AccountBalance+=transaction.Amount;
                             transaction.AccountBalance = customer.AccountBalance;
                            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                            var i = new Random().Next(25);
                            var j = new Random().Next(25);
                            var k = new Random().Next(25,99);
                            transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
                             check =  _transactionRepo.CreateTransfer(transaction); 

                        }
                           

                    }

                }
                else
                {
                    if(transaction.Amount < customer.AccountBalance && customer.AccountBalance >= 500 )
                    {
                        if(transaction.Amount >= 2000)
                        {
                                charges = transaction.Amount*0.005;
                                customer.AccountBalance-=charges;

                        }
                           customer.AccountBalance-=transaction.Amount;
                           reciever.AccountBalance+=transaction.Amount;
                             transaction.AccountBalance = customer.AccountBalance;
                            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                            var i = new Random().Next(25);
                            var j = new Random().Next(25);
                            var k = new Random().Next(25,99);
                            transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
                             check =  _transactionRepo.CreateTransfer(transaction); 
                    }
                }

            }


             if((int)transaction.TransactType == 4)
             {
                  if((int)customer.AccountType == 1)
                {
                    if(customer.AccountBalance <= 200000)
                    {
                        if(transaction.Amount <= customer.AccountBalance)
                        {
                             customer.AccountBalance-=transaction.Amount;
                             transaction.AccountBalance = customer.AccountBalance;
                            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                            var i = new Random().Next(25);
                            var j = new Random().Next(25);
                            var k = new Random().Next(25,99);
                            transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
                             check =  _transactionRepo.CreateTransaction(transaction); 

                        }
                           

                    }

                }
                else
                {
                    if(transaction.Amount < customer.AccountBalance && customer.AccountBalance >= 500 )
                    {
                        customer.AccountBalance-=transaction.Amount;
                             transaction.AccountBalance = customer.AccountBalance;
                            string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                            var i = new Random().Next(25);
                            var j = new Random().Next(25);
                            var k = new Random().Next(25,99);
                            transaction.RefNum= $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;
                             check =  _transactionRepo.CreateTransaction(transaction); 
                    }
                }

                
             }
           
             return (Transaction)check;
        }

        public void DeleteTransactionUsingRefNum(string refNum)
        {
            var transaction = _transactionRepo.GetTransactionByRefNum(refNum);
           _transactionRepo.DeleteTransactionUsingRefNum(transaction);
        }

        public IList<Transaction> GetAllTransaction()
        {
           return _transactionRepo.GetAllTransaction();
        }

        public IList<Transaction> GetAllTransactionUsingAccountNumber(string accountNumber)
        {
            var customer = _customerRepo.GetCustomerByAccountnumber(accountNumber);
            return _transactionRepo.GetAllTransactionUsingAccountNumber(customer.AccountNumber);
        }

        public Transaction GetTransactionByRefNum(string refNum)
        {
            var transaction = _transactionRepo.GetTransactionByRefNum(refNum);
            return _transactionRepo.GetTransactionByRefNum(transaction.RefNum);
        }

    }
}
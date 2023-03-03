
using MVC_MobileBankApp.Models;
using MVC_MobileBankApp.Models.DTOs;
using MVC_MobileBankApp.Models.DTOs.TransactionDto;
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

        public CreateTransactionRequestModel CreateTransaction(CreateTransactionRequestModel transaction)
        {
            
            double charges = 0;
            var reciever = _customerRepo.GetCustomerByAccountnumber(transaction.RecipientAccountNumber);
           var customer = _customerRepo.GetCustomerByAccountnumber(transaction.AccountNumber);
           object check = null;
           transaction.Message = null;
           
           if(customer.Pin == transaction.Pin)
           {
             if((int)transaction.TransactType == 1)
            {
                customer.AccountBalance+=transaction.Amount;
                // transaction.AccountBalance = customer.AccountBalance;
                // transaction.RefNum= RefNum();
                var transact = new Transaction{
                   AccountBalance = customer.AccountBalance,
                   AccountNumber = customer.AccountNumber,
                   RefNum = RefNum(),
                   Amount = transaction.Amount,
                   RecipientAccountNumber = transaction.RecipientAccountNumber,
                   Pin = transaction.Pin,
                   DateCreated = TransactionDate(),
                   Description = transaction.Description,
                   TransactType = transaction.TransactType
                };
                transaction.SuccessMessage = $"Tnx: Credit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n Amt: NGN {transaction.Amount}\\n Ref Number: {transact.RefNum}\\n Balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
               check =  _transactionRepo.CreateTransaction(transact);   

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
                                    // transaction.AccountBalance = customer.AccountBalance;
                                    // transaction.RefNum= RefNum();
                                        var transact = new Transaction{
                                        AccountBalance = customer.AccountBalance,
                                        AccountNumber = customer.AccountNumber,
                                        RefNum = RefNum(),
                                        Amount = transaction.Amount,
                                        RecipientAccountNumber = transaction.RecipientAccountNumber,
                                        Pin = transaction.Pin,
                                        DateCreated = TransactionDate(),
                                        Description = transaction.Description,
                                        TransactType = transaction.TransactType
                             };
                              transaction.SuccessMessage = $"Tnx: Debit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n VAT: NGN {charges}\\n Amt: NGN {transaction.Amount}\\n From: {transaction.AccountNumber}\\n Ref Number: {transact.RefNum}\\n Balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
                             _transactionRepo.CreateTransaction(transact); 

                        }
                        else
                        {
                             transaction.Message = $"Oops!\\nYou are having low balance";
                              return transaction;
                        }
                           

                    }
                    else
                    {
                         transaction.Message = $"Oops!\\nGo to the bank and Upgrade your account";
                         return transaction;
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
                                // transaction.AccountBalance = customer.AccountBalance;
                                // transaction.RefNum= RefNum();
                                    var transact = new Transaction{
                                AccountBalance = customer.AccountBalance,
                                AccountNumber = customer.AccountNumber,
                                RefNum = RefNum(),
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = TransactionDate(),
                                Description = transaction.Description,
                                TransactType = transaction.TransactType
                           };
                            transaction.SuccessMessage = $"Tnx: Debit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n VAT: NGN {charges}\\n Amt: NGN {transaction.Amount}\\n From: {transaction.AccountNumber}\\n Ref Number: {transact.RefNum}\\n Balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
                             _transactionRepo.CreateTransaction(transact); 
                    }
                     else
                        {
                             transaction.Message = $"Oops!\\nYou are having low balance";
                              return transaction;
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
                                    // transaction.AccountBalance = customer.AccountBalance;
                                    // transaction.RefNum= RefNum();
                                    var transact = new Transaction{
                                        AccountBalance = customer.AccountBalance,
                                        AccountNumber = customer.AccountNumber,
                                        RefNum = RefNum(),
                                        Amount = transaction.Amount,
                                        RecipientAccountNumber = transaction.RecipientAccountNumber,
                                        Pin = transaction.Pin,
                                        DateCreated = TransactionDate(),
                                        Description = transaction.Description,
                                        TransactType = transaction.TransactType
                                };
                                transaction.SuccessMessage = $"Tnx: Debit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n VAT: NGN {charges}\\n Amt: NGN {transaction.Amount}\\n From: {transaction.AccountNumber}\\n To: {reciever.AccountNumber}\\n Ref Number: {transact.RefNum}\\n Balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
                                _transactionRepo.CreateTransfer(transact); 

                        }
                        else
                        {
                             transaction.Message = $"Oops!\\nYou are having low balance";
                              return transaction;
                        }
                           

                    }
                     else
                    {
                         transaction.Message = $"Oops!\\nGo to the bank and Upgrade your account";
                         return transaction;
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
                            //  transaction.AccountBalance = customer.AccountBalance;
                            // transaction.RefNum= RefNum();
                              var transact = new Transaction{
                                AccountBalance = customer.AccountBalance,
                                AccountNumber = customer.AccountNumber,
                                RefNum = RefNum(),
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = TransactionDate(),
                                Description = transaction.Description,
                                TransactType = transaction.TransactType
                             };
                              transaction.SuccessMessage = $"Tnx: Debit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n  VAT: NGN {charges}\\n Amt: NGN {transaction.Amount}\\n From: {transaction.AccountNumber}\\n To: {reciever.AccountNumber}\\n Ref Number: {transact.RefNum}\\n Balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
                              _transactionRepo.CreateTransfer(transact); 
                    }
                     else
                        {
                             transaction.Message = $"Oops!\\nYou are having low balance";
                              return transaction;
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
                            //  transaction.AccountBalance = customer.AccountBalance;
                            // transaction.RefNum= RefNum();
                              var transact = new Transaction{
                                AccountBalance = customer.AccountBalance,
                                AccountNumber = customer.AccountNumber,
                                RefNum = RefNum(),
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = TransactionDate(),
                                Description = transaction.Description,
                                TransactType = transaction.TransactType
                            };
                            transaction.SuccessMessage = $"Tnx: Debit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n  Amt: NGN {transaction.Amount}\\n From: {transaction.AccountNumber}\\n Ref Number: {transact.RefNum}\\n Your balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
                            _transactionRepo.CreateTransaction(transact); 

                        }
                        else
                        {
                             transaction.Message = $"Oops!\\nYou are having low balance";
                              return transaction;
                        }
                           

                    }
                        else
                    {
                         transaction.Message = $"Oops!\\nGo to the bank and Upgrade your account";
                         return transaction;
                    }

                }
                else
                {
                    if(transaction.Amount < customer.AccountBalance && customer.AccountBalance >= 500 )
                    {
                        customer.AccountBalance-=transaction.Amount;
                            //  transaction.AccountBalance = customer.AccountBalance;
                            // transaction.RefNum= RefNum();
                              var transact = new Transaction{
                                AccountBalance = customer.AccountBalance,
                                AccountNumber = customer.AccountNumber,
                                RefNum = RefNum(),
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = TransactionDate(),
                                Description = transaction.Description,
                                TransactType = transaction.TransactType
                             };
                             transaction.SuccessMessage = $"Tnx: Debit\\n Acc: {transaction.AccountNumber[0]}{transaction.AccountNumber[1]}*****{transaction.AccountNumber[7]}{transaction.AccountNumber[8]}*\\n Amt: NGN {transaction.Amount}\\n From: {transaction.AccountNumber}\\n Ref Number: {transact.RefNum}\\n Balance : # {customer.AccountBalance}\\n Date: {transact.DateCreated}";
                             _transactionRepo.CreateTransaction(transact); 
                    }
                     else
                        {
                             transaction.Message = $"Oops!\\nYou are having low balance";
                              return transaction;
                        }
                }  
             }
           }
           else
           {
            transaction.Message = $"Oops!\\nWrong pin";
             return transaction;
           }
           
             return new CreateTransactionRequestModel{
                                AccountNumber = customer.AccountNumber,
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                Description = transaction.Description,
                                TransactType = transaction.TransactType,
                                Message = transaction.Message,
                                SuccessMessage = transaction.SuccessMessage                          
             };
        }

        public void DeleteTransactionUsingRefNum(string refNum)
        {
            var transaction =_transactionRepo.GetTransactionByRefNum(refNum);
            var transact = new Transaction {
                               AccountBalance = transaction.AccountBalance,
                                AccountNumber = transaction.AccountNumber,
                                RefNum = refNum,
                                Amount = transaction.Amount,
                                RecipientAccountNumber = transaction.RecipientAccountNumber,
                                Pin = transaction.Pin,
                                DateCreated = transaction.DateCreated,
                                Description = transaction.Description,
                                TransactType = transaction.TransactType

                               };
            _transactionRepo.DeleteTransactionUsingRefNum(transact);
        }

        public IList<TransactionResponseModel> GetAllTransaction()
        {
           var transactions = _transactionRepo.GetAllTransaction();
           return transactions.Select(item => new TransactionResponseModel{
                                    AccountNumber = item.AccountNumber,
                                    Amount = item.Amount,
                                    RecipientAccountNumber = item.RecipientAccountNumber,
                                    Pin = item.Pin,
                                    Description = item.Description,
                                    TransactType = item.TransactType,
                                    AccountBalance = item.AccountBalance,
                                    RefNum = item.RefNum,
                                     DateCreated = item.DateCreated,

           }).ToList();
        }

        public IList<TransactionResponseModel> GetAllTransactionUsingAccountNumber(string accountNumber)
        {
            var customer = _customerRepo.GetCustomerByAccountnumber(accountNumber);
            var transactions = _transactionRepo.GetAllTransactionUsingAccountNumber(customer.AccountNumber);
              return transactions.Select(item => new TransactionResponseModel{
                                    AccountNumber = item.AccountNumber,
                                    Amount = item.Amount,
                                    RecipientAccountNumber = item.RecipientAccountNumber,
                                    Pin = item.Pin,
                                    Description = item.Description,
                                    TransactType = item.TransactType,
                                    AccountBalance = item.AccountBalance,
                                    RefNum = item.RefNum,
                                     DateCreated = item.DateCreated,

           }).ToList();
        }

        public TransactionResponseModel GetTransactionByRefNum(string refNum)
        {
            var transaction = _transactionRepo.GetTransactionByRefNum(refNum);
                               return new TransactionResponseModel{
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
            // return _transactionRepo.GetTransactionByRefNum(transaction.RefNum);
        }
       public TransactionResponseModel GetTransactionByAccount(string accountNumber)
       {
           var transaction =  _transactionRepo.GetTransactionByAccountNumber(accountNumber);
                               return new TransactionResponseModel{
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

        public string RefNum()
        {
             string alpha  ="abcdefghijklmnopqrstuvwxyz".ToUpper();
                var i = new Random().Next(25);
                var j = new Random().Next(25);
                var k = new Random().Next(25,99);
                return $"Ref{k}{i}{j}{alpha[i]}{alpha[j]}" ;

        }

         public string  TransactionDate()
        {
           return DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

        }

    }
}
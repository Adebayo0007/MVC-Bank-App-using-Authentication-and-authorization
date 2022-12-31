using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models.DTOs
{
    public class TransactionDTO
    {
         
        [DisplayName("Ref Number")]
        public string RefNum{get;set;}
        [DisplayName("Transaction Type")]
        public TransactionType TransactType {get; set;}
        public string Description {get;set;}

         [DisplayName("Account Number")]
        public string AccountNumber{get;set;}

        public Customer Customer {get;set;}
        public double Amount{get;set;}
        public string Pin{get;set;}
         [DisplayName("Account Balance")]
        public double AccountBalance{get;set;}
         [DisplayName("Date Created")]
        public DateTime DateCreated {get;set;} = DateTime.Now;
        public string? RecipientAccountNumber {get; set;}
        
    }

         public class TransactionRequestModel
    {
          [DisplayName("Ref Number")]
        public string RefNum{get;set;}
        [DisplayName("Transaction Type")]
        public TransactionType TransactType {get; set;}
        public string Description {get;set;}

         [DisplayName("Account Number")]
        public string AccountNumber{get;set;}

        public Customer Customer {get;set;}
        public double Amount{get;set;}
        public string Pin{get;set;}
         [DisplayName("Account Balance")]
        public double AccountBalance{get;set;}
         [DisplayName("Date Created")]
        public DateTime DateCreated {get;set;}
        public string? RecipientAccountNumber {get; set;}
    }
}
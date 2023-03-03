using System.ComponentModel;
using MVC_MobileBankApp.Models.Enum;

namespace MVC_MobileBankApp.Models.DTOs.TransactionDto
{
    public class TransactionResponseModel
    {
           [DisplayName("Ref Number")]
        public string RefNum{get;set;}

        [DisplayName("Transaction Type")]
        public TransactionType TransactType {get; set;}
        public string? Description {get;set;}

         [DisplayName("Account Number")]
        public string AccountNumber{get;set;}

        [DisplayName("Amount (#)")]
        public double Amount{get;set;}
        public string Pin{get;set;}
         [DisplayName("Account Balance")]
        public double AccountBalance{get;set;}

       public string DateCreated {get;set;} 
        public string? RecipientAccountNumber {get; set;}
        
    }
}
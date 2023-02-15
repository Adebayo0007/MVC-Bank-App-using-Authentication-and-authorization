using MVC_MobileBankApp.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_MobileBankApp.Models

{
    public class Transaction
    {
        [Key]
        [DisplayName("Ref Number")]
        public string RefNum{get;set;}
        [DisplayName("Transaction Type")]
        public TransactionType TransactType {get; set;}
        public string? Description {get;set;}

        [ForeignKey("AccountNumber")]
        [DisplayName("Account Number")]
        public string AccountNumber{get;set;}

        public Customer Customer {get;set;}
        public double Amount{get;set;}
        public string Pin{get;set;}
         [DisplayName("Account Balance")]
        public double AccountBalance{get;set;}
         [DisplayName("Date Created")]
        public string DateCreated {get;set;} 
        public string? RecipientAccountNumber {get; set;}
    }
}